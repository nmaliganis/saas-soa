using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Categories;

namespace soa.contracts.Categories
{
  public interface ICreateCategoryProcessor
  {
    Task<CategoryUiModel> CreateCategoryAsync(CategoryForCreationUiModel newCategoryUiModel);
  }
}