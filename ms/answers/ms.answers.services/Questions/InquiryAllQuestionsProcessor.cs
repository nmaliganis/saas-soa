using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Answers;
using soa.common.infrastructure.Vms.Questions;
using soa.contracts.Questions;
using soa.repository.ContractRepositories;

namespace soa.services.Questions
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
