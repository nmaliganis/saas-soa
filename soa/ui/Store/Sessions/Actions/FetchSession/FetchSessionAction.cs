using System;

namespace smart.charger.webui.Store.Sessions.Actions.FetchSession
{
  public class FetchSessionAction
  {
    public Guid SessionToBeFetchedId { get; private set; }

    public FetchSessionAction(Guid sessionToBeFetchedId)
    {
      SessionToBeFetchedId = sessionToBeFetchedId;
    }
  }
}