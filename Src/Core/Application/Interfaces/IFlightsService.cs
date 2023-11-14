using Application.Models.Flight;
using Application.Models.General;
using ClientSdk;

namespace Application.Interfaces
{
    public interface IFlightsService
    {
        Task<Response<List<FlightModel>>> GetFlights(Filter filter, CancellationToken cancellationToken);

    }
}
