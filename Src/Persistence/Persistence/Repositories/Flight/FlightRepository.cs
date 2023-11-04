using Domain.DomainClass;

namespace Persistence.Repositories
{

    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(ProjectContext context) : base(context)
        {
        }
    }
}
