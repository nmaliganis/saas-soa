using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Answers;
using soa.contracts.Answers;
using soa.repository.ContractRepositories;

namespace soa.services.Answers
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
