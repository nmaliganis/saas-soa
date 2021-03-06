using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace soa.qa.contracts.Questions
{
    public interface IInquiryQuestionProcessor
    {
        Task<QuestionUiModel> GetQuestionByIdAsync(int id);
        Task<QuestionUiModel> GetQuestionByTitleAsync(string title);
    }
}