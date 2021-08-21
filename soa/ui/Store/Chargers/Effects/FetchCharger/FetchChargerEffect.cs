using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Chargers;
using smart.charger.webui.Store.Chargers.Actions.FetchChargers;

namespace smart.charger.webui.Store.Chargers.Effects.FetchCharger
{
  public class FetchChargerEffect : Effect<FetchChargerAction>
  {
    public IChargerDataService ChargerDataService { get; set; }
    public FetchChargerEffect(IChargerDataService chargerDataService)
    {
      ChargerDataService = chargerDataService;
    }

    public override async Task HandleAsync(FetchChargerAction action, IDispatcher dispatcher)
    {
      try
      {
        var charger = await ChargerDataService.GetCharger(action.ChargerToBeFetchedId);
        dispatcher.Dispatch(new FetchChargerSuccessAction(charger));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchChargerFailedAction(e.Message));
      }     
    }
  }
}