using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;

namespace soa.qa.contracts.Tags
{
    public interface IUpdateTagProcessor
    {
        Task<TagUiModel> UpdateTagAsync(int idTagToBeUpdated, TagForModificationUiModel updatedTag);
    }
}
