using Fluxor;
using smart.charger.webui.Store.Sessions.Actions.FetchSessions;

namespace smart.charger.webui.Store.Sessions.Reducers.FetchSessions
{
  public class FetchSessionListReducerSuccessActionReducer : Reducer<SessionState, FetchSessionListSuccessAction>
  {
    public override SessionState Reduce(SessionState state, FetchSessionListSuccessAction action)
    {
      return new SessionState(
        action.SessionList,
        "",
        state.IsLoading,
        state.Session,
        state.SessionToBeCreatedPayload,
        state.SessionToBeUpdatePayload,
        state.SessionId
      );
    }
  }
}