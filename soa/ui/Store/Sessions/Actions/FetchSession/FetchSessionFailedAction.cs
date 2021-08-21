namespace smart.charger.webui.Store.Sessions.Actions.FetchSession
{
  public class FetchSessionFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchSessionFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}