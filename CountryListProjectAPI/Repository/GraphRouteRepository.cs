namespace CountryListProjectAPI.Repository
{
    public class GraphRouteRepository : IGraphRouteRepository
    {
        private readonly CountryContext _context;
        public GraphRouteRepository(CountryContext context)
        {
            _context = context;
        }

        public IQueryable<GraphRoute> GetAll()
        {
            return _context.GraphRoutes;
        }

        public GraphRoute GetById(int id)
        {
            return _context.GraphRoutes.SingleOrDefault(x => x.Id == id);
        }

        public List<string> GetByCode(string sourceCountryCode)
        {
            var countryRoutes = _context.Countries.Join(_context.GraphRoutes, country => country.Id, route => route.OriginId, (c, p) => new { c, p }).ToList();
            var verticles = countryRoutes.Count() + 2;
            var g = new Graph(verticles);
            
            countryRoutes.ForEach(x => g.AddEdge(x.p.OriginId, x.p.DestinationId));

            var startId = _context.Countries.FirstOrDefault(c => c.Code == "USA").Id;
            var targetId = _context.Countries.FirstOrDefault(x => x.Code == sourceCountryCode).Id;
            g.ShortesPath(startId, targetId);

            var resultPath = new List<string>();
            
            g.results.ForEach(x => resultPath.Add(_context.Countries.FirstOrDefault(country => country.Id == x).Code));
            resultPath.Reverse();
            
            return resultPath;
        }        

        public GraphRoute Add(GraphRoute graphRoute)
        {
            _context.GraphRoutes.Add(graphRoute);
            _context.SaveChanges();
            return graphRoute;
        }

        public void Update(GraphRoute graphRoute)
        {
            _context.GraphRoutes.Update(graphRoute);
            _context.SaveChanges();
        }

        public void Delete(GraphRoute graphRoute)
        {
            _context.GraphRoutes.Remove(graphRoute);
            _context.SaveChanges();
        }
    }
}
