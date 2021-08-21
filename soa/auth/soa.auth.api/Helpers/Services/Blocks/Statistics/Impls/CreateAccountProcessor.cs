using System.Threading.Tasks;
using soa.auth.api.Helpers.Repositories;
using soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts;
using soa.common.dtos.Vms.Accounts;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace soa.auth.api.Helpers.Services.Blocks.Statistics.Impls
{
    public class CreateAccountProcessor : ICreateAccountProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IAccountRepository _accountRepository;
        private readonly IAutoMapper _autoMapper;

        public CreateAccountProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
            IAccountRepository accountRepository)
        {
            _uOf = uOf;
            _accountRepository = accountRepository;
            _autoMapper = autoMapper;
        }

        public Task<AccountUiModel> CreateAccountAsync(AccountForCreationUiModel newAccountUiModel)
        {
            return null;
        }
    }
}