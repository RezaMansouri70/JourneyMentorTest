using Application.Interfaces;
using Application.Models.Airport;
using Application.Models.Flight;
using Application.Models.General;
using ClientSdk;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AirportsService : IAirportsService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AirportsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task<Response<List<AirportModel>>> GetAirports(Filter filter)
        {

            var data = new ResponeFromAviationstack<AirportModel>();
            try
            {
                var AccessKey = _configuration.GetSection("AviationstackSetting:AccessKey").Value;
                string requestUrl = "http://api.aviationstack.com/v1/airports?access_key=" + AccessKey + "&limit=" + filter.PageSize + "&offset=" + ((filter.PageIndex - 1) * filter.PageSize);
                data = await _httpClient.GetFromJsonAsync<ResponeFromAviationstack<AirportModel>>(requestUrl);
            }
            catch (Exception ex)
            {

                return new Response<List<AirportModel>>()
                {
                    Data = new List<AirportModel>(),
                    Success = false,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    TotalRecords = 0,
                    ErrorMessage = ex.Message
                };
                // We Can Log Err Here
            }

            return new Response<List<AirportModel>>()
            {
                Data = data?.data,
                Success = true,
                PageIndex = filter.PageIndex,
                PageSize = filter.PageSize,
                TotalRecords = data != null ? data.pagination.total : 0
            };
        }
    }

}
