using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Models.DTOs.Sessions;
using smart.charger.webui.Services.Base;
using smart.charger.webui.Services.Contracts.Sessions;

namespace smart.charger.webui.Services.Impls.Sessions
{
  public class SessionDataService : ISessionDataService
  {
    private readonly HttpClient _httpClient;
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string Version { get; private set; }
    public SessionDataService(IConfiguration configuration, HttpClient httpClient)
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

    public async Task<List<SessionDto>> GetSessionList(string authorizationToken = null)
    {
      List<SessionDto> result = new List<SessionDto>();

      var client = new RestClient($"{BaseAddr}/evcharge/api");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"bearer {authorizationToken}");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<List<SessionDto>>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        SessionErrorModel resultError = JsonConvert.DeserializeObject<SessionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public async Task<SessionDto> GetSession(int id)
    {
      SessionDto result = new SessionDto();

      var client = new RestClient($"{BaseAddr}/api/{Version}/Sessions/{id}");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<SessionDto>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        SessionErrorModel resultError = JsonConvert.DeserializeObject<SessionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      else
      {
        SessionErrorModel resultError = JsonConvert.DeserializeObject<SessionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public async Task<int> GetTotalSessionCount()
    {
      int result = 0;

      var client = new RestClient($"{BaseAddr}/api/{Version}/Sessions/count-total");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<int>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        SessionErrorModel resultError = JsonConvert.DeserializeObject<SessionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      else
      {
        SessionErrorModel resultError = JsonConvert.DeserializeObject<SessionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public Task<SessionDto> CreateSession(SessionForCreationDto sessionToBeCreated)
    {
      throw new System.NotImplementedException();
    }

    public Task<SessionDto> UpdateSession(Guid sessionIdToBeUpdated, SessionForModificationDto sessionToBeUpdated)
    {
      throw new System.NotImplementedException();
    }

    public Task<SessionDto> DeleteSession(Guid sessionIdToBeDeleted)
    {
      throw new System.NotImplementedException();
    }

    public async Task<int> FetchFinishedSessionCount(string authorizationToken = null)
    {
      int result = 0;

      var client = new RestClient($"{BaseAddr}/evcharge/api/count-finished");
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
        SessionErrorModel resultError = JsonConvert.DeserializeObject<SessionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public async Task<int> FetchActiveSessionCount(string authorizationToken = null)
    {
      int result = 0;

      var client = new RestClient($"{BaseAddr}/evcharge/api/count-active");
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
        SessionErrorModel resultError = JsonConvert.DeserializeObject<SessionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }

      return result;
    }
  }
}