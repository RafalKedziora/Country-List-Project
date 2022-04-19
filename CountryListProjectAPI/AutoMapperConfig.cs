namespace CountryListProjectAPI
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                #region Country

                cfg.CreateMap<Country, CountryDto>();
                cfg.CreateMap<CreateCountryDto, Country>();
                cfg.CreateMap<UpdateCountryDto, Country>();
                cfg.CreateMap<IEnumerable<Country>, ListCountryDto>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src));

                #endregion

                #region GraphRoute

                cfg.CreateMap<GraphRoute, GraphRouteDto>();
                cfg.CreateMap<CreateGraphRouteDto, GraphRoute>();
                cfg.CreateMap<UpdateGraphRouteDto, GraphRoute>();
                cfg.CreateMap<IEnumerable<GraphRoute>, ListGraphRouteDto>()
                .ForMember(dest => dest.GraphRoutes, opt => opt.MapFrom(src => src));

                #endregion
            }).CreateMapper();
    }
}
