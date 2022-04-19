namespace CountryListProjectAPI.Entities
{
    public class CountryRoute
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int RouteId { get; set; }
        public GraphRoute GraphRoute { get; set; }
    }
}
