using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Questions;
using soa.contracts.Questions;
using soa.repository.ContractRepositories;

namespace soa.services.Questions
{
  public class CreateQuestionProcessor : ICreateQuestionProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IQuestionRepository _questionRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateQuestionProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      IQuestionRepository questionRepository)
    {
      _uOf = uOf;
      _questionRepository = questionRepository;
      _autoMapper = autoMapper;
    }

    public Task<QuestionUiModel> CreateQuestionAsync(QuestionForCreationUiModel newQuestionUiModel)
    {
      return null;
    }
  }
}
