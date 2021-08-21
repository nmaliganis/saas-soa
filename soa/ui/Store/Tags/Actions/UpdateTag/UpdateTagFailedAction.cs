namespace soa.ui.Store.Tags.Actions.UpdateTag
{
  public class UpdateTagFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateTagFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}