using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Services.Base;
using soa.ui.Models.DTOs.Categories;
using soa.ui.Services.Contracts.Categories;

namespace soa.ui.Services.Impls.Categories
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly HttpClient _httpClient;
        public IConfiguration Configuration { get; set; }
        public string BaseAddr { get; private set; }
        public string Version { get; private set; }

        public CategoryDataService(IConfiguration configuration, HttpClient httpClient)
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

        public async Task<List<CategoryDto>> GetCategoryList(string authorizationToken = null)
        {
            List<CategoryDto> result = new List<CategoryDto>();

            var client = new RestClient($"{BaseAddr}/api/categories");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    result = JsonConvert.DeserializeObject<List<CategoryDto>>(response.Content);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    CategoryErrorModel resultError =
                        JsonConvert.DeserializeObject<CategoryErrorModel>(response.Content);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
                }
            }
            catch (Exception e)
            {
                throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
            }

            return result;
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            CategoryDto result = new CategoryDto();

            var client = new RestClient($"{BaseAddr}/api/{Version}/categories/{id}");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<CategoryDto>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                CategoryErrorModel resultError = JsonConvert.DeserializeObject<CategoryErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<int> GetTotalCategoryCount()
        {
            int result = 0;

            var client = new RestClient($"{BaseAddr}/api/{Version}/categories/count-total");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                CategoryErrorModel resultError = JsonConvert.DeserializeObject<CategoryErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public Task<CategoryDto> CreateCategory(CategoryForCreationDto categoryToBeCreated)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryDto> UpdateCategory(Guid categoryIdToBeUpdated,
            CategoryForModificationDto categoryToBeUpdated)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryDto> DeleteCategory(Guid categoryIdToBeDeleted)
        {
            throw new System.NotImplementedException();
        }
    }
}