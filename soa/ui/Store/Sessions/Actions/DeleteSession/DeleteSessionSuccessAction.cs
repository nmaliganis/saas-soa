using System;

namespace smart.charger.webui.Store.Sessions.Actions.DeleteSession
{
  public class DeleteSessionSuccessAction
  {
    public Guid SessionHaveBeenDeletedId { get; private set; }
    public string SessionDeletionStatus { get; private set; }

    public DeleteSessionSuccessAction(Guid sessionHaveBeenDeletedId, string sessionDeletionStatus)
    {
      SessionHaveBeenDeletedId = sessionHaveBeenDeletedId;
      SessionDeletionStatus = sessionDeletionStatus;
    }
  }
}