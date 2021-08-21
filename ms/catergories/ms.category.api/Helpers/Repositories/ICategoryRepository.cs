using ms.category.api.Helpers.Models;
using soa.common.infrastructure.Domain;
using soa.qa.model.Categories;

namespace ms.category.api.Helpers.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        int FindCountTotals();
        Category FindCategoryByName(string name);
    }
}