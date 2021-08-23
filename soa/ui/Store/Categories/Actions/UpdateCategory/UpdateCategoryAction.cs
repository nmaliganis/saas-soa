using System;
using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories.Actions.UpdateCategory
{
  public class UpdateCategoryAction
  {
    public int CategoryToBeUpdateId { get; private set; }
    public CategoryForModificationDto CategoryForModification { get; private set; }

    public UpdateCategoryAction(int categoryToBeUpdateId, CategoryForModificationDto categoryForModification)
    {
        CategoryToBeUpdateId = categoryToBeUpdateId;
        CategoryForModification = categoryForModification;
    }
  }
}