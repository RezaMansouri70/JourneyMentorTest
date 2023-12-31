﻿using Application.Interfaces;
using Application.Models.Flight;
using Application.Models.General;
using ClientSdk;
using Microsoft.Extensions.Configuration;
using Persistence;
using System.Net.Http.Json;

namespace Application.Services
{
    public class FlightsService : IFlightsService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public FlightsService(HttpClient httpClient, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<List<FlightModel>>> GetFlights(Filter filter , CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
            var data = new ResponeFromAviationstack<FlightModel>();
            try
            {
                var AccessKey = _configuration.GetSection("AviationstackSetting:AccessKey").Value;
                string requestUrl = "http://api.aviationstack.com/v1/flights?access_key=" + AccessKey + "&limit=" + filter.PageSize + "&offset=" + ((filter.PageIndex - 1) * filter.PageSize);
                data = await _httpClient.GetFromJsonAsync<ResponeFromAviationstack<FlightModel>>(requestUrl);
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
                // We Can Log Err Here
            }

            // Persist Data In Database
            var dataMustSaveInDB = data.data.Select(a => new Domain.DomainClass.Flight(a.flight_date, a.flight_status, a.departure.airport)).ToList();
            await _unitOfWork.FlightRepository.AddRange(dataMustSaveInDB);
            await _unitOfWork.Save();



            return new Response<List<FlightModel>>()
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
