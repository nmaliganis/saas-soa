using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.TypeMappings;
using soa.qa.contracts.Tags;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Tags
{
  public class InquiryAllTagsProcessor : IInquiryAllTagsProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ITagRepository _tagRepository;

    public InquiryAllTagsProcessor(IAutoMapper autoMapper, ITagRepository tagRepository)
    {
      _tagRepository = tagRepository;
      _autoMapper = autoMapper;
    }

    public Task<List<TagUiModel>> GetTagsAsync()
    {
      return Task.Run(() => _tagRepository.FindAll().Select(x => _autoMapper.Map<TagUiModel>(x)).ToList());
    }
  }
}
