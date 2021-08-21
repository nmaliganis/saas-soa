using Fluxor;
using smart.charger.webui.Store.Stations.Actions.FetchStation;

namespace smart.charger.webui.Store.Stations.Reducers.FetchStations
{
  public class FetchStationListReducerFailedActionReducer : Reducer<StationState, FetchStationListFailedAction>
  {
    public override StationState Reduce(StationState state, FetchStationListFailedAction action)
    {
      return new StationState(
        state.StationList,
        action.ErrorMessage,
        state.IsLoading,
        state.Station,
        state.StationToBeCreatedPayload,
        state.StationToBeUpdatePayload,
        state.StationId
        );
    }
  }
}