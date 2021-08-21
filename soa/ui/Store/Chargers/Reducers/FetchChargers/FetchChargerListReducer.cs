using Fluxor;
using smart.charger.webui.Store.Chargers.Actions.FetchCharger;

namespace smart.charger.webui.Store.Chargers.Reducers.FetchChargers
{
  public class FetchChargerListReducer : Reducer<ChargerState, FetchChargerListAction>
  {
    public override ChargerState Reduce(ChargerState state, FetchChargerListAction action)
    {
      return new ChargerState(
        state.ChargerList,
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