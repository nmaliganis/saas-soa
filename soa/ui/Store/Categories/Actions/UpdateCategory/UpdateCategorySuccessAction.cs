using System;
using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories.Actions.UpdateCategory
{
  public class UpdateCategorySuccessAction
  {
    public int CategoryHaveBeenUpdateId { get; private set; }
    public CategoryDto CategoryModification { get; private set; }

    public UpdateCategorySuccessAction(int categoryHaveBeenUpdateId, CategoryDto categoryModification)
    {
      CategoryHaveBeenUpdateId = categoryHaveBeenUpdateId;
      CategoryModification = categoryModification;
    }
  }
}