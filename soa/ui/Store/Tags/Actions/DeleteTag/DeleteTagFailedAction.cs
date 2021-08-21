namespace soa.ui.Store.Tags.Actions.DeleteTag
{
  public class DeleteTagFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteTagFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}