using soa.common.infrastructure.Domain;
using soa.qa.model.Tags;

namespace soa.qa.repository.ContractRepositories
{
    public interface ITagRepository : IRepository<Tag, int>
    {
        int FindCountTotals();
        Tag FindTagByNumPlate(string numPlate);
    }
}