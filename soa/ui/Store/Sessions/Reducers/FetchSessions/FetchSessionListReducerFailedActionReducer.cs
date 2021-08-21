using Fluxor;
using smart.charger.webui.Store.Sessions.Actions.FetchSessions;

namespace smart.charger.webui.Store.Sessions.Reducers.FetchSessions
{
  public class FetchSessionListReducerFailedActionReducer : Reducer<SessionState, FetchSessionListFailedAction>
  {
    public override SessionState Reduce(SessionState state, FetchSessionListFailedAction action)
    {
      return new SessionState(
        state.SessionList,
        action.ErrorMessage,
        state.IsLoading,
        state.Session,
        state.SessionToBeCreatedPayload,
        state.SessionToBeUpdatePayload,
        state.SessionId
        );
    }
  }
}