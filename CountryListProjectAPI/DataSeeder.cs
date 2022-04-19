namespace CountryListProjectAPI
{
    public class DataSeeder
    {
        private readonly CountryContext _countryContext;
        public DataSeeder(CountryContext countryContext)
        {
            _countryContext = countryContext;
        }

        public void Seed()
        {
            if (_countryContext.Database.CanConnect())
            {
                if (!_countryContext.Countries.Any())
                {
                    var countries = GetCountries();
                    _countryContext.Countries.AddRange(countries);
                    _countryContext.SaveChanges();

                    var setBorders = GetGraphRoutes();
                    _countryContext.GraphRoutes.UpdateRange(setBorders);
                    _countryContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Country> GetCountries()
        {
            var countries = new List<Country>()
            {
                new Country()
                {
                    Name = "Canada",
                    Code = "CAN"
                },
                new Country()
                {
                    Name = "United States",
                    Code = "USA"
                },
                new Country()
                {
                    Name = "Mexico",
                    Code = "MEX"
                },
                new Country()
                {
                    Name = "Belize",
                    Code = "BLZ"
                },
                new Country()
                {
                    Name = "Guatemala",
                    Code = "GTM"
                },
                new Country()
                {
                    Name = "El Salvador",
                    Code = "SLV"
                },
                new Country()
                {
                    Name = "Honduras",
                    Code = "HND"
                },
                new Country()
                {
                    Name = "Nicaragua",
                    Code = "NIC"
                },
                new Country()
                {
                    Name = "Costa Rica",
                    Code = "CRI"
                },
                new Country()
                {
                    Name = "Panama",
                    Code = "PAN"
                }
            };

            return countries;
        }

        private IEnumerable<GraphRoute> GetGraphRoutes()
        {
            var existingCountries = _countryContext.Countries.ToList();

            var graphRoutes = new List<GraphRoute>()
            {
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "USA").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "CAN").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "USA").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "MEX").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "MEX").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "BLZ").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "MEX").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "GTM").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "GTM").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "SLV").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "GTM").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "HND").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "HND").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "NIC").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "NIC").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "CRI").Id
                },
                new GraphRoute()
                {
                    OriginId = existingCountries.Single(x => x.Code == "CRI").Id,
                    DestinationId = existingCountries.Single(x => x.Code == "PAN").Id
                },
            };
            
            
            return graphRoutes;
        }
    }
}
