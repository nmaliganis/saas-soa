using Fluxor;
using smart.charger.webui.Store.Stations.Actions.FetchStation;

namespace smart.charger.webui.Store.Stations.Reducers.FetchStations
{
  public class FetchStationListReducerSuccessActionReducer : Reducer<StationState, FetchStationListSuccessAction>
  {
    public override StationState Reduce(StationState state, FetchStationListSuccessAction action)
    {
      return new StationState(
        action.StationList,
        "",
        state.IsLoading,
        state.Station,
        state.StationToBeCreatedPayload,
        state.StationToBeUpdatePayload,
        state.StationId
      );
    }
  }
}