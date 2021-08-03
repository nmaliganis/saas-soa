using System.Threading.Tasks;
using soa.common.dtos.Vms.Categories;

namespace soa.qa.contracts.Categories
{
    public interface IUpdateCategoryProcessor
    {
        Task<CategoryUiModel> UpdateCategoryAsync(int idCategoryToBeUpdated, CategoryForModificationUiModel updatedCategory);
    }
}
