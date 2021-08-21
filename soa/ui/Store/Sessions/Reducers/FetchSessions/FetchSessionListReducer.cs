using Fluxor;
using smart.charger.webui.Store.Sessions.Actions.FetchSessions;

namespace smart.charger.webui.Store.Sessions.Reducers.FetchSessions
{
  public class FetchSessionListReducer : Reducer<SessionState, FetchSessionListAction>
  {
    public override SessionState Reduce(SessionState state, FetchSessionListAction action)
    {
      return new SessionState(
        state.SessionList,
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