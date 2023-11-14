
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Persistence;
using RichardSzalay.MockHttp;

namespace IntegerationTest.BookServices
{
    public class AriportServicesTest : IClassFixture<ApplicationTestFixture>
    {
        private readonly IAirportsService _manager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProjectContext _dbContext;


        public AriportServicesTest(ApplicationTestFixture fixture)
        {

            #region Arrange

            _dbContext = fixture.ApplicationDbContext;
            _unitOfWork = new UnitOfWork(_dbContext);

            //Mock IConfiguration
            var AccessKey = new Dictionary<string, string?> { { "AviationstackSetting:AccessKey", "cc87b1a25245d61a7db964fe5edf9f01" } };
            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(AccessKey).Build();

            //Mock HttpClient
            var mockHttpMessageHandler = new MockHttpMessageHandler();
            mockHttpMessageHandler
                .When("http://api.aviationstack.com/v1/airports?access_key=cc87b1a25245d61a7db964fe5edf9f01&limit=1&offset=0")
                .Respond("application/json", "{\"Success\":true,\"Data\":[{\"airport_name\":\"Anaa\",\"iata_code\":\"AAA\",\"icao_code\":\"NTGA\",\"latitude\":\"-17.05\",\"longitude\":\"-145.41667\",\"geoname_id\":\"6947726\",\"timezone\":\"Pacific/Tahiti\",\"gmt\":\"-10\",\"phone_number\":null,\"country_name\":\"French Polynesia\",\"country_iso2\":\"PF\",\"city_iata_code\":\"AAA\"}],\"Error\":0,\"ErrorMessage\":null,\"PageIndex\":1,\"PageSize\":1,\"TotalRecords\":6706}");


            _manager = new AirportsService(mockHttpMessageHandler.ToHttpClient(), configuration, _unitOfWork);

            #endregion
        }

        [Fact]
        public void should_get_airports_from_the_source_and_save_in_db()
        {
            // Act
            var result = _manager.GetAirports(new Application.Models.General.Filter() { PageIndex = 1, PageSize = 1 } , new CancellationToken()).GetAwaiter().GetResult();

            // Assert
            Assert.True(result.Success); //  Is Success Reading Data From Source
            Assert.True(_unitOfWork.AirportRepository.GetAll().ToList().Count > 1); //  Is Data Saved In Mock Database



        }


    }
}
