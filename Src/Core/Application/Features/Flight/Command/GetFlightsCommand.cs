using Application.Interfaces;
using Application.Models.Airport;
using Application.Models.Flight;
using Application.Models.General;
using ClientSdk;
using MediatR;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Flight.Command
{

    public  class GetFlightsCommand : Filter, IRequest<Response<List<FlightModel>>>
    {

    }

    public class GetFlightsCommandHandler : IRequestHandler<GetFlightsCommand, Response<List<FlightModel>>>
    {
        private readonly IFlightsService flightsService;
        public GetFlightsCommandHandler(IFlightsService flightsService)
        {
            this.flightsService = flightsService;
        }

        public async Task<Response<List<FlightModel>>> Handle(GetFlightsCommand request, CancellationToken cancellationToken)
        {          
            return await flightsService.GetFlights(request);
        }

    }
}
