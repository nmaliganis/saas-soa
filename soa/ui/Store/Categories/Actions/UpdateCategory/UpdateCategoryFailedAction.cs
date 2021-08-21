namespace soa.ui.Store.Categories.Actions.UpdateCategory
{
  public class UpdateCategoryFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateCategoryFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}