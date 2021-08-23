using System;
using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags.Actions.UpdateTag
{
  public class UpdateTagSuccessAction
  {
    public int TagHaveBeenUpdateId { get; private set; }
    public TagDto TagHaveBeenUpdated { get; private set; }

    public UpdateTagSuccessAction(int tagHaveBeenUpdateId, TagDto tagHaveBeenUpdated)
    {
      TagHaveBeenUpdateId = tagHaveBeenUpdateId;
      TagHaveBeenUpdated = tagHaveBeenUpdated;
    }
  }
}