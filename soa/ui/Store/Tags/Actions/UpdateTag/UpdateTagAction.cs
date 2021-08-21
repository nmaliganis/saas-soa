using System;

namespace soa.ui.Store.Tags.Actions.UpdateTag
{
  public class UpdateTagAction
  {
    public Guid TagToBeUpdateId { get; private set; }

    public UpdateTagAction(Guid tagToBeUpdateId)
    {
      TagToBeUpdateId = tagToBeUpdateId;
    }
  }
}