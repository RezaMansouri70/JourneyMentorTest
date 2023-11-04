using Application.Features.Airport.Command;
using ClientSdk;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
