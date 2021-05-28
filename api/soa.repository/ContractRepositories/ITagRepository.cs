using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Tags;

namespace soa.repository.ContractRepositories
{
    public interface ITagRepository : IRepository<Tag, int>
    {
        QueryResult<Tag> FindAllTagsPagedOf(int? pageNum = -1, int? pageSize = -1);
        int FindCountTotals();
        Tag FindTagByNumPlate(string numPlate);
    }
}