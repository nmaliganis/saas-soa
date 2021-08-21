using System;

namespace soa.ui.Store.Categories.Actions.UpdateCategory
{
  public class UpdateCategoryAction
  {
    public Guid CategoryToBeUpdateId { get; private set; }

    public UpdateCategoryAction(Guid categoryToBeUpdateId)
    {
      CategoryToBeUpdateId = categoryToBeUpdateId;
    }
  }
}