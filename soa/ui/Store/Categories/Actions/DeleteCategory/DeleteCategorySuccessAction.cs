using System;

namespace soa.ui.Store.Categories.Actions.DeleteCategory
{
  public class DeleteCategorySuccessAction
  {
    public int CategoryHaveBeenDeletedId { get; private set; }
    public string CategoryDeletionStatus { get; private set; }

    public DeleteCategorySuccessAction(int categoryHaveBeenDeletedId, string categoryDeletionStatus)
    {
      CategoryHaveBeenDeletedId = categoryHaveBeenDeletedId;
      CategoryDeletionStatus = categoryDeletionStatus;
    }
  }
}