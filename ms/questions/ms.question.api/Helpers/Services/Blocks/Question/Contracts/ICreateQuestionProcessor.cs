using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace ms.question.api.Helpers.Services.Blocks.Question.Contracts
{
  public interface ICreateQuestionProcessor
  {
    Task<QuestionUiModel> CreateQuestionAsync(QuestionForCreationUiModel newQuestionUiModel);
  }
}