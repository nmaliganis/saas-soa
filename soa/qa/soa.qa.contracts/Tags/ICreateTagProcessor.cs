using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;

namespace soa.qa.contracts.Tags
{
  public interface ICreateTagProcessor
  {
    Task<TagUiModel> CreateTagAsync(TagForCreationUiModel newTagUiModel);
  }
}