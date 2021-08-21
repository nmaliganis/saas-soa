namespace soa.ui.Store.Categories.Actions.CreateCategory
{
  public class CreateCategoryFailedAction
  {
    public string ErrorMessage { get; private set; }
    public string ErrorContent { get; private set; }
    public CreateCategoryFailedAction(string errorMessage, string errorContent)
    {
      ErrorMessage = errorMessage;
      ErrorContent = errorContent;
    }
  }
}