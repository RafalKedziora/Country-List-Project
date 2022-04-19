namespace CountryListProjectAPI.Service
{
    public interface IGraphRouteService
    {
        ListGraphRouteDto GetAllGraphRoutes();
        GraphRouteDto GetGraphRouteById(int id);
        GraphRouteDto AddNewGraphRoute(CreateGraphRouteDto newGraphRoute);
        void UpdateGraphRoute(int id, UpdateGraphRouteDto updatedGraphRoute);
        void DeleteGraphRoute(int id);
        CodesPath GetRouteByCode(string code);
    }
}
