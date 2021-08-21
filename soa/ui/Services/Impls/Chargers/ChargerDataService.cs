using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Models.DTOs.Chargers;
using smart.charger.webui.Services.Base;
using smart.charger.webui.Services.Contracts.Chargers;

namespace smart.charger.webui.Services.Impls.Chargers
{
  public class ChargerDataService : IChargerDataService
  {
    private readonly HttpClient _httpClient;
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string Version { get; private set; }
    public ChargerDataService(IConfiguration configuration, HttpClient httpClient)
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

    public async Task<List<ChargerDto>> GetChargerList(string authorizationToken = null)
    {
      List<ChargerDto> result = new List<ChargerDto>();

      var client = new RestClient($"{BaseAddr}/api/chargers");
      var request = new RestRequest(Method.GET);
      
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"bearer {authorizationToken}");

      try
      {
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
          result = JsonConvert.DeserializeObject<List<ChargerDto>>(response.Content);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          ChargerErrorModel resultError = JsonConvert.DeserializeObject<ChargerErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
      }
      catch (Exception e)
      {
        throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
      }
      return result;
    }

    public async Task<ChargerDto> GetCharger(Guid id)
    {
      ChargerDto result = new ChargerDto();

      var client = new RestClient($"{BaseAddr}/api/{Version}/Chargers/{id}");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");
      //request.AddHeader("Authorization", $"bearer {authorizationToken}");

      try
      {
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
          result = JsonConvert.DeserializeObject<ChargerDto>(response.Content);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          ChargerErrorModel resultError = JsonConvert.DeserializeObject<ChargerErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
        else
        {
          ChargerErrorModel resultError = JsonConvert.DeserializeObject<ChargerErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
      }
      catch (Exception e)
      {
        throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
      }

      return result;
    }

    public async Task<int> GetTotalChargerCount()
    {
      int result = 0;

      var client = new RestClient($"{BaseAddr}/api/{Version}/Chargers/count-total");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      try
      {
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
          result = JsonConvert.DeserializeObject<int>(response.Content);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          ChargerErrorModel resultError = JsonConvert.DeserializeObject<ChargerErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
        else
        {
          ChargerErrorModel resultError = JsonConvert.DeserializeObject<ChargerErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
      }
      catch (Exception e)
      {
        throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
      }

      return result;
    }

    public Task<ChargerDto> CreateCharger(ChargerForCreationDto chargerToBeCreated)
    {
      throw new System.NotImplementedException();
    }

    public Task<ChargerDto> UpdateCharger(Guid chargerIdToBeUpdated, ChargerForModificationDto chargerToBeUpdated)
    {
      throw new System.NotImplementedException();
    }

    public Task<ChargerDto> DeleteCharger(Guid chargerIdToBeDeleted)
    {
      throw new System.NotImplementedException();
    }

    public async Task<int> FetchAvailableChargersCount(string authorizationToken = null)
    {
      int result = 0;

      try
      {
        var client = new RestClient($"{BaseAddr}/api/chargers/count-available");
        var request = new RestRequest(Method.GET);

        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", $"bearer {authorizationToken}");

        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
          result = JsonConvert.DeserializeObject<int>(response.Content);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          ChargerErrorModel resultError = JsonConvert.DeserializeObject<ChargerErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
      }
      catch (Exception e)
      {
        throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
      }

      return result;
    }

    public async Task<int> FetchChargersInUseCount(string authorizationToken = null)
    {
      int result = 0;

      try
      {
        var client = new RestClient($"{BaseAddr}/api/chargers/count-use");
        var request = new RestRequest(Method.GET);

        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", $"bearer {authorizationToken}");

        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
          result = JsonConvert.DeserializeObject<int>(response.Content);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          ChargerErrorModel resultError = JsonConvert.DeserializeObject<ChargerErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
      }
      catch (Exception e)
      {
        throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
      }
      return result;
    }
  }
}