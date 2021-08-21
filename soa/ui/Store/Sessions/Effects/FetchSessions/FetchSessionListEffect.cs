using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Sessions;
using smart.charger.webui.Store.Sessions.Actions.FetchSessions;

namespace smart.charger.webui.Store.Sessions.Effects.FetchSessions
{
  public class FetchSessionListEffect : Effect<FetchSessionListAction>
  {
    public ISessionDataService SessionDataService { get; set; }
    public FetchSessionListEffect(ISessionDataService sessionDataService)
    {
      SessionDataService = sessionDataService;
    }

    public override async Task HandleAsync(FetchSessionListAction action, IDispatcher dispatcher)
    {
      try
      {
        var sessions = await SessionDataService.GetSessionList(action.Auth);
        dispatcher.Dispatch(new FetchSessionListSuccessAction(sessions));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchSessionListFailedAction(e.Message));
      }      
    }
  }
}