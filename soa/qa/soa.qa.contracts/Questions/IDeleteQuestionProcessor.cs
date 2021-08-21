using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace soa.qa.contracts.Questions
{
  public interface IDeleteQuestionProcessor
  {
    Task<QuestionForDeletionUiModel> SoftDeleteQuestionAsync(Guid accountIdToDeleteThisQuestion, int questionToBeDeletedId);
    Task<QuestionForDeletionUiModel> HardDeleteQuestionAsync(int questionToBeDeletedId);
  }
}