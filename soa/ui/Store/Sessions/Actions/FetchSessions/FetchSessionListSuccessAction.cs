using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Store.Sessions.Actions.FetchSessions
{
  public class FetchSessionListSuccessAction
  {
    public List<SessionDto> SessionList { get; private set; }

    public FetchSessionListSuccessAction(List<SessionDto> sessionList)
    {
      SessionList  = sessionList;
    }
  }
}