using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Services.Base;
using soa.ui.Models.DTOs.Tags;
using soa.ui.Services.Contracts.Tags;

namespace soa.ui.Services.Impls.Tags
{
    public class TagDataService : ITagDataService
    {
        private readonly HttpClient _httpClient;
        public IConfiguration Configuration { get; set; }
        public string BaseAddr { get; private set; }
        public string Version { get; private set; }

        public TagDataService(IConfiguration configuration, HttpClient httpClient)
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

        public async Task<List<TagDto>> GetTagList(string authorizationToken = null)
        {
            List<TagDto> result = new List<TagDto>();

            var client = new RestClient($"{BaseAddr}/api/tags");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    result = JsonConvert.DeserializeObject<List<TagDto>>(response.Content);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    TagErrorModel resultError = JsonConvert.DeserializeObject<TagErrorModel>(response.Content);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
                }
            }
            catch (Exception e)
            {
                throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
            }

            return result;
        }

        public async Task<TagDto> GetTag(int id)
        {
            TagDto result = new TagDto();

            var client = new RestClient($"{BaseAddr}/api/{Version}/tags/{id}");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<TagDto>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                TagErrorModel resultError = JsonConvert.DeserializeObject<TagErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<int> GetTotalTagCount()
        {
            int result = 0;

            var client = new RestClient($"{BaseAddr}/api/{Version}/tags/count-total");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                TagErrorModel resultError = JsonConvert.DeserializeObject<TagErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<TagDto> CreateTag(TagForCreationDto tagToBeCreated)
        {
            TagDto result = new TagDto();

            var client = new RestClient($"{BaseAddr}/api/tags");
            var request = new RestRequest("", Method.POST);

            request.AddJsonBody(tagToBeCreated);
            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<TagDto>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                TagErrorModel resultError = JsonConvert.DeserializeObject<TagErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<TagDto> UpdateTag(int tagIdToBeUpdated, TagForModificationDto tagToBeUpdated)
        {
            TagDto result = new TagDto();

            var client = new RestClient($"{BaseAddr}/api/tags/{tagIdToBeUpdated}");
            var request = new RestRequest("", Method.PUT);

            request.AddJsonBody(tagToBeUpdated);
            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<TagDto>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                TagErrorModel resultError = JsonConvert.DeserializeObject<TagErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<TagDto> DeleteTag(int tagIdToBeDeleted)
        {
            TagDto result = new TagDto();

            var client = new RestClient($"{BaseAddr}/api/tags/{tagIdToBeDeleted}");
            var request = new RestRequest("", Method.DELETE);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<TagDto>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                TagErrorModel resultError = JsonConvert.DeserializeObject<TagErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}