using Application.Features.Flight.Command;
using ClientSdk;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : Controller
    {

        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator) => _mediator = mediator; 

        [HttpGet(Routes.GetFlights)]
        public async Task<IActionResult> GetFlights([FromQuery] GetFlightsCommand command, CancellationToken token)
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
