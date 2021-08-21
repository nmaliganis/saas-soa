using System;

namespace smart.charger.webui.Store.Chargers.Actions.DeleteCharger
{
  public class DeleteChargerSuccessAction
  {
    public Guid ChargerHaveBeenDeletedId { get; private set; }
    public string ChargerDeletionStatus { get; private set; }

    public DeleteChargerSuccessAction(Guid chargerHaveBeenDeletedId, string chargerDeletionStatus)
    {
      ChargerHaveBeenDeletedId = chargerHaveBeenDeletedId;
      ChargerDeletionStatus = chargerDeletionStatus;
    }
  }
}