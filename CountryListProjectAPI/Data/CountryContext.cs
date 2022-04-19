namespace CountryListProjectAPI.Data
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<GraphRoute> GraphRoutes { get; set; }
        public DbSet<CountryRoute> CountryRoute { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryRoute>().HasKey(cr => new { cr.CountryId, cr.RouteId });
            modelBuilder.Entity<CountryRoute>()
                .HasOne<Country>(cr => cr.Country)
                .WithMany(c => c.GraphRoutes)
                .HasForeignKey(cr => cr.CountryId);
            
            modelBuilder.Entity<CountryRoute>()
                .HasOne<GraphRoute>(cr => cr.GraphRoute)
                .WithMany(r => r.Countries)
                .HasForeignKey(cr => cr.RouteId);
        }
    }
}
