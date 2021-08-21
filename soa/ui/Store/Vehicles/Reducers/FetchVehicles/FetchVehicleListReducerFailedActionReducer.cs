using Fluxor;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicle;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicles;

namespace smart.charger.webui.Store.Vehicles.Reducers.FetchVehicles
{
  public class FetchVehicleListReducerFailedActionReducer : Reducer<VehicleState, FetchVehicleListFailedAction>
  {
    public override VehicleState Reduce(VehicleState state, FetchVehicleListFailedAction action)
    {
      return new VehicleState(
        state.VehicleList,
        action.ErrorMessage,
        state.IsLoading,
        state.Vehicle,
        state.VehicleToBeCreatedPayload,
        state.VehicleToBeUpdatePayload,
        state.VehicleId
        );
    }
  }
}