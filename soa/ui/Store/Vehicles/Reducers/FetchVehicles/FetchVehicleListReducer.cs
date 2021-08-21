using Fluxor;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicles;
using soa.ui.Store.Vehicles;

namespace smart.charger.webui.Store.Vehicles.Reducers.FetchVehicles
{
  public class FetchVehicleListReducer : Reducer<VehicleState, FetchVehicleListAction>
  {
    public override VehicleState Reduce(VehicleState state, FetchVehicleListAction action)
    {
      return new VehicleState(
        state.VehicleList,
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