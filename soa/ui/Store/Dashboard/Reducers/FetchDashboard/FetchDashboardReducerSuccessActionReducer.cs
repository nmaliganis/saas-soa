using Fluxor;
using smart.charger.webui.Store.Dashboard.Actions.FetchDashboards;

namespace smart.charger.webui.Store.Dashboard.Reducers.FetchDashboard
{
  public class FetchDashboardReducerSuccessActionReducer : Reducer<DashboardState, FetchDashboardSuccessAction>
  {
    public override DashboardState Reduce(DashboardState state, FetchDashboardSuccessAction action)
    {
      return new DashboardState(
        "",
        action.FinishedSessionCount,
        action.ActiveSessionCount,
        action.AvailableChargersCount,
        action.ChargersInUseCount
      );
    }
  }
}