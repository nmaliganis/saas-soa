using System;

namespace soa.ui.Store.Tags.Actions.FetchTag
{
  public class FetchTagAction
  {
    public int TagToBeFetchedId { get; private set; }

    public FetchTagAction(int tagToBeFetchedId)
    {
      TagToBeFetchedId = tagToBeFetchedId;
    }
  }
}