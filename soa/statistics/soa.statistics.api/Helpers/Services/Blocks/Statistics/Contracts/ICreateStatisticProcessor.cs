using System.Threading.Tasks;
using soa.common.dtos.Vms.Statistics;

namespace soa.qa.contracts.Statistics
{
    public interface ICreateStatisticProcessor
    {
        Task<StatisticUiModel> CreateStatisticAsync(StatisticForCreationUiModel newStatisticUiModel);
    }
}