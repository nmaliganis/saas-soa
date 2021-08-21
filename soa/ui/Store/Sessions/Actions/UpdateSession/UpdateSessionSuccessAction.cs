using System;

namespace smart.charger.webui.Store.Sessions.Actions.UpdateSession
{
  public class UpdateSessionSuccessAction
  {
    public Guid SessionHaveBeenUpdateId { get; private set; }
    public string SessionDeletionStatus { get; private set; }

    public UpdateSessionSuccessAction(Guid sessionHaveBeenUpdateId, string sessionDeletionStatus)
    {
      SessionHaveBeenUpdateId = sessionHaveBeenUpdateId;
      SessionDeletionStatus = sessionDeletionStatus;
    }
  }
}