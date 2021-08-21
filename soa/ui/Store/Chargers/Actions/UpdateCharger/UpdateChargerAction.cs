using System;

namespace smart.charger.webui.Store.Chargers.Actions.UpdateCharger
{
  public class UpdateChargerAction
  {
    public Guid ChargerToBeUpdateId { get; private set; }

    public UpdateChargerAction(Guid chargerToBeUpdateId)
    {
      ChargerToBeUpdateId = chargerToBeUpdateId;
    }
  }
}