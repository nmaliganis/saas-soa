using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Base;
using smart.charger.webui.Services.Contracts.Chargers;
using smart.charger.webui.Store.Chargers.Actions.CreateCharger;

namespace smart.charger.webui.Store.Chargers.Effects.CreateCharger
{
  public class CreateChargerEffect : Effect<CreateChargerAction>
  {
    public IChargerDataService ChargerDataService { get; set; }
    public CreateChargerEffect(IChargerDataService chargerDataService)
    {
      ChargerDataService = chargerDataService;
    }

    public override async Task HandleAsync(CreateChargerAction action, IDispatcher dispatcher)
    {
      try
      {
        var createdCharger = await ChargerDataService.CreateCharger(action.ChargerToBeCreatedPayload);
        dispatcher.Dispatch(new CreateChargerSuccessAction(createdCharger));
        //Todo: Logging
      }
      catch (ServiceHttpRequestException<string> e)
      {
        dispatcher.Dispatch(new CreateChargerFailedAction(errorMessage: e.Message, e.Content));
      }     
      catch (Exception e)
      {
        dispatcher.Dispatch(new CreateChargerFailedAction(errorMessage: e.Message, e.InnerException?.Message));
      }     
    }
  }
}