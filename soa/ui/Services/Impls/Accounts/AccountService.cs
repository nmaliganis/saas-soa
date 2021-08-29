using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using smart.charger.webui.Models.DTOs.Account;
using smart.charger.webui.Services.Base;
using smart.charger.webui.Services.Contracts.Accounts;
using soa.ui.Models.DTOs.Account;

namespace smart.charger.webui.Services.Impls.Accounts
{
  public class AccountService : IAccountService
  {
    private readonly HttpClient _httpClient;
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public AccountService(IConfiguration configuration, HttpClient httpClient)
    {
      Configuration = configuration;
      _httpClient = httpClient;
      OnCreated();
    }
    private void OnCreated()
    {
      BaseAddr = Configuration["env"] == "prod" ? Configuration["RemoteUrl"] : Configuration["LocalUrl"];
    }


    public async Task<AuthDto> TryToLogin(LoginDto login)
    {
      AuthDto result = new AuthDto();

      var client = new RestClient($"{BaseAddr}/api/Users/login");
      var request = new RestRequest(Method.POST);
      request.AddJsonBody(login);
      request.AddHeader("Content-Type", "application/json");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<AuthDto>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        LoginErrorModel resultError = JsonConvert.DeserializeObject<LoginErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }

      return result;
    }
  }
}