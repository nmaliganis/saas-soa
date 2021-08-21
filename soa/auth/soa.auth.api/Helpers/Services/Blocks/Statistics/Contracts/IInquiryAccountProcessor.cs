using System.Threading.Tasks;
using soa.common.dtos.Vms.Accounts;

namespace soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts
{
    public interface IInquiryAccountProcessor
    {
        Task<AccountUiModel> GetAccountByIdAsync(int id);
        Task<AccountUiModel> GetAccountByTitleAsync(string title);
    }
}