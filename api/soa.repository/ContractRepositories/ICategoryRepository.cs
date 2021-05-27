using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Categories;

namespace soa.repository.ContractRepositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        QueryResult<Category> FindAllCategoriesPagedOf(int? pageNum = -1, int? pageSize = -1);
        int FindCountTotals();
        Category FindCategoryByName(string name);
    }
}