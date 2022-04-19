namespace CountryListProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [SwaggerOperation(Summary = "Retrieves all Countries")]
        [HttpGet]
        public IActionResult Get()
        {
            var countries = _countryService.GetAllCountries();
            return Ok(countries);
        }

        [SwaggerOperation(Summary = "Retrieves a specific Country by id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var country = _countryService.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [SwaggerOperation(Summary = "Create a new country")]
        [HttpPost]
        public IActionResult Create(CreateCountryDto newCountry)
        {
            var country = _countryService.AddNewCountry(newCountry);
            return Created($"api/countries/{country.Id}", country);
        }

        [SwaggerOperation(Summary = "Update and existing country")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCountryDto updatedCountry)
        {
            _countryService.UpdateCountry(id, updatedCountry);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific country")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _countryService.DeleteCountry(id);
            return NoContent();
        }
    }
}
