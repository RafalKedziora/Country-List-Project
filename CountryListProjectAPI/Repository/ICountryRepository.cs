namespace CountryListProjectAPI.Repository
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetAll();
        Country GetById(int id);
        Country Add(Country country);
        void Update(Country country);
        void Delete(Country country);
    }
}
