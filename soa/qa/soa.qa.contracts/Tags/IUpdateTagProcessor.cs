using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Tags;

namespace soa.qa.contracts.Tags
{
    public interface IUpdateTagProcessor
    {
        Task<TagUiModel> UpdateTagAsync(int idTagToBeUpdated, TagForModificationUiModel updatedTag);
    }
}
