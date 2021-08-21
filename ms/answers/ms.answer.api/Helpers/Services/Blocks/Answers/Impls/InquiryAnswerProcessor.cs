using System;
using System.Threading.Tasks;
using ms.answer.api.Helpers.Repositories;
using ms.answer.api.Helpers.Services.Blocks.Answers.Contracts;
using soa.common.dtos.Vms.Answers;
using soa.common.infrastructure.TypeMappings;

namespace ms.answer.api.Helpers.Services.Blocks.Answers.Impls
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
