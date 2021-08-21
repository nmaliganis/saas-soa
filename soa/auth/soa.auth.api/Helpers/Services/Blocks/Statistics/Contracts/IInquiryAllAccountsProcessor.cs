using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Accounts;

namespace soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts
{
    public interface IInquiryAllAccountsProcessor
    {
        Task<List<AccountUiModel>> GetAccountsAsync();
    }
}