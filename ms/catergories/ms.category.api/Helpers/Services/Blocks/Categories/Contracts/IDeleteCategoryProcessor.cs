using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Categories;

namespace ms.category.api.Helpers.Services.Blocks.Categories.Contracts
{
  public interface IDeleteCategoryProcessor
  {
    Task<CategoryForDeletionUiModel> SoftDeleteCategoryAsync(Guid accountIdToDeleteThisCategory, int categoryToBeDeletedId);
    Task<CategoryForDeletionUiModel> HardDeleteCategoryAsync(int categoryToBeDeletedId);
  }
}