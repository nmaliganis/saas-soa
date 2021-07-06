using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Tags;

namespace soa.contracts.Tags
{
  public interface ICreateTagProcessor
  {
    Task<TagUiModel> CreateTagAsync(TagForCreationUiModel newTagUiModel);
  }
}