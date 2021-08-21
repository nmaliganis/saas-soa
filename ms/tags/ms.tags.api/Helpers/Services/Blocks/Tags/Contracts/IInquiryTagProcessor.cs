using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;

namespace ms.tag.api.Helpers.Services.Blocks.Tags.Contracts
{
    public interface IInquiryTagProcessor
    {
        Task<TagUiModel> GetTagByIdAsync(int id);
        Task<TagUiModel> GetTagByTitleAsync(string title);
    }
}