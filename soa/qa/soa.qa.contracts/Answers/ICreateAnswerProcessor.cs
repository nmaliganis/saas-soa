using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace soa.qa.contracts.Answers
{
  public interface ICreateAnswerProcessor
  {
    Task<AnswerUiModel> CreateAnswerAsync(AnswerForCreationUiModel newAnswerUiModel);
  }
}