using System.Threading.Tasks;
using soa.common.dtos.Vms.Accounts;

namespace ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts
{
    public interface IInquiryAccountProcessor
    {
        Task<AccountUiModel> GetAccountByIdAsync(int id);
        Task<AccountUiModel> GetAccountByTitleAsync(string title);
    }
}