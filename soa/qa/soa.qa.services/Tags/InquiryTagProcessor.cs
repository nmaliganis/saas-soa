using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.TypeMappings;
using soa.qa.contracts.Tags;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Tags
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
