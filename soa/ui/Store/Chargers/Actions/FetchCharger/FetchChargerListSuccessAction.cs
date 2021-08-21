using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Chargers;

namespace smart.charger.webui.Store.Chargers.Actions.FetchCharger
{
  public class FetchChargerListSuccessAction
  {
    public List<ChargerDto> ChargerList { get; private set; }

    public FetchChargerListSuccessAction(List<ChargerDto> chargerList)
    {
      ChargerList  = chargerList;
    }
  }
}