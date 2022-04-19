namespace CountryListProjectAPI.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public ListCountryDto GetAllCountries()
        {
            var countries = _countryRepository.GetAll();
            return _mapper.Map<ListCountryDto>(countries);
        }

        public CountryDto GetCountryById(int id)
        {
            var country = _countryRepository.GetById(id);
            return _mapper.Map<CountryDto>(country);
        }
        
        public CountryDto AddNewCountry(CreateCountryDto newCountry)
        {
            var country = _mapper.Map<Country>(newCountry);
            _countryRepository.Add(country);
            return _mapper.Map<CountryDto>(country);
        }

        public void UpdateCountry(int id, UpdateCountryDto country)
        {
            var existingCountry = _countryRepository.GetById(id);
            var updatedCountry = _mapper.Map(country, existingCountry);
            _countryRepository.Update(updatedCountry);
        }
        
        public void DeleteCountry(int id)
        {
            var country = _countryRepository.GetById(id);
            _countryRepository.Delete(country);
        }
    }
}
