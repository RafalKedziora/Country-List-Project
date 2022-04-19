namespace CountryListProjectAPI.Entities
{
    public partial class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IList<CountryRoute>? GraphRoutes { get; set; }
    }
    
}
