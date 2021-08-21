using System;
using System.Threading.Tasks;
using ms.auth.api.Helpers.Repositories;
using ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts;
using soa.common.dtos.Vms.Accounts;
using soa.common.infrastructure.TypeMappings;

namespace ms.auth.api.Helpers.Services.Blocks.Accounts.Impls
{
    public class InquiryAccountProcessor : IInquiryAccountProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAccountRepository _accountRepository;

        public InquiryAccountProcessor(IAutoMapper autoMapper,
            IAccountRepository AccountRepository)
        {
            _autoMapper = autoMapper;
            _accountRepository = AccountRepository;
        }

        public Task<AccountUiModel> GetAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountUiModel> GetAccountByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }
    }
}