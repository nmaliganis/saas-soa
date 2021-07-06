using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Categories;

namespace soa.qa.contracts.Categories
{
    public interface IInquiryCategoryProcessor
    {
        Task<CategoryUiModel> GetCategoryByIdAsync(int id);
        Task<CategoryUiModel> GetCategoryByNameAsync(string name);
    }
}