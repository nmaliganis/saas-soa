using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories.Actions.CreateCategory
{
  public class CreateCategorySuccessAction
  {
    public CategoryDto CategoryHaveBeenCreated { get; private set; }

    public CreateCategorySuccessAction(CategoryDto categoryHaveBeenCreated)
    {
      CategoryHaveBeenCreated = categoryHaveBeenCreated;
    }
  }
}