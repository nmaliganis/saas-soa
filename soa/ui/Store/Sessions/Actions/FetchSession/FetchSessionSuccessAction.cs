using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Store.Sessions.Actions.FetchSession
{
  public class FetchSessionSuccessAction
  {
    public SessionDto SessionToHaveBeenFetched { get; private set; }

    public FetchSessionSuccessAction(SessionDto sessionToHaveBeenFetched)
    {
      SessionToHaveBeenFetched  = sessionToHaveBeenFetched;
    }
  }
}