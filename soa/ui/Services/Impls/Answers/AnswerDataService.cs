using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Services.Base;
using soa.ui.Models.DTOs.Answers;
using soa.ui.Services.Contracts.Answers;

namespace soa.ui.Services.Impls.Answers
{
    public class AnswerDataService : IAnswerDataService
    {
        private readonly HttpClient _httpClient;
        public IConfiguration Configuration { get; set; }
        public string BaseAddr { get; private set; }
        public string Version { get; private set; }

        public AnswerDataService(IConfiguration configuration, HttpClient httpClient)
        {
            Configuration = configuration;
            _httpClient = httpClient;
            OnCreated();
        }

        private void OnCreated()
        {
            //BaseAddr = Configuration["env"] == "prod" ? Configuration["RemoteUrl"] : Configuration["LocalUrl"];
            BaseAddr = Configuration["env"] == "prod" ? Configuration["LocalUrl"] : Configuration["LocalUrl"];
            Version = Configuration["version"];
        }

        public async Task<List<AnswerDto>> GetAnswerList(string authorizationToken = null)
        {
            List<AnswerDto> result = new List<AnswerDto>();

            var client = new RestClient($"{BaseAddr}/api/Answers");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    result = JsonConvert.DeserializeObject<List<AnswerDto>>(response.Content);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    AnswerErrorModel resultError = JsonConvert.DeserializeObject<AnswerErrorModel>(response.Content);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
                }
            }
            catch (Exception e)
            {
                throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
            }

            return result;
        }

        public async Task<AnswerDto> GetAnswer(int id)
        {
            AnswerDto result = new AnswerDto();

            var client = new RestClient($"{BaseAddr}/api/{Version}/answers/{id}");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<AnswerDto>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                AnswerErrorModel resultError = JsonConvert.DeserializeObject<AnswerErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<int> GetTotalAnswerCount()
        {
            int result = 0;

            var client = new RestClient($"{BaseAddr}/api/{Version}/answers/count-total");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                AnswerErrorModel resultError = JsonConvert.DeserializeObject<AnswerErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public Task<AnswerDto> CreateAnswer(AnswerForCreationDto answerToBeCreated)
        {
            throw new System.NotImplementedException();
        }

        public Task<AnswerDto> UpdateAnswer(Guid answerIdToBeUpdated, AnswerForModificationDto answerToBeUpdated)
        {
            throw new System.NotImplementedException();
        }

        public Task<AnswerDto> DeleteAnswer(Guid answerIdToBeDeleted)
        {
            throw new System.NotImplementedException();
        }
    }
}