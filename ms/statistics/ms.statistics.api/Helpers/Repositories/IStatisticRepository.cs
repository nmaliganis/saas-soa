using soa.common.infrastructure.Domain;
using soa.statistics.api.Helpers.Models;

namespace soa.statistics.api.Helpers.Repositories
{
    public interface IStatisticRepository : IRepository<Statistic, int>
    {
        int FindCounts();
        Statistic FindByBody(string body);
    }
}