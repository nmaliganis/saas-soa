using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Categories;

namespace soa.contracts.Categories
{
    public interface IUpdateCategoryProcessor
    {
        Task<CategoryUiModel> UpdateCategoryAsync(int idCategoryToBeUpdated, CategoryForModificationUiModel updatedCategory);
    }
}
