using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Tags;

namespace soa.contracts.Tags
{
    public interface IInquiryAllTagsProcessor
    {
      Task<List<TagUiModel>> GetTagsAsync();
    }
}