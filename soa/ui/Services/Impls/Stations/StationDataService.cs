using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Models.DTOs.Stations;
using smart.charger.webui.Services.Base;
using smart.charger.webui.Services.Contracts.Stations;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace smart.charger.webui.Services.Impls.Stations
{
  public class StationDataService : IStationDataService
  {
    private readonly HttpClient _httpClient;
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string Version { get; private set; }
    public StationDataService(IConfiguration configuration, HttpClient httpClient)
    {
      Configuration = configuration;
      _httpClient = httpClient;
      OnCreated();
    }
    private void OnCreated()
    {
      BaseAddr = Configuration["env"] == "prod" ? Configuration["RemoteUrl"] : Configuration["LocalUrl"];
      Version = Configuration["version"];
    }

    public async Task<List<StationDto>> GetStationList(string authorizationToken = null)
    {
      List<StationDto> result = new List<StationDto>();

      var client = new RestClient($"{BaseAddr}/api/Stations");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"bearer {authorizationToken}");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<List<StationDto>>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        StationErrorModel resultError = JsonConvert.DeserializeObject<StationErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }

      return result;
    }

    public async Task<StationDto> GetStation(Guid id)
    {
      StationDto result = new StationDto();

      var client = new RestClient($"{BaseAddr}/api/{Version}/Stations/{id}");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<StationDto>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        StationErrorModel resultError = JsonConvert.DeserializeObject<StationErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }

      return result;
    }

    public async Task<int> GetTotalStationCount()
    {
      int result = 0;

      var client = new RestClient($"{BaseAddr}/api/{Version}/Stations/count-total");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<int>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        StationErrorModel resultError = JsonConvert.DeserializeObject<StationErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }

      return result;
    }

    public Task<StationDto> CreateStation(StationForCreationDto stationToBeCreated)
    {
      throw new System.NotImplementedException();
    }

    public Task<StationDto> UpdateStation(Guid stationIdToBeUpdated, StationForModificationDto stationToBeUpdated)
    {
      throw new System.NotImplementedException();
    }

    public Task<StationDto> DeleteStation(Guid stationIdToBeDeleted)
    {
      throw new System.NotImplementedException();
    }
  }
}