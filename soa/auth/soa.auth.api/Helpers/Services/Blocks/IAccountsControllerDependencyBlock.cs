using soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts;

namespace soa.auth.api.Helpers.Services.Blocks
{
    public interface IAccountsControllerDependencyBlock
    {
        ICreateAccountProcessor CreateAccountProcessor { get; }
        IInquiryAccountProcessor InquiryAccountProcessor { get; }
        IInquiryAllAccountsProcessor InquiryAllAccountsProcessor { get; }
    }
}