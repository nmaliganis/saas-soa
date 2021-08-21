using smart.charger.webui.Models.DTOs.Chargers;

namespace smart.charger.webui.Store.Chargers.Actions.CreateCharger
{
  public class CreateChargerSuccessAction
  {
    public ChargerDto ChargerHaveBeenCreated { get; private set; }

    public CreateChargerSuccessAction(ChargerDto chargerHaveBeenCreated)
    {
      ChargerHaveBeenCreated = chargerHaveBeenCreated;
    }
  }
}