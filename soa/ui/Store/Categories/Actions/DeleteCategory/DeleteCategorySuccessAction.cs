using System;

namespace soa.ui.Store.Categories.Actions.DeleteCategory
{
  public class DeleteCategorySuccessAction
  {
    public Guid CategoryHaveBeenDeletedId { get; private set; }
    public string CategoryDeletionStatus { get; private set; }

    public DeleteCategorySuccessAction(Guid categoryHaveBeenDeletedId, string categoryDeletionStatus)
    {
      CategoryHaveBeenDeletedId = categoryHaveBeenDeletedId;
      CategoryDeletionStatus = categoryDeletionStatus;
    }
  }
}