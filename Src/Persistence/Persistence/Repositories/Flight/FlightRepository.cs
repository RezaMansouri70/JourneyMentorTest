using Domain.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(ProjectContext context) : base(context)
        {
        }
    }
}
