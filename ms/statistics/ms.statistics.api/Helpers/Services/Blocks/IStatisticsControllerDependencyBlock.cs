using soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts;

namespace soa.statistics.api.Helpers.Services.Blocks
{
    public interface IStatisticsControllerDependencyBlock
    {
        ICreateStatisticProcessor CreateStatisticProcessor { get; }
        IInquiryStatisticProcessor InquiryStatisticProcessor { get; }
        IInquiryAllStatisticsProcessor InquiryAllStatisticsProcessor { get; }
    }
}