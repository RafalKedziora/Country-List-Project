var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IGraphRouteService, GraphRouteService>();
builder.Services.AddScoped<IGraphRouteRepository, GraphRouteRepository>();

#region Validators

builder.Services.AddScoped<IValidator<CreateCountryDto>, CreateCountryDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateCountryDto>, UpdateCountryDtoValidator>();
builder.Services.AddScoped<IValidator<CreateGraphRouteDto>, CreateGraphRouteDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateGraphRouteDto>, UpdateGraphRouteDtoValidator>();

#endregion

builder.Services.AddSingleton(AutoMapperConfig.Initialize());
builder.Services.AddDbContext<CountryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CountriesDB")));
builder.Services.AddTransient<DataSeeder>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MyIntentions API", Version = "v0.5" });
});

var app = builder.Build();

SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
