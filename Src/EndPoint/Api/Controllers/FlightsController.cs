using Application.Interfaces;
using Application.Models.Flight;
using ClientSdk;
using Microsoft.AspNetCore.Mvc;
using Application.Models.General;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : Controller
    {
        private readonly IFlightsService flightsService;

        public FlightsController(IFlightsService flightsService)
        {
            this.flightsService = flightsService;
        }

        [HttpGet(Routes.GetFlights)]
        public async Task<Response<List<FlightModel>>> GetFlights([FromQuery]Filter filter)
        {
            return await flightsService.GetFlights(filter);
        }
    }

  
}
