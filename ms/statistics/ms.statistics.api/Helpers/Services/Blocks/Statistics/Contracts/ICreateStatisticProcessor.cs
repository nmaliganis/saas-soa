using System.Threading.Tasks;
using soa.common.dtos.Vms.Statistics;

namespace soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts
{
    public interface ICreateStatisticProcessor
    {
        Task<StatisticUiModel> CreateStatisticAsync(StatisticForCreationUiModel newStatisticUiModel);
    }
}