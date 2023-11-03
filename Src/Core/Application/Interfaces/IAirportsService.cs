using Application.Models.Airport;
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
    public interface IAirportsService
    {
        Task<Response<List<AirportModel>>> GetAirports(Filter filter);

    }
}
