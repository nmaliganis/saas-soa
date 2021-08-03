using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace soa.qa.contracts.Answers
{
  public interface IDeleteAnswerProcessor
  {
    Task<AnswerForDeletionUiModel> SoftDeleteAnswerAsync(Guid accountIdToDeleteThisAnswer, int answerToBeDeletedId);
    Task<AnswerForDeletionUiModel> HardDeleteAnswerAsync(int answerToBeDeletedId);
  }
}