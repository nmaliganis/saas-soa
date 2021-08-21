using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Answers;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Answers
{
  public class CreateAnswerProcessor : ICreateAnswerProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IAnswerRepository _answerRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateAnswerProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      IAnswerRepository answerRepository)
    {
      _uOf = uOf;
      _answerRepository = answerRepository;
      _autoMapper = autoMapper;
    }

    public Task<AnswerUiModel> CreateAnswerAsync(AnswerForCreationUiModel newAnswerUiModel)
    {
      return null;
    }
  }
}
