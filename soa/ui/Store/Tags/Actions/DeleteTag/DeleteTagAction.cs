using System;

namespace soa.ui.Store.Tags.Actions.DeleteTag
{
  public class DeleteTagAction
  {
    public Guid TagToBeDeletedId { get; private set; }

    public DeleteTagAction(Guid tagToBeDeletedId)
    {
      TagToBeDeletedId = tagToBeDeletedId;
    }
  }
}