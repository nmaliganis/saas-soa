using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace ms.question.api.Helpers.Services.Blocks.Question.Contracts
{
    public interface IUpdateQuestionProcessor
    {
        Task<QuestionUiModel> UpdateQuestionAsync(int idQuestionToBeUpdated, QuestionForModificationUiModel updatedQuestion);
    }
}
