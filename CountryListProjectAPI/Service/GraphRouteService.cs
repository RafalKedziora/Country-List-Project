namespace CountryListProjectAPI.Service
{
    public class GraphRouteService : IGraphRouteService
    {
        private readonly IGraphRouteRepository _graphRouteRepository;
        private readonly IMapper _mapper;

        public GraphRouteService(IGraphRouteRepository graphRouteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _graphRouteRepository = graphRouteRepository;
        }

        public ListGraphRouteDto GetAllGraphRoutes()
        {
            var graphRoutes = _graphRouteRepository.GetAll();
            return _mapper.Map<ListGraphRouteDto>(graphRoutes);
        }

        public GraphRouteDto GetGraphRouteById(int id)
        {
            var graphRoute = _graphRouteRepository.GetById(id);
            return _mapper.Map<GraphRouteDto>(graphRoute);
        }

        public CodesPath GetRouteByCode(string code)
        {
            var countries = _graphRouteRepository.GetByCode(code);
            CodesPath cp = new CodesPath();
            cp.Codes = countries;
            return cp;
        }

        public GraphRouteDto AddNewGraphRoute(CreateGraphRouteDto newGraphRoute)
        {
            var graphRoute = _mapper.Map<GraphRoute>(newGraphRoute);
            _graphRouteRepository.Add(graphRoute);
            return _mapper.Map<GraphRouteDto>(graphRoute);
        }

        public void UpdateGraphRoute(int id, UpdateGraphRouteDto updatedGraphRoute)
        {
            var existingGraphRoute = _graphRouteRepository.GetById(id);
            var updtdGraphRoute = _mapper.Map(updatedGraphRoute, existingGraphRoute);
            _graphRouteRepository.Update(updtdGraphRoute);
        }

        public void DeleteGraphRoute(int id)
        {
            var country = _graphRouteRepository.GetById(id);
            _graphRouteRepository.Delete(country);
        }
    }
}
