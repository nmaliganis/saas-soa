using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Questions;

namespace soa.contracts.Questions
{
    public interface IUpdateQuestionProcessor
    {
        Task<QuestionUiModel> UpdateQuestionAsync(Guid idQuestionToBeUpdated, QuestionForModificationUiModel updatedQuestion);
    }
}
