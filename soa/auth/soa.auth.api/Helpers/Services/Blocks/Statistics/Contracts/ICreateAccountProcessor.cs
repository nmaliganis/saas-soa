using System.Threading.Tasks;
using soa.common.dtos.Vms.Accounts;

namespace soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts
{
    public interface ICreateAccountProcessor
    {
        Task<AccountUiModel> CreateAccountAsync(AccountForCreationUiModel newAccountUiModel);
    }
}