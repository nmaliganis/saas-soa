using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Categories;

namespace soa.contracts.Categories
{
    public interface IInquiryCategoryProcessor
    {
        Task<CategoryUiModel> GetCategoryByIdAsync(int id);
        Task<CategoryUiModel> GetCategoryByNameAsync(string name);
    }
}