using ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts;

namespace ms.auth.api.Helpers.Services.Blocks
{
    public interface IAccountsControllerDependencyBlock
    {
        ICreateAccountProcessor CreateAccountProcessor { get; }
        IInquiryAccountProcessor InquiryAccountProcessor { get; }
        IInquiryAllAccountsProcessor InquiryAllAccountsProcessor { get; }
    }
}