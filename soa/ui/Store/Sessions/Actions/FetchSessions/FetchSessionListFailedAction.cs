namespace smart.charger.webui.Store.Sessions.Actions.FetchSessions
{
  public class FetchSessionListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchSessionListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}