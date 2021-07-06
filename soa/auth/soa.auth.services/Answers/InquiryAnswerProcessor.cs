using System;
using System.Threading.Tasks;
using soa.common.infrastructure.PropertyMappings;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Answers;
using soa.contracts.Answers;
using soa.repository.ContractRepositories;

namespace soa.services.Answers
{
  public class InquiryAnswerProcessor : IInquiryAnswerProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IAnswerRepository _answerRepository;

    public InquiryAnswerProcessor(IAutoMapper autoMapper,
      IAnswerRepository answerRepository)
    {
      _autoMapper = autoMapper;
      _answerRepository = answerRepository;
    }


    public Task<int> GetAnswerCountTotalsAsync()
    {
      return Task.Run(() => _answerRepository.FindCountTotals());
    }

    public Task<AnswerUiModel> GetAnswerByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<AnswerUiModel> GetAnswerByTitleAsync(string title)
    {
      throw new NotImplementedException();
    }
  }
}
