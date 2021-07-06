using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Answers;

namespace soa.contracts.Answers
{
    public interface IInquiryAnswerProcessor
    {
        Task<AnswerUiModel> GetAnswerByIdAsync(int id);
        Task<AnswerUiModel> GetAnswerByTitleAsync(string title);
    }
}