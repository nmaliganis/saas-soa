using System;
using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags.Actions.UpdateTag
{
  public class UpdateTagAction
  {
    public int TagToBeUpdateId { get; private set; }
    public TagForModificationDto TagForModificationDto { get; }

    public UpdateTagAction(int tagToBeUpdateId, TagForModificationDto tagForModificationDto)
    {
        TagToBeUpdateId = tagToBeUpdateId;
        TagForModificationDto = tagForModificationDto;
    }
  }
}