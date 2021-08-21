using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories.Actions.FetchCategory
{
  public class FetchCategorySuccessAction
  {
    public CategoryDto CategoryToHaveBeenFetched { get; private set; }

    public FetchCategorySuccessAction(CategoryDto categoryToHaveBeenFetched)
    {
      CategoryToHaveBeenFetched  = categoryToHaveBeenFetched;
    }
  }
}