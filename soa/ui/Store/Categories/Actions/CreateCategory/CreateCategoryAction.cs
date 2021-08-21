using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories.Actions.CreateCategory
{
  public class CreateCategoryAction
  {
    public CreateCategoryAction(CategoryForCreationDto categoryToBeCreatedPayload)
    {
      CategoryToBeCreatedPayload = categoryToBeCreatedPayload;
    }

    public CategoryForCreationDto CategoryToBeCreatedPayload { get; private set; }
  }
}