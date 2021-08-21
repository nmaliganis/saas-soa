using smart.charger.webui.Models.DTOs.Chargers;

namespace smart.charger.webui.Store.Chargers.Actions.FetchChargers
{
  public class FetchChargerSuccessAction
  {
    public ChargerDto ChargerToHaveBeenFetched { get; private set; }

    public FetchChargerSuccessAction(ChargerDto chargerToHaveBeenFetched)
    {
      ChargerToHaveBeenFetched  = chargerToHaveBeenFetched;
    }
  }
}