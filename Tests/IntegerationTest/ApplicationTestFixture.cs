using Domain.DomainClass;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace IntegerationTest
{
    public class ApplicationTestFixture 
    {
        public ProjectContext ApplicationDbContext { get; private set; }

        public ApplicationTestFixture()
        {
            SetServices();
            FillMockData();
        
        }
        private void SetServices()
        {
            var dbName = $"CrudTestDb_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<ProjectContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            ApplicationDbContext = new ProjectContext(dbContextOptions);
        }

        private void FillMockData()
        {
            FillMockFlights();

        }

        private void FillMockFlights()
        {
            Flight flight = new Flight(DateOnly.FromDateTime(DateTime.Now), "scheduled", "Nanning");

            ApplicationDbContext.Flights.Add(flight);

            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }

       

    }
}
