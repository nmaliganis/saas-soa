using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace ms.answer.api.Helpers.Services.Blocks.Answers.Contracts
{
  public interface IDeleteAnswerProcessor
  {
    Task<AnswerForDeletionUiModel> SoftDeleteAnswerAsync(Guid accountIdToDeleteThisAnswer, int answerToBeDeletedId);
    Task<AnswerForDeletionUiModel> HardDeleteAnswerAsync(int answerToBeDeletedId);
  }
}