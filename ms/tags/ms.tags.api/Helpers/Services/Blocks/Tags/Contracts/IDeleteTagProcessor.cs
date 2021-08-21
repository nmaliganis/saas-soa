using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;

namespace ms.tag.api.Helpers.Services.Blocks.Tags.Contracts
{
  public interface IDeleteTagProcessor
  {
    Task<TagForDeletionUiModel> SoftDeleteTagAsync(Guid accountIdToDeleteThisTag, int tagToBeDeletedId);
    Task<TagForDeletionUiModel> HardDeleteTagAsync(int tagToBeDeletedId);
  }
}