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
            FillMockAirports();


        }

        private void FillMockFlights()
        {
            Flight flight = new Flight(DateOnly.FromDateTime(DateTime.Now), "scheduled", "Nanning");

            ApplicationDbContext.Flights.Add(flight);

            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }

        private void FillMockAirports()
        {


            Airport airport = new Airport("Anaa", "AAA", "NTGA", "-17.05", "-145.41667", "6947726", "Pacific/Tahiti", "-10", "null", "French Polynesia", "PF", "AAA");

            ApplicationDbContext.Airports.Add(airport);

            ApplicationDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }



    }
}
