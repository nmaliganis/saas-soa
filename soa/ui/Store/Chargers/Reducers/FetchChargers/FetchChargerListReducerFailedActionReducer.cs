using Fluxor;
using smart.charger.webui.Store.Chargers.Actions.FetchCharger;

namespace smart.charger.webui.Store.Chargers.Reducers.FetchChargers
{
  public class FetchChargerListReducerFailedActionReducer : Reducer<ChargerState, FetchChargerListFailedAction>
  {
    public override ChargerState Reduce(ChargerState state, FetchChargerListFailedAction action)
    {
      return new ChargerState(
        state.ChargerList,
        action.ErrorMessage,
        state.IsLoading,
        state.Charger,
        state.ChargerToBeCreatedPayload,
        state.ChargerToBeUpdatePayload,
        state.ChargerId
        );
    }
  }
}