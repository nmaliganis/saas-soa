using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace soa.qa.contracts.Answers
{
    public interface IUpdateAnswerProcessor
    {
        Task<AnswerUiModel> UpdateAnswerAsync(int idAnswerToBeUpdated, AnswerForModificationUiModel updatedAnswer);
    }
}
