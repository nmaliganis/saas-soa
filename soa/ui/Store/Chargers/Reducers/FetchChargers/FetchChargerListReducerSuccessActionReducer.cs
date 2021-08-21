using Fluxor;
using smart.charger.webui.Store.Chargers.Actions.FetchCharger;

namespace smart.charger.webui.Store.Chargers.Reducers.FetchChargers
{
  public class FetchChargerListReducerSuccessActionReducer : Reducer<ChargerState, FetchChargerListSuccessAction>
  {
    public override ChargerState Reduce(ChargerState state, FetchChargerListSuccessAction action)
    {
      return new ChargerState(
        action.ChargerList,
        "",
        state.IsLoading,
        state.Charger,
        state.ChargerToBeCreatedPayload,
        state.ChargerToBeUpdatePayload,
        state.ChargerId
      );
    }
  }
}