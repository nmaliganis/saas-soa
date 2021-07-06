using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Answers;

namespace soa.contracts.Answers
{
    public interface IUpdateAnswerProcessor
    {
        Task<AnswerUiModel> UpdateAnswerAsync(int idAnswerToBeUpdated, AnswerForModificationUiModel updatedAnswer);
    }
}
