using soa.common.infrastructure.Domain;
using soa.qa.model.Tags;
using soa.statistics.api.Helpers.Models;
using Tag = soa.statistics.api.Helpers.Models.Tag;

namespace soa.statistics.api.Helpers.Repositories
{
    public interface IStatisticRepository : IRepository<Statistic, int>
    {
        int FindCountTotals();
        Tag FindTagByNumPlate(string numPlate);
    }
}