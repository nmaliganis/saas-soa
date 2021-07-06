using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Answers;

namespace soa.contracts.Answers
{
    public interface IInquiryAllAnswersProcessor
    {
      Task<List<AnswerUiModel>> GetAnswersAsync();
    }
}