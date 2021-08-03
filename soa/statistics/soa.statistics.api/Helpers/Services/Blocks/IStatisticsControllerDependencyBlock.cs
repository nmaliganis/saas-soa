namespace soa.statistics.api.Helpers.Services.Blocks
{
    public interface IStatisticsControllerDependencyBlock
    {
        ICreateStatisticProcessor CreateStatisticProcessor { get; }
        IInquiryStatisticProcessor InquiryStatisticProcessor { get; }
        IUpdateStatisticProcessor UpdateStatisticProcessor { get; }
        IInquiryAllStatisticsProcessor InquiryAllStatisticsProcessor { get; }
        IDeleteStatisticProcessor DeleteStatisticProcessor { get; }
    }
}