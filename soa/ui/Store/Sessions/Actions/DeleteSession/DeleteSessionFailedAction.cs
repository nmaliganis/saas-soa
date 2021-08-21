namespace smart.charger.webui.Store.Sessions.Actions.DeleteSession
{
  public class DeleteSessionFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteSessionFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}