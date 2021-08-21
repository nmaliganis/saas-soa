using ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts;

namespace ms.auth.api.Helpers.Services.Blocks
{
    public class AccountsControllerDependencyBlock : IAccountsControllerDependencyBlock
    {
        public AccountsControllerDependencyBlock(ICreateAccountProcessor createAccountProcessor,
            IInquiryAccountProcessor inquiryAccountProcessor,
            IInquiryAllAccountsProcessor allAccountProcessor)

        {
            CreateAccountProcessor = createAccountProcessor;
            InquiryAccountProcessor = inquiryAccountProcessor;
            InquiryAllAccountsProcessor = allAccountProcessor;
        }

        public ICreateAccountProcessor CreateAccountProcessor { get; private set; }
        public IInquiryAccountProcessor InquiryAccountProcessor { get; private set; }
        public IInquiryAllAccountsProcessor InquiryAllAccountsProcessor { get; private set; }
    }
}