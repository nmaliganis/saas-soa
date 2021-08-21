using System;

namespace soa.ui.Store.Tags.Actions.FetchTag
{
  public class FetchTagAction
  {
    public Guid TagToBeFetchedId { get; private set; }

    public FetchTagAction(Guid tagToBeFetchedId)
    {
      TagToBeFetchedId = tagToBeFetchedId;
    }
  }
}