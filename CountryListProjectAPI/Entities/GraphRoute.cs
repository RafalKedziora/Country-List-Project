namespace CountryListProjectAPI.Entities
{
    public class GraphRoute
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }

        public IList<CountryRoute> Countries { get; set; }
    }
}
