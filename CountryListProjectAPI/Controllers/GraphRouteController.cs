namespace CountryListProjectAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class GraphRouteController : ControllerBase
    {
        private readonly IGraphRouteService _graphRouteService;
        public GraphRouteController(IGraphRouteService graphRouteService)
        {
            _graphRouteService = graphRouteService;
        }

        [SwaggerOperation(Summary = "Retrieves all Graph Routes")]
        [HttpGet]
        public IActionResult Get()
        {
            var graphRoutes = _graphRouteService.GetAllGraphRoutes();
            return Ok(graphRoutes);
        }

        [SwaggerOperation(Summary = "Retrieves a specific Graph Route by id")]        
        [HttpGet("graph/{id}")]
        public IActionResult Get(int id)
        {
            var graphRoute = _graphRouteService.GetGraphRouteById(id);
            if (graphRoute == null)
            {
                return NotFound();
            }
            return Ok(graphRoute);
        }

        [SwaggerOperation(Summary = "Retrieves path from USA to a specific country")]
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            var country = _graphRouteService.GetRouteByCode(code);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [SwaggerOperation(Summary = "Create new Graph Route")]
        [HttpPost]
        public IActionResult Create(CreateGraphRouteDto newGraphRoute)
        {
            var graphRoute = _graphRouteService.AddNewGraphRoute(newGraphRoute);
            return Created($"api/graphRoutes/{graphRoute.Id}", graphRoute);
        }

        [SwaggerOperation(Summary = "Update an existing Graph Route")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateGraphRouteDto updateGraphRoute)
        {
            _graphRouteService.UpdateGraphRoute(id, updateGraphRoute);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific Graph Route")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _graphRouteService.DeleteGraphRoute(id);
            return NoContent();
        }

    }
}
