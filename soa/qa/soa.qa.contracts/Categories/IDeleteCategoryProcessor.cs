using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Categories;

namespace soa.qa.contracts.Categories
{
  public interface IDeleteCategoryProcessor
  {
    Task<CategoryForDeletionUiModel> SoftDeleteCategoryAsync(Guid accountIdToDeleteThisCategory, int categoryToBeDeletedId);
    Task<CategoryForDeletionUiModel> HardDeleteCategoryAsync(int categoryToBeDeletedId);
  }
}