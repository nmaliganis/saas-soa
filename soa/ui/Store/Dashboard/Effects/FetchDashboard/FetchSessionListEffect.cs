using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Chargers;
using smart.charger.webui.Services.Contracts.Sessions;
using smart.charger.webui.Store.Dashboard.Actions.FetchDashboards;

namespace smart.charger.webui.Store.Dashboard.Effects.FetchDashboard
{
  public class FetchDashboardEffect : Effect<FetchDashboardAction>
  {
    public IChargerDataService ChargerDataService { get; set; }
    public ISessionDataService SessionDataService { get; set; }
    public FetchDashboardEffect(IChargerDataService chargerDataService, ISessionDataService sessionDataService)
    {
      ChargerDataService = chargerDataService;
      SessionDataService = sessionDataService;
    }

    public override async Task HandleAsync(FetchDashboardAction action, IDispatcher dispatcher)
    {
      try
      {
        var availableChargersCount = await ChargerDataService.FetchAvailableChargersCount(action.Auth);
        var chargersInUseCount = await ChargerDataService.FetchChargersInUseCount(action.Auth);

        var finishedSessionCount = await SessionDataService.FetchFinishedSessionCount(action.Auth);
        var activeSessionCount = await SessionDataService.FetchActiveSessionCount(action.Auth);

        dispatcher.Dispatch(new FetchDashboardSuccessAction(finishedSessionCount, activeSessionCount, availableChargersCount, chargersInUseCount));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchDashboardFailedAction(e.Message));
      }      
    }
  }
}