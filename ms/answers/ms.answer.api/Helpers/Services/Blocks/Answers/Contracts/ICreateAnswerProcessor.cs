using System.Threading.Tasks;
using soa.common.dtos.Vms.Answers;

namespace ms.answer.api.Helpers.Services.Blocks.Answers.Contracts
{
  public interface ICreateAnswerProcessor
  {
    Task<AnswerUiModel> CreateAnswerAsync(AnswerForCreationUiModel newAnswerUiModel);
  }
}