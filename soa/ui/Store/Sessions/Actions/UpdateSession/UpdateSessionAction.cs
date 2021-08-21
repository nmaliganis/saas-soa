using System;

namespace smart.charger.webui.Store.Sessions.Actions.UpdateSession
{
  public class UpdateSessionAction
  {
    public Guid SessionToBeUpdateId { get; private set; }

    public UpdateSessionAction(Guid sessionToBeUpdateId)
    {
      SessionToBeUpdateId = sessionToBeUpdateId;
    }
  }
}