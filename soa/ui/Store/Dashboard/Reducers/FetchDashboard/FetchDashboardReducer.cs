using Fluxor;
using smart.charger.webui.Store.Dashboard.Actions.FetchDashboards;

namespace smart.charger.webui.Store.Dashboard.Reducers.FetchDashboard
{
  public class FetchDashboardReducer : Reducer<DashboardState, FetchDashboardAction>
  {
    public override DashboardState Reduce(DashboardState state, FetchDashboardAction action)
    {
      return new DashboardState(
        "",
        state.FinishedSessionCount,
        state.ActiveSessionCount,
        state.AvailableChargersCount,
        state.ChargersInUseCount
        );
    }
  }
}