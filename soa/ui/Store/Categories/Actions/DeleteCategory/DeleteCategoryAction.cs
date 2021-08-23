using System;

namespace soa.ui.Store.Categories.Actions.DeleteCategory
{
  public class DeleteCategoryAction
  {
    public int CategoryToBeDeletedId { get; private set; }

    public DeleteCategoryAction(int categoryToBeDeletedId)
    {
      CategoryToBeDeletedId = categoryToBeDeletedId;
    }
  }
}