using Domain.DomainClass;

namespace Persistence.Repositories
{

    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        public AirportRepository(ProjectContext context) : base(context)
        {
        }
    }
}
