using Application.Models.Flight;
using Application.Models.General;
using ClientSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFlightsService
    {
        Task<Response<List<FlightModel>>> GetFlights(Filter filter);

    }
}
