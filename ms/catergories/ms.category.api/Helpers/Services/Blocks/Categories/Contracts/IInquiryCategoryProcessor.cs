using System.Threading.Tasks;
using soa.common.dtos.Vms.Categories;

namespace soa.qa.contracts.Categories
{
    public interface IInquiryCategoryProcessor
    {
        Task<CategoryUiModel> GetCategoryByIdAsync(int id);
        Task<CategoryUiModel> GetCategoryByNameAsync(string name);
    }
}