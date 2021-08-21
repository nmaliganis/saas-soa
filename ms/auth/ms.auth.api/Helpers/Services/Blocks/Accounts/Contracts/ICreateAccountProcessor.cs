using System.Threading.Tasks;
using soa.common.dtos.Vms.Accounts;

namespace ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts
{
    public interface ICreateAccountProcessor
    {
        Task<AccountUiModel> CreateAccountAsync(AccountForCreationUiModel newAccountUiModel);
    }
}