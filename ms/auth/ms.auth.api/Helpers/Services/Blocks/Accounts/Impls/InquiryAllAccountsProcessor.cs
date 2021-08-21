using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms.auth.api.Helpers.Repositories;
using ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts;
using soa.common.dtos.Vms.Accounts;
using soa.common.infrastructure.TypeMappings;

namespace ms.auth.api.Helpers.Services.Blocks.Accounts.Impls
{
    public class InquiryAllAccountsProcessor : IInquiryAllAccountsProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAccountRepository _AccountRepository;

        public InquiryAllAccountsProcessor(IAutoMapper autoMapper, IAccountRepository accountRepository)
        {
            _AccountRepository = accountRepository;
            _autoMapper = autoMapper;
        }

        public Task<List<AccountUiModel>> GetAccountsAsync()
        {
            return Task.Run(() => _AccountRepository.FindAll().Select(x => _autoMapper.Map<AccountUiModel>(x)).ToList());
        }
    }
}