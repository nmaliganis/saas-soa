using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Stations;
using smart.charger.webui.Store.Stations.Actions.FetchStation;

namespace smart.charger.webui.Store.Stations.Effects.FetchVehicles
{
  public class FetchStationListEffect : Effect<FetchStationListAction>
  {
    public IStationDataService StationDataService { get; set; }
    public FetchStationListEffect(IStationDataService stationDataService)
    {
      StationDataService = stationDataService;
    }

    public override async Task HandleAsync(FetchStationListAction action, IDispatcher dispatcher)
    {
      try
      {
        var stations = await StationDataService.GetStationList(action.Auth);
        dispatcher.Dispatch(new FetchStationListSuccessAction(stations));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchStationListFailedAction(e.Message));
      }      
    }
  }
}