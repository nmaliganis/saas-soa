using Fluxor;
using soa.ui.Store.Dashboard.Actions.FetchDashboards;

namespace soa.ui.Store.Dashboard.Reducers.FetchDashboard
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
        action.ChargersInUseCount,
        action.QuestionTodayTotalCount,
        action.QuestionUnansweredTotalCount,
        action.QuestionTotalCount,
        action.AnswerTotalCount
      );
    }
  }
}