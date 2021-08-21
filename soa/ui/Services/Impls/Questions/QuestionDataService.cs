using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Services.Base;
using soa.ui.Models.DTOs.Questions;
using soa.ui.Services.Contracts.Questions;

namespace soa.ui.Services.Impls.Questions
{
  public class QuestionDataService : IQuestionDataService
  {
    private readonly HttpClient _httpClient;
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string Version { get; private set; }
    public QuestionDataService(IConfiguration configuration, HttpClient httpClient)
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

    public async Task<List<QuestionDto>> GetQuestionList(string authorizationToken = null)
    {
      List<QuestionDto> result = new List<QuestionDto>();

      var client = new RestClient($"{BaseAddr}/api/Questions");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"bearer {authorizationToken}");

      try
      {
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
          result = JsonConvert.DeserializeObject<List<QuestionDto>>(response.Content);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          QuestionErrorModel resultError = JsonConvert.DeserializeObject<QuestionErrorModel>(response.Content);
          throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
        }
      }
      catch (Exception e)
      {
        throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
      }
      return result;
    }

    public async Task<QuestionDto> GetQuestion(int id)
    {
      QuestionDto result = new QuestionDto();

      var client = new RestClient($"{BaseAddr}/api/{Version}/questions/{id}");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<QuestionDto>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        QuestionErrorModel resultError = JsonConvert.DeserializeObject<QuestionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public async Task<int> GetTotalQuestionCount()
    {
      int result = 0;

      var client = new RestClient($"{BaseAddr}/api/{Version}/questions/count-total");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<int>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        QuestionErrorModel resultError = JsonConvert.DeserializeObject<QuestionErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public Task<QuestionDto> CreateQuestion(QuestionForCreationDto questionToBeCreated)
    {
      throw new System.NotImplementedException();
    }

    public Task<QuestionDto> UpdateQuestion(Guid questionIdToBeUpdated, QuestionForModificationDto questionToBeUpdated)
    {
      throw new System.NotImplementedException();
    }

    public Task<QuestionDto> DeleteQuestion(Guid questionIdToBeDeleted)
    {
      throw new System.NotImplementedException();
    }
  }
}