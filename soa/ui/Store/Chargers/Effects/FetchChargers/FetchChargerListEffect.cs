using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Chargers;
using smart.charger.webui.Store.Chargers.Actions.FetchCharger;

namespace smart.charger.webui.Store.Chargers.Effects.FetchChargers
{
  public class FetchChargerListEffect : Effect<FetchChargerListAction>
  {
    public IChargerDataService ChargerDataService { get; set; }
    public FetchChargerListEffect(IChargerDataService chargerDataService)
    {
      ChargerDataService = chargerDataService;
    }

    public override async Task HandleAsync(FetchChargerListAction action, IDispatcher dispatcher)
    {
      try
      {
        var chargers = await ChargerDataService.GetChargerList(action.Auth);
        dispatcher.Dispatch(new FetchChargerListSuccessAction(chargers));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchChargerListFailedAction(e.Message));
      }      
    }
  }
}