namespace soa.ui.Store.Categories.Actions.DeleteCategory
{
  public class DeleteCategoryFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteCategoryFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}