using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Tags;

namespace soa.contracts.Tags
{
    public interface IInquiryTagProcessor
    {
        Task<TagUiModel> GetTagByIdAsync(int id);
        Task<TagUiModel> GetTagByTitleAsync(string title);
    }
}