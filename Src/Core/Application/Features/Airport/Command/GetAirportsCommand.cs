using Application.Interfaces;
using Application.Models.Airport;
using Application.Models.General;
using ClientSdk;
using MediatR;

namespace Application.Features.Airport.Command
{

    public class GetAirportsCommand : Filter, IRequest<Response<List<AirportModel>>>
    {

    }

    public class GetAirportsCommandHandler : IRequestHandler<GetAirportsCommand, Response<List<AirportModel>>>
    {
        private readonly IAirportsService airportsService;
        public GetAirportsCommandHandler(IAirportsService airportsService)
        {
            this.airportsService = airportsService;
        }

        public async Task<Response<List<AirportModel>>> Handle(GetAirportsCommand request, CancellationToken cancellationToken)
        {
            return await airportsService.GetAirports(request , cancellationToken);
        }

    }
}
