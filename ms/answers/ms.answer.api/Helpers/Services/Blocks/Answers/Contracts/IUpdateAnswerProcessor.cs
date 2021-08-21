using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace ms.answer.api.Helpers.Services.Blocks.Answers.Contracts
{
    public interface IUpdateAnswerProcessor
    {
        Task<AnswerUiModel> UpdateAnswerAsync(int idAnswerToBeUpdated, AnswerForModificationUiModel updatedAnswer);
    }
}
