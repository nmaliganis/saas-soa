namespace soa.ui.Store.Categories.Actions.FetchCategories
{
  public class FetchCategoryListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchCategoryListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}