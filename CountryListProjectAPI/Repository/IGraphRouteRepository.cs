namespace CountryListProjectAPI.Repository
{
    public interface IGraphRouteRepository
    {
        IQueryable<GraphRoute> GetAll();
        GraphRoute GetById(int id);
        GraphRoute Add(GraphRoute graphRoute);
        void Update(GraphRoute graphRoute);
        void Delete(GraphRoute graphRoute);
        List<string> GetByCode(string code);
    }
}
