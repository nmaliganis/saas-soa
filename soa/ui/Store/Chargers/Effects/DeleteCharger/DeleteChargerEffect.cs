using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Chargers;
using smart.charger.webui.Store.Chargers.Actions.DeleteCharger;

namespace smart.charger.webui.Store.Chargers.Effects.DeleteCharger
{
  public class DeleteChargerEffect : Effect<DeleteChargerAction>
  {
    public IChargerDataService ChargerDataService { get; set; }
    public DeleteChargerEffect(IChargerDataService chargerDataService)
    {
      ChargerDataService = chargerDataService;
    }

    public override async Task HandleAsync(DeleteChargerAction action, IDispatcher dispatcher)
    {
      try
      {
        var deletedCharger = await ChargerDataService.DeleteCharger(action.ChargerToBeDeletedId);
        dispatcher.Dispatch(new DeleteChargerSuccessAction(deletedCharger.Id, deletedCharger.Message));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new DeleteChargerFailedAction(e.Message));
      }  
    }
  }
}