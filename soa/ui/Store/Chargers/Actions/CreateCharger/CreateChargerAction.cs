using smart.charger.webui.Models.DTOs.Chargers;

namespace smart.charger.webui.Store.Chargers.Actions.CreateCharger
{
  public class CreateChargerAction
  {
    public CreateChargerAction(ChargerForCreationDto chargerToBeCreatedPayload)
    {
      ChargerToBeCreatedPayload = chargerToBeCreatedPayload;
    }

    public ChargerForCreationDto ChargerToBeCreatedPayload { get; private set; }
  }
}