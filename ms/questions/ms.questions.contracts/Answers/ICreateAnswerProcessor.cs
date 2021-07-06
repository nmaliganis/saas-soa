using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Answers;

namespace soa.contracts.Answers
{
  public interface ICreateAnswerProcessor
  {
    Task<AnswerUiModel> CreateAnswerAsync(AnswerForCreationUiModel newAnswerUiModel);
  }
}