using Application.Interfaces;
using Application.Models.Flight;
using ClientSdk;
using Microsoft.AspNetCore.Mvc;
using Application.Models.General;
using Application.Models.Airport;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Application.Features.Airport.Command;
using Domain.ValueObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : Controller
    {
        private readonly IMediator _mediator;

        public AirportsController(IMediator mediator) => _mediator = mediator;

        [HttpGet(Routes.GetAirports)]
        public async Task<IActionResult> GetFlights([FromQuery] GetAirportsCommand command, CancellationToken token)
        {
            try
            {
                return Ok(await _mediator.Send(command, token));
            }
            catch (TaskCanceledException)
            {
                return Empty;
            }
           

        }


    }
}
