using Domain.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        public AirportRepository(ProjectContext context) : base(context)
        {
        }
    }
}
