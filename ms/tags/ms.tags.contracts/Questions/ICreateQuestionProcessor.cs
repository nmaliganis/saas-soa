using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Questions;

namespace soa.contracts.Questions
{
  public interface ICreateQuestionProcessor
  {
    Task<QuestionUiModel> CreateQuestionAsync(QuestionForCreationUiModel newQuestionUiModel);
  }
}