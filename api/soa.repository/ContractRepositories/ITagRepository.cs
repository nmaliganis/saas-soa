using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Tags;

namespace soa.repository.ContractRepositories
{
    public interface ITagRepository : IRepository<Tag, int>
    {
        int FindCountTotals();
        Tag FindTagByNumPlate(string numPlate);
    }
}