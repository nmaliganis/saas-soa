using System;

namespace soa.ui.Store.Tags.Actions.DeleteTag
{
  public class DeleteTagSuccessAction
  {
    public int TagHaveBeenDeletedId { get; private set; }
    public string TagDeletionStatus { get; private set; }

    public DeleteTagSuccessAction(int tagHaveBeenDeletedId, string tagDeletionStatus)
    {
      TagHaveBeenDeletedId = tagHaveBeenDeletedId;
      TagDeletionStatus = tagDeletionStatus;
    }
  }
}