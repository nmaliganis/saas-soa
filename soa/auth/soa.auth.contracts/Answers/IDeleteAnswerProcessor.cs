using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Answers;

namespace soa.contracts.Answers
{
  public interface IDeleteAnswerProcessor
  {
    Task<AnswerForDeletionUiModel> SoftDeleteAnswerAsync(Guid accountIdToDeleteThisAnswer, int answerToBeDeletedId);
    Task<AnswerForDeletionUiModel> HardDeleteAnswerAsync(int answerToBeDeletedId);
  }
}