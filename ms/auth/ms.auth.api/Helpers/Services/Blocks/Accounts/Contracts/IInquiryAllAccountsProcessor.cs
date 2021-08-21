using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Accounts;

namespace ms.auth.api.Helpers.Services.Blocks.Accounts.Contracts
{
    public interface IInquiryAllAccountsProcessor
    {
        Task<List<AccountUiModel>> GetAccountsAsync();
    }
}