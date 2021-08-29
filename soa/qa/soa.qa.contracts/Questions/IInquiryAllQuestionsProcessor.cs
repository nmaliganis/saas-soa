using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace soa.qa.contracts.Questions
{
    public interface IInquiryAllQuestionsProcessor
    {
        Task<List<QuestionUiModel>> GetQuestionsAsync();
        Task<List<QuestionUiModel>> GetQuestionsAsyncByToday();
        Task<List<QuestionUiModel>> GetQuestionsAsyncByUnanswered();
        Task<int> GetQuestionsCountTotalAsync();

        Task<int> GetUnAnsweredQuestionsCountTotalAsync();
    }
}