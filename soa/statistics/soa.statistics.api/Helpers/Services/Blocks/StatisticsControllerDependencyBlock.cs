using soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts;

namespace soa.statistics.api.Helpers.Services.Blocks
{
    public class StatisticsControllerDependencyBlock : IStatisticsControllerDependencyBlock
    {
        public StatisticsControllerDependencyBlock(ICreateStatisticProcessor createStatisticProcessor,
            IInquiryStatisticProcessor inquiryStatisticProcessor,
            IInquiryAllStatisticsProcessor allStatisticProcessor)

        {
            CreateStatisticProcessor = createStatisticProcessor;
            InquiryStatisticProcessor = inquiryStatisticProcessor;
            InquiryAllStatisticsProcessor = allStatisticProcessor;
        }

        public ICreateStatisticProcessor CreateStatisticProcessor { get; private set; }
        public IInquiryStatisticProcessor InquiryStatisticProcessor { get; private set; }
        public IInquiryAllStatisticsProcessor InquiryAllStatisticsProcessor { get; private set; }
    }
}