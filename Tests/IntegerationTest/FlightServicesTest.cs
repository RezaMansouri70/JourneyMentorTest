
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Persistence;
using RichardSzalay.MockHttp;

namespace IntegerationTest.BookServices
{
    public class FlightServicesTest : IClassFixture<ApplicationTestFixture>
    {
        private readonly IFlightsService _manager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProjectContext _dbContext;


        public FlightServicesTest(ApplicationTestFixture fixture)
        {

            #region Arrange

            _dbContext = fixture.ApplicationDbContext;
            _unitOfWork = new UnitOfWork(_dbContext);

            //Mock IConfiguration
            var AccessKey = new Dictionary<string, string?> {{"AviationstackSetting:AccessKey", "cc87b1a25245d61a7db964fe5edf9f01" } };
            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(AccessKey).Build();

            //Mock HttpClient
            var mockHttpMessageHandler = new MockHttpMessageHandler();
            mockHttpMessageHandler
                .When("http://api.aviationstack.com/v1/flights?access_key=cc87b1a25245d61a7db964fe5edf9f01&limit=1&offset=0")
                .Respond("application/json", "{\"Success\":true,\"Data\":[{\"flight_date\":\"2023-11-05\",\"flight_status\":\"scheduled\",\"departure\":{\"airport\":\"Auckland International\",\"timezone\":\"Pacific/Auckland\",\"iata\":\"AKL\",\"icao\":\"NZAA\",\"terminal\":\"I\",\"gate\":null,\"delay\":60,\"scheduled\":\"2023-11-05T04:40:00+03:30\",\"estimated\":\"2023-11-05T04:40:00+03:30\",\"actual\":null,\"estimated_runway\":null,\"actual_runway\":null},\"arrival\":{\"airport\":\"Kuala Lumpur International Airport (klia)\",\"timezone\":\"Asia/Kuala_Lumpur\",\"iata\":\"KUL\",\"icao\":\"WMKK\",\"terminal\":\"1\",\"gate\":null,\"baggage\":null,\"delay\":null,\"scheduled\":\"2023-11-05T10:50:00+03:30\",\"estimated\":\"2023-11-05T10:50:00+03:30\",\"actual\":null,\"estimated_runway\":null,\"actual_runway\":null},\"airline\":{\"name\":\"KLM\",\"iata\":\"KL\",\"icao\":\"KLM\"},\"flight\":{\"number\":\"4096\",\"iata\":\"KL4096\",\"icao\":\"KLM4096\",\"codeshared\":{\"airline_name\":\"malaysia airlines\",\"airline_iata\":\"mh\",\"airline_icao\":\"mas\",\"flight_number\":\"132\",\"flight_iata\":\"mh132\",\"flight_icao\":\"mas132\"}},\"aircraft\":null,\"live\":null}],\"Error\":0,\"ErrorMessage\":null,\"PageIndex\":1,\"PageSize\":1,\"TotalRecords\":347659}\r\n");


            _manager = new FlightsService(mockHttpMessageHandler.ToHttpClient(), configuration, _unitOfWork);

            #endregion
        }

        [Fact]
        public void should_get_flights_from_the_source()
        {
            // Act
            var result = _manager.GetFlights(new Application.Models.General.Filter() { PageIndex=1 , PageSize=1 }).GetAwaiter().GetResult();

            // Assert
            Assert.True(result.Success);
        }


    }
}
