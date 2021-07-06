using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Categories;

namespace soa.repository.ContractRepositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        int FindCountTotals();
        Category FindCategoryByName(string name);
    }
}