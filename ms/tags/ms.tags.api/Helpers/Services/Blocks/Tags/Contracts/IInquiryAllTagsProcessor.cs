using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;

namespace soa.qa.contracts.Tags
{
    public interface IInquiryAllTagsProcessor
    {
      Task<List<TagUiModel>> GetTagsAsync();
    }
}