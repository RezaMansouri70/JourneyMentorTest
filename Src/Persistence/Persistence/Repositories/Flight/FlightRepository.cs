
namespace Persistence.Repositories
{

    public class FlightRepository : Repository<Domain.DomainClass.Flight>, IFlightRepository
    {
        public FlightRepository(ProjectContext context) : base(context)
        {
        }
    }
}
