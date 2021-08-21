using System.Net.Http;
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using smart.charger.webui.DataRetrieval;
using smart.charger.webui.Services.Contracts.Accounts;
using smart.charger.webui.Services.Contracts.Chargers;
using smart.charger.webui.Services.Contracts.Sessions;
using smart.charger.webui.Services.Contracts.Stations;
using smart.charger.webui.Services.Contracts.Vehicles;
using smart.charger.webui.Services.Impls.Accounts;
using smart.charger.webui.Services.Impls.Chargers;
using smart.charger.webui.Services.Impls.Sessions;
using smart.charger.webui.Services.Impls.Stations;
using smart.charger.webui.Services.Impls.Vehicles;
using Syncfusion.Blazor;
using Westwind.AspNetCore.LiveReload;

namespace smart.charger.webui
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      services.AddServerSideBlazor();
      services.AddSingleton<IssuesGenerator>();
      services.AddTelerikBlazor();
      services.AddSyncfusionBlazor();

      services.AddLiveReload(config =>
      {
        config.LiveReloadEnabled = true;
        config.ClientFileExtensions = ".css,.js,.htm,.html";
        config.FolderToMonitor = "~/../";
      });

      services.AddFluxor(options =>
      {
        options.ScanAssemblies(typeof(Startup).Assembly);
        options.UseRouting();
      });

      services.AddBlazoredLocalStorage();
      services.AddBlazoredLocalStorage(config =>
        config.JsonSerializerOptions.WriteIndented = true);

      services.AddScoped<HttpClient>(s =>
      {
        var remoteUrl = Configuration["env"] == "prod" ? Configuration["RemoteUrl"] : Configuration["LocalUrl"];
        var client = new HttpClient {BaseAddress = new System.Uri(remoteUrl)};
        return client;
      });

      services.AddScoped<IChargerDataService, ChargerDataService>();
      services.AddScoped<IVehicleDataService, VehicleDataService>();
      services.AddScoped<ISessionDataService, SessionDataService>();
      services.AddScoped<IStationDataService, StationDataService>();
      services.AddScoped<IAccountService, AccountService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
      });
    }
  }
}
