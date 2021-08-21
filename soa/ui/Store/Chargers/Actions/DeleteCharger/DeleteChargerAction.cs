using System;

namespace smart.charger.webui.Store.Chargers.Actions.DeleteCharger
{
  public class DeleteChargerAction
  {
    public Guid ChargerToBeDeletedId { get; private set; }

    public DeleteChargerAction(Guid chargerToBeDeletedId)
    {
      ChargerToBeDeletedId = chargerToBeDeletedId;
    }
  }
}