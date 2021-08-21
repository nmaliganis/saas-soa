using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace ms.question.api.Helpers.Services.Blocks.Question.Contracts
{
    public interface IInquiryQuestionProcessor
    {
        Task<QuestionUiModel> GetQuestionByIdAsync(int id);
        Task<QuestionUiModel> GetQuestionByTitleAsync(string title);
    }
}