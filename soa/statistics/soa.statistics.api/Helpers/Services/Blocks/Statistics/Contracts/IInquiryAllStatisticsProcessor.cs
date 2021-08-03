using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Statistics;

namespace soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts
{
    public interface IInquiryAllStatisticsProcessor
    {
        Task<List<StatisticUiModel>> GetStatisticsAsync();
    }
}