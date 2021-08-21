using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms.answer.api.Helpers.Repositories;
using ms.answer.api.Helpers.Services.Blocks.Answers.Contracts;
using soa.common.dtos.Vms.Answers;
using soa.common.infrastructure.TypeMappings;

namespace ms.answer.api.Helpers.Services.Blocks.Answers.Impls
{
  public class InquiryAllAnswersProcessor : IInquiryAllAnswersProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IAnswerRepository _answerRepository;

    public InquiryAllAnswersProcessor(IAutoMapper autoMapper, IAnswerRepository answerRepository)
    {
      _answerRepository = answerRepository;
      _autoMapper = autoMapper;
    }

    public Task<List<AnswerUiModel>> GetAnswersAsync()
    {
      return Task.Run(() => _answerRepository.FindAll().Select(x => _autoMapper.Map<AnswerUiModel>(x)).ToList());
    }
  }
}
