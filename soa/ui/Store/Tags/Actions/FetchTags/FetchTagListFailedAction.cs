namespace soa.ui.Store.Tags.Actions.FetchTags
{
  public class FetchTagListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchTagListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}