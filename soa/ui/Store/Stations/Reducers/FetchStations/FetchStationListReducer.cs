using Fluxor;
using smart.charger.webui.Store.Stations.Actions.FetchStation;

namespace smart.charger.webui.Store.Stations.Reducers.FetchStations
{
  public class FetchStationListReducer : Reducer<StationState, FetchStationListAction>
  {
    public override StationState Reduce(StationState state, FetchStationListAction action)
    {
      return new StationState(
        state.StationList,
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