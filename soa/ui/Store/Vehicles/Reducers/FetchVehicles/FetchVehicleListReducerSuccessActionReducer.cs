using Fluxor;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicle;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicles;
using soa.ui.Store.Vehicles;

namespace smart.charger.webui.Store.Vehicles.Reducers.FetchVehicles
{
  public class FetchVehicleListReducerSuccessActionReducer : Reducer<VehicleState, FetchVehicleListSuccessAction>
  {
    public override VehicleState Reduce(VehicleState state, FetchVehicleListSuccessAction action)
    {
      return new VehicleState(
        action.VehicleList,
        "",
        state.IsLoading,
        state.Vehicle,
        state.VehicleToBeCreatedPayload,
        state.VehicleToBeUpdatePayload,
        state.VehicleId
      );
    }
  }
}