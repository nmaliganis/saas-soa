using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Questions;

namespace soa.qa.contracts.Questions
{
  public interface IDeleteQuestionProcessor
  {
    Task<QuestionForDeletionUiModel> SoftDeleteQuestionAsync(Guid accountIdToDeleteThisQuestion, int questionToBeDeletedId);
    Task<QuestionForDeletionUiModel> HardDeleteQuestionAsync(int questionToBeDeletedId);
  }
}