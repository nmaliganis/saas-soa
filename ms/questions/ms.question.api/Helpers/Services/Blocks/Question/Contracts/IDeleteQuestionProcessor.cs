using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace ms.question.api.Helpers.Services.Blocks.Question.Contracts
{
  public interface IDeleteQuestionProcessor
  {
    Task<QuestionForDeletionUiModel> SoftDeleteQuestionAsync(Guid accountIdToDeleteThisQuestion, int questionToBeDeletedId);
    Task<QuestionForDeletionUiModel> HardDeleteQuestionAsync(int questionToBeDeletedId);
  }
}