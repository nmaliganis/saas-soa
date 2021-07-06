using soa.contracts.Categories;

namespace soa.contracts.V1
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