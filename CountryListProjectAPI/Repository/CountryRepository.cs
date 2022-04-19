namespace CountryListProjectAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountryContext _context;
        public CountryRepository(CountryContext context)
        {
            _context = context;
        }

        public IQueryable<Country> GetAll()
        {
            return _context.Countries;
        }

        public Country GetById(int id)
        {
            return _context.Countries.SingleOrDefault(x => x.Id == id);
        }
        
        public Country Add(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return country;
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }
    }
}
