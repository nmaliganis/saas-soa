using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;
using soa.common.infrastructure.TypeMappings;
using soa.qa.contracts.Questions;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Questions
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
