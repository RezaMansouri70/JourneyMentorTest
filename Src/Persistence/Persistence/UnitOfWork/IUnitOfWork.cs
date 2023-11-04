using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IUnitOfWork
    {
        IAirportRepository AirportRepository { get; }
        IFlightRepository FlightRepository { get; }

        Task<int> Save();
    }
}
