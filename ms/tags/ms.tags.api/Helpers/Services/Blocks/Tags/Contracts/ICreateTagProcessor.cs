using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;

namespace ms.tag.api.Helpers.Services.Blocks.Tags.Contracts
{
  public interface ICreateTagProcessor
  {
    Task<TagUiModel> CreateTagAsync(TagForCreationUiModel newTagUiModel);
  }
}