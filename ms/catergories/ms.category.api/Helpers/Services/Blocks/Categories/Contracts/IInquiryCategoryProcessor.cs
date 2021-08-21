using System.Threading.Tasks;
using soa.common.dtos.Vms.Categories;

namespace ms.category.api.Helpers.Services.Blocks.Categories.Contracts
{
    public interface IInquiryCategoryProcessor
    {
        Task<CategoryUiModel> GetCategoryByIdAsync(int id);
        Task<CategoryUiModel> GetCategoryByNameAsync(string name);
    }
}