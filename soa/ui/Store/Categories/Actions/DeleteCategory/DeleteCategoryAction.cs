using System;

namespace soa.ui.Store.Categories.Actions.DeleteCategory
{
  public class DeleteCategoryAction
  {
    public Guid CategoryToBeDeletedId { get; private set; }

    public DeleteCategoryAction(Guid categoryToBeDeletedId)
    {
      CategoryToBeDeletedId = categoryToBeDeletedId;
    }
  }
}