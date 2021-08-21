using System;

namespace smart.charger.webui.Store.Sessions.Actions.DeleteSession
{
  public class DeleteSessionAction
  {
    public Guid SessionToBeDeletedId { get; private set; }

    public DeleteSessionAction(Guid sessionToBeDeletedId)
    {
      SessionToBeDeletedId = sessionToBeDeletedId;
    }
  }
}