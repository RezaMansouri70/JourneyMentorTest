using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSdk
{
    public struct Routes
    {
        public const string GetAirports = "/api/Airports/GetAirports";
       

        public const string GetFlights = "/api/Flights/GetFlights";
      
    }

    public class AppConfig
    {
        public string ApiUrl { get; set; }

        public AppConfig()
        {
            ApiUrl = "http://localhost:7057";
        }
    }
}
