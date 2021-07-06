using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Tags;
using soa.contracts.Tags;
using soa.repository.ContractRepositories;

namespace soa.services.Tags
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
