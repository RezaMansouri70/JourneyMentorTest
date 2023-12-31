﻿using Application.Interfaces;
using Application.Models.Airport;
using Application.Models.General;
using ClientSdk;
using Domain.DomainClass;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Persistence;
using System.Net.Http.Json;

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


        public async Task<Response<List<AirportModel>>> GetAirports(Filter filter , CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
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

            // Persist Data In Database

            var dataMustSaveInDB = data.data.Select(a => new Airport(a.airport_name, a.iata_code, a.icao_code, a.latitude, a.longitude, a.geoname_id, a.timezone, a.gmt, a.phone_number, a.country_name, a.country_iso2, a.city_iata_code)).ToList();
            await _unitOfWork.AirportRepository.AddRange(dataMustSaveInDB);
            await _unitOfWork.Save();


            return new Response<List<AirportModel>>()
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
