using System;

namespace soa.ui.Store.Tags.Actions.UpdateTag
{
  public class UpdateTagSuccessAction
  {
    public Guid TagHaveBeenUpdateId { get; private set; }
    public string TagDeletionStatus { get; private set; }

    public UpdateTagSuccessAction(Guid tagHaveBeenUpdateId, string tagDeletionStatus)
    {
      TagHaveBeenUpdateId = tagHaveBeenUpdateId;
      TagDeletionStatus = tagDeletionStatus;
    }
  }
}