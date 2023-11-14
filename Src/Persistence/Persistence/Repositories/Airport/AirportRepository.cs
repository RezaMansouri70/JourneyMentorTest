using Domain.DomainClass;

namespace Persistence.Repositories
{

    public class AirportRepository : Repository<Domain.DomainClass.Airport>, IAirportRepository
    {
        public AirportRepository(ProjectContext context) : base(context)
        {
        }
    }
}
