using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;

namespace soa.qa.contracts.Tags
{
  public interface IDeleteTagProcessor
  {
    Task<TagForDeletionUiModel> SoftDeleteTagAsync(Guid accountIdToDeleteThisTag, int tagToBeDeletedId);
    Task<TagForDeletionUiModel> HardDeleteTagAsync(int tagToBeDeletedId);
  }
}