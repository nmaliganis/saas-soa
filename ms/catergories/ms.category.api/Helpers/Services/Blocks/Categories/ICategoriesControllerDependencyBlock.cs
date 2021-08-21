using ms.category.api.Helpers.Services.Blocks.Categories.Contracts;

namespace ms.category.api.Helpers.Services.Blocks.Categories
{
  public interface ICategoriesControllerDependencyBlock
  {
    ICreateCategoryProcessor CreateCategoryProcessor { get; }
    IInquiryCategoryProcessor InquiryCategoryProcessor { get; }
    IUpdateCategoryProcessor UpdateCategoryProcessor { get; }
    IInquiryAllCategoriesProcessor InquiryAllCategoriesProcessor { get; }
    IDeleteCategoryProcessor DeleteCategoryProcessor { get; }
  }
}