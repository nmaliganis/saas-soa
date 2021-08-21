using Fluxor;
using smart.charger.webui.Store.Dashboard.Actions.FetchDashboards;

namespace smart.charger.webui.Store.Dashboard.Reducers.FetchDashboard
{
  public class FetchDashboardReducerFailedActionReducer : Reducer<DashboardState, FetchDashboardFailedAction>
  {
    public override DashboardState Reduce(DashboardState state, FetchDashboardFailedAction action)
    {
      return new DashboardState(
        action.ErrorMessage,
        state.FinishedSessionCount,
        state.ActiveSessionCount,
        state.AvailableChargersCount,
        state.ChargersInUseCount
        );
    }
  }
}