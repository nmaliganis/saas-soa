using soa.common.infrastructure.Domain;
using soa.qa.model.Categories;

namespace soa.qa.repository.ContractRepositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        int FindCountTotals();
        Category FindCategoryByName(string name);
    }
}