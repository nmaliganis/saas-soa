using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace soa.qa.contracts.Questions
{
  public interface ICreateQuestionProcessor
  {
    Task<QuestionUiModel> CreateQuestionAsync(QuestionForCreationUiModel newQuestionUiModel);
  }
}