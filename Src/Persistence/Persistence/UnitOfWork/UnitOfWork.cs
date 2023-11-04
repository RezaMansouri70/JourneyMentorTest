using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _context;

        public UnitOfWork(ProjectContext context)
        {
            _context = context;
            AirportRepository = new AirportRepository(_context);
            FlightRepository = new FlightRepository(_context);

        }

        public IAirportRepository AirportRepository { get; set; }
        public IFlightRepository FlightRepository { get; set; }



        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}