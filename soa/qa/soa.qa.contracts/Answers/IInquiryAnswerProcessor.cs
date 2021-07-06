using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace soa.qa.contracts.Answers
{
    public interface IInquiryAnswerProcessor
    {
        Task<AnswerUiModel> GetAnswerByIdAsync(int id);
        Task<AnswerUiModel> GetAnswerByTitleAsync(string title);
    }
}