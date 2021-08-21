using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Services.Base;
using smart.charger.webui.Services.Contracts.Vehicles;


namespace smart.charger.webui.Services.Impls.Vehicles
{
  public class VehicleDataService : IVehicleDataService
  {
    private readonly HttpClient _httpClient;
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string Version { get; private set; }
    public VehicleDataService(IConfiguration configuration, HttpClient httpClient)
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

    public async Task<List<VehicleDto>> GetVehicleList(string authorizationToken = null)
    {
      List<VehicleDto> result = new List<VehicleDto>();

      var client = new RestClient($"{BaseAddr}/api/Vehicles");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"bearer {authorizationToken}");

      try
      {
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
          result = JsonConvert.DeserializeObject<List<VehicleDto>>(response.Content);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          VehicleErrorModel resultError = JsonConvert.DeserializeObject<VehicleErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
      }
      catch (Exception e)
      {
        throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
      }
      return result;
    }

    public async Task<VehicleDto> GetVehicle(int id)
    {
      VehicleDto result = new VehicleDto();

      var client = new RestClient($"{BaseAddr}/api/{Version}/Vehicles/{id}");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<VehicleDto>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        VehicleErrorModel resultError = JsonConvert.DeserializeObject<VehicleErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public async Task<int> GetTotalVehicleCount()
    {
      int result = 0;

      var client = new RestClient($"{BaseAddr}/api/{Version}/Vehicles/count-total");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<int>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        VehicleErrorModel resultError = JsonConvert.DeserializeObject<VehicleErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public Task<VehicleDto> CreateVehicle(VehicleForCreationDto vehicleToBeCreated)
    {
      throw new System.NotImplementedException();
    }

    public Task<VehicleDto> UpdateVehicle(Guid vehicleIdToBeUpdated, VehicleForModificationDto vehicleToBeUpdated)
    {
      throw new System.NotImplementedException();
    }

    public Task<VehicleDto> DeleteVehicle(Guid vehicleIdToBeDeleted)
    {
      throw new System.NotImplementedException();
    }
  }
}