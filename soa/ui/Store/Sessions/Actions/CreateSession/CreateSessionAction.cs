using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Store.Sessions.Actions.CreateSession
{
  public class CreateSessionAction
  {
    public CreateSessionAction(SessionForCreationDto sessionToBeCreatedPayload)
    {
      SessionToBeCreatedPayload = sessionToBeCreatedPayload;
    }

    public SessionForCreationDto SessionToBeCreatedPayload { get; private set; }
  }
}