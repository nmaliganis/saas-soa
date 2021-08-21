using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms.question.api.Helpers.Repositories;
using ms.question.api.Helpers.Services.Blocks.Question.Contracts;
using soa.common.dtos.Vms.Questions;
using soa.common.infrastructure.TypeMappings;

namespace ms.question.api.Helpers.Services.Blocks.Question.Impls
{
  public class InquiryAllQuestionsProcessor : IInquiryAllQuestionsProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IQuestionRepository _questionRepository;

    public InquiryAllQuestionsProcessor(IAutoMapper autoMapper, IQuestionRepository questionRepository)
    {
      _questionRepository = questionRepository;
      _autoMapper = autoMapper;
    }

    public Task<List<QuestionUiModel>> GetQuestionsAsync()
    {
      return Task.Run(() => _questionRepository.FindAll().Select(x => _autoMapper.Map<QuestionUiModel>(x)).ToList());
    }
  }
}
