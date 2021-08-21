using System;

namespace smart.charger.webui.Store.Chargers.Actions.UpdateCharger
{
  public class UpdateChargerSuccessAction
  {
    public Guid ChargerHaveBeenUpdateId { get; private set; }
    public string ChargerDeletionStatus { get; private set; }

    public UpdateChargerSuccessAction(Guid chargerHaveBeenUpdateId, string chargerDeletionStatus)
    {
      ChargerHaveBeenUpdateId = chargerHaveBeenUpdateId;
      ChargerDeletionStatus = chargerDeletionStatus;
    }
  }
}