namespace soa.ui.Store.Tags.Actions.FetchTag
{
  public class FetchTagFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchTagFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}