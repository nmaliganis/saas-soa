using System;
using System.Threading.Tasks;
using ms.tag.api.Helpers.Repositories;
using ms.tag.api.Helpers.Services.Blocks.Tags.Contracts;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.TypeMappings;

namespace ms.tag.api.Helpers.Services.Blocks.Tags.Impls
{
  public class InquiryTagProcessor : IInquiryTagProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ITagRepository _tagRepository;

    public InquiryTagProcessor(IAutoMapper autoMapper,
      ITagRepository tagRepository)
    {
      _autoMapper = autoMapper;
      _tagRepository = tagRepository;
    }


    public Task<int> GetTagCountTotalsAsync()
    {
      return Task.Run(() => _tagRepository.FindCountTotals());
    }

    public Task<TagUiModel> GetTagByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<TagUiModel> GetTagByTitleAsync(string title)
    {
      throw new NotImplementedException();
    }
  }
}
