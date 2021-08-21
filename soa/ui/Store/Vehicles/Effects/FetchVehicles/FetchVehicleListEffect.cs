using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Vehicles;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicles;

namespace smart.charger.webui.Store.Vehicles.Effects.FetchVehicles
{
  public class FetchVehicleListEffect : Effect<FetchVehicleListAction>
  {
    public IVehicleDataService VehicleDataService { get; set; }
    public FetchVehicleListEffect(IVehicleDataService vehicleDataService)
    {
      VehicleDataService = vehicleDataService;
    }

    public override async Task HandleAsync(FetchVehicleListAction action, IDispatcher dispatcher)
    {
      try
      {
        var vehicles = await VehicleDataService.GetVehicleList(action.Auth);
        dispatcher.Dispatch(new FetchVehicleListSuccessAction(vehicles));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchVehicleListFailedAction(e.Message));
      }      
    }
  }
}