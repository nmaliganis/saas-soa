namespace smart.charger.webui.Store.Sessions.Actions.UpdateSession
{
  public class UpdateSessionFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateSessionFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}