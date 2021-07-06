using System.Threading.Tasks;
using soa.common.dtos.Vms.Categories;

namespace soa.qa.contracts.Categories
{
  public interface ICreateCategoryProcessor
  {
    Task<CategoryUiModel> CreateCategoryAsync(CategoryForCreationUiModel newCategoryUiModel);
  }
}