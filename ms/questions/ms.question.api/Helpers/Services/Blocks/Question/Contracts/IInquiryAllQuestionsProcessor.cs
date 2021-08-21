using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace ms.question.api.Helpers.Services.Blocks.Question.Contracts
{
    public interface IInquiryAllQuestionsProcessor
    {
      Task<List<QuestionUiModel>> GetQuestionsAsync();
    }
}