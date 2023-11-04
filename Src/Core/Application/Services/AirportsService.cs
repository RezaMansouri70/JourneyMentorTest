using Application.Interfaces;
using Application.Models.Airport;
using Application.Models.Flight;
using Application.Models.General;
using ClientSdk;
using Domain.DomainClass;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AirportsService : IAirportsService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public AirportsService(HttpClient httpClient, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
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

            // Save In DB
            var airportnameInResult = data.data.Select(x => x.airport_name).ToArray();
            var NotExistedName = _unitOfWork.AirportRepository.Find(x => (!airportnameInResult.Contains(x.airport_name.Value))).Select(x=>x.airport_name.Value).ToArray();
            //.Where(x=> !airportnameInResult.Contains(x.airport_name.Value)  )
            if (NotExistedName.Any()) 
            {
                var dataMustSaveInDB = data.data.Where(x => NotExistedName.Contains(x.airport_name)).Select(a => new Airport(a.airport_name, a.iata_code, a.icao_code, a.latitude, a.longitude, a.geoname_id, a.timezone, a.gmt, a.phone_number, a.country_name, a.country_iso2, a.city_iata_code)).ToList();
                await _unitOfWork.AirportRepository.AddRange(dataMustSaveInDB);
                await _unitOfWork.Save();
            }
            
            return  new Response<List<AirportModel>>()
            {
                Data = data?.data,
                Success = true,
                PageIndex = filter.PageIndex,
                PageSize = filter.PageSize,
                TotalRecords = data != null && data.pagination != null ? data.pagination.total : 0
            };

        }
    }

}
