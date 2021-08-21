using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Store.Sessions.Actions.CreateSession
{
  public class CreateSessionSuccessAction
  {
    public SessionDto SessionHaveBeenCreated { get; private set; }

    public CreateSessionSuccessAction(SessionDto sessionHaveBeenCreated)
    {
      SessionHaveBeenCreated = sessionHaveBeenCreated;
    }
  }
}