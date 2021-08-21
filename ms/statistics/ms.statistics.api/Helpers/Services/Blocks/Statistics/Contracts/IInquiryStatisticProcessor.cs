using System.Threading.Tasks;
using soa.common.dtos.Vms.Statistics;

namespace soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts
{
    public interface IInquiryStatisticProcessor
    {
        Task<StatisticUiModel> GetStatisticByIdAsync(int id);
        Task<StatisticUiModel> GetStatisticByTitleAsync(string title);
    }
}