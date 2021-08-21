using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace ms.answer.api.Helpers.Services.Blocks.Answers.Contracts
{
    public interface IInquiryAnswerProcessor
    {
        Task<AnswerUiModel> GetAnswerByIdAsync(int id);
        Task<AnswerUiModel> GetAnswerByTitleAsync(string title);
    }
}