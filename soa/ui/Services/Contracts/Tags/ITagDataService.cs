using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Services.Contracts.Tags
{
  public interface ITagDataService
  {
    Task<List<TagDto>> GetTagList(string authorizationToken = null);
    Task<TagDto> GetTag(int actionTagId);
    Task<int> GetTotalTagCount();

    Task<TagDto> CreateTag(TagForCreationDto tagToBeCreated);
    Task<TagDto> UpdateTag(Guid tagIdToBeUpdated, TagForModificationDto tagToBeUpdated);
    Task<TagDto> DeleteTag(Guid tagIdToBeDeleted);
  }
}