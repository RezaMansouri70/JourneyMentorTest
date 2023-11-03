using Application.Interfaces;
using Application.Models.Flight;
using Application.Models.General;
using ClientSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FlightsService : IFlightsService
    {
        
        public async Task<Response<List<FlightModel>>> GetFlights(Filter filter)
        {
            var client = new HttpClient();
            var data = new ResponeFromAviationstack<FlightModel>();
            try
            {
                 data = await client.GetFromJsonAsync<ResponeFromAviationstack<FlightModel>>("http://api.aviationstack.com/v1/flights?access_key=cc87b1a25245d61a7db964fe5edf9f01&limit=" + filter.PageSize + "&offset=" + ((filter.PageIndex - 1) * filter.PageSize));
            }
            catch (Exception ex)
            {

                return new Response<List<FlightModel>>()
                {
                    Data = new List<FlightModel>(),
                    Success = false,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    TotalRecords = 0,
                    ErrorMessage = ex.Message
                };
            }
           
            return new Response<List<FlightModel>>()
            {
                Data = data?.data ,
                Success = true ,
                PageIndex = filter.PageIndex,
                PageSize = filter.PageSize,
                TotalRecords = data.pagination.total
            };
        }
    }

}
