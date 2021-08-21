using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Questions;

namespace soa.qa.contracts.Questions
{
    public interface IInquiryAllQuestionsProcessor
    {
      Task<List<QuestionUiModel>> GetQuestionsAsync();
    }
}