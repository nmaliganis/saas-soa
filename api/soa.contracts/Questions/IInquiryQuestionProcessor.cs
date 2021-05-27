using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Questions;

namespace soa.contracts.Questions
{
    public interface IInquiryQuestionProcessor
    {
        Task<QuestionUiModel> GetQuestionByIdAsync(Guid id);
        Task<QuestionUiModel> GetQuestionByNumPlateAsync(string numPlate);
    }
}