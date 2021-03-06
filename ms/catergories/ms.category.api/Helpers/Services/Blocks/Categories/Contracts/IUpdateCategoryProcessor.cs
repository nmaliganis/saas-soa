using System.Threading.Tasks;
using soa.common.dtos.Vms.Categories;

namespace ms.category.api.Helpers.Services.Blocks.Categories.Contracts
{
    public interface IUpdateCategoryProcessor
    {
        Task<CategoryUiModel> UpdateCategoryAsync(int idCategoryToBeUpdated, CategoryForModificationUiModel updatedCategory);
    }
}
