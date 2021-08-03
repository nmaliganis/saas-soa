using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;
using soa.common.infrastructure.TypeMappings;
using soa.qa.contracts.Answers;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Answers
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
