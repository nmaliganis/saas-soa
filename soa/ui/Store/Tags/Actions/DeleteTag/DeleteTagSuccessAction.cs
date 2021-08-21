using System;

namespace soa.ui.Store.Tags.Actions.DeleteTag
{
  public class DeleteTagSuccessAction
  {
    public Guid TagHaveBeenDeletedId { get; private set; }
    public string TagDeletionStatus { get; private set; }

    public DeleteTagSuccessAction(Guid tagHaveBeenDeletedId, string tagDeletionStatus)
    {
      TagHaveBeenDeletedId = tagHaveBeenDeletedId;
      TagDeletionStatus = tagDeletionStatus;
    }
  }
}