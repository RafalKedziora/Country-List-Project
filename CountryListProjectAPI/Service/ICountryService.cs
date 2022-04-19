namespace CountryListProjectAPI.Service
{
    public interface ICountryService
    {
        ListCountryDto GetAllCountries();
        CountryDto GetCountryById(int id);
        CountryDto AddNewCountry(CreateCountryDto newCountry);
        void UpdateCountry(int id, UpdateCountryDto updatedCountry);
        void DeleteCountry(int id);
    }
}
