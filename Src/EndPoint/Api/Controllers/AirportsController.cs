using Application.Interfaces;
using Application.Models.Flight;
using ClientSdk;
using Microsoft.AspNetCore.Mvc;
using Application.Models.General;
using Application.Models.Airport;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : Controller
    {
        private readonly IAirportsService airportsService;

        public AirportsController(IAirportsService airportsService)
        {
            this.airportsService = airportsService;
        }
        [HttpGet(Routes.GetAirports)]
        public async Task<Response<List<AirportModel>>> GetFlights([FromQuery]Filter filter)
        {
            return await airportsService.GetAirports(filter);
        }
    }

  
}
