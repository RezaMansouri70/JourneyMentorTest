using Persistence.Repositories;

namespace Persistence
{
    public interface IUnitOfWork
    {
        IAirportRepository AirportRepository { get; }
        IFlightRepository FlightRepository { get; }

        Task<int> Save();
    }
}
