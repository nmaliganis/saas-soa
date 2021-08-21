using System;
using System.Threading.Tasks;
using soa.auth.api.Helpers.Repositories;
using soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts;
using soa.common.dtos.Vms.Accounts;
using soa.common.infrastructure.TypeMappings;

namespace soa.auth.api.Helpers.Services.Blocks.Statistics.Impls
{
    public class InquiryAccountProcessor : IInquiryAccountProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAccountRepository _accountRepository;

        public InquiryAccountProcessor(IAutoMapper autoMapper,
            IAccountRepository accountRepository)
        {
            _autoMapper = autoMapper;
            _accountRepository = accountRepository;
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