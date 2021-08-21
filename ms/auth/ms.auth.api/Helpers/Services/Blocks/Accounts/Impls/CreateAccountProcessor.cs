using System.Threading.Tasks;
using ms.auth.api.Helpers.Repositories;
using ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts;
using soa.common.dtos.Vms.Accounts;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace ms.auth.api.Helpers.Services.Blocks.Accounts.Impls
{
    public class CreateAccountProcessor : ICreateAccountProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IAccountRepository _AccountRepository;
        private readonly IAutoMapper _autoMapper;

        public CreateAccountProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
            IAccountRepository accountRepository)
        {
            _uOf = uOf;
            _AccountRepository = accountRepository;
            _autoMapper = autoMapper;
        }

        public Task<AccountUiModel> CreateAccountAsync(AccountForCreationUiModel newAccountUiModel)
        {
            return null;
        }
    }
}