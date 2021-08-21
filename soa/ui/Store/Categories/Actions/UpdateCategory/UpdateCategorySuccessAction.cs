using System;

namespace soa.ui.Store.Categories.Actions.UpdateCategory
{
  public class UpdateCategorySuccessAction
  {
    public Guid CategoryHaveBeenUpdateId { get; private set; }
    public string CategoryDeletionStatus { get; private set; }

    public UpdateCategorySuccessAction(Guid categoryHaveBeenUpdateId, string categoryDeletionStatus)
    {
      CategoryHaveBeenUpdateId = categoryHaveBeenUpdateId;
      CategoryDeletionStatus = categoryDeletionStatus;
    }
  }
}