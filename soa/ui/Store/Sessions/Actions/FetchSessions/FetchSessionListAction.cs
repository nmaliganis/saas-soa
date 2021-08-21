namespace smart.charger.webui.Store.Sessions.Actions.FetchSessions
{
  public class FetchSessionListAction
  {
    public string Auth { get; }

    public FetchSessionListAction(string auth)
    {
      Auth = auth;
    }
  }
}