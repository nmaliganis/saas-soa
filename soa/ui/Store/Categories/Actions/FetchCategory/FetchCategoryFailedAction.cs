namespace soa.ui.Store.Categories.Actions.FetchCategory
{
  public class FetchCategoryFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchCategoryFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}