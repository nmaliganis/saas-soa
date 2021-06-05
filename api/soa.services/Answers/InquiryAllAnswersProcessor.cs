using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.infrastructure.PropertyMappings;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Answers;
using soa.common.infrastructure.Vms.Persons;
using soa.contracts.Answers;
using soa.repository.ContractRepositories;

namespace soa.services.Answers
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
