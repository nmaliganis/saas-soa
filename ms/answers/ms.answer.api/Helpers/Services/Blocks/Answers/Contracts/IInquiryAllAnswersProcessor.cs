using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace soa.qa.contracts.Answers
{
    public interface IInquiryAllAnswersProcessor
    {
      Task<List<AnswerUiModel>> GetAnswersAsync();
    }
}