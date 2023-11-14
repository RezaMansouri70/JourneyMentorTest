using Application.Models.Airport;
using Application.Models.General;
using ClientSdk;

namespace Application.Interfaces
{
    public interface IAirportsService
    {
        Task<Response<List<AirportModel>>> GetAirports(Filter filter , CancellationToken cancellationToken);

    }
}
