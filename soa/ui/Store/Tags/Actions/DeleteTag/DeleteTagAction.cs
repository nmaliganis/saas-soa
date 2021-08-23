using System;

namespace soa.ui.Store.Tags.Actions.DeleteTag
{
  public class DeleteTagAction
  {
    public int TagToBeDeletedId { get; private set; }

    public DeleteTagAction(int tagToBeDeletedId)
    {
      TagToBeDeletedId = tagToBeDeletedId;
    }
  }
}