using System;

namespace smart.charger.webui.Store.Stations.Actions.UpdatesStation
{
  public class UpdateStationSuccessAction
  {
    public Guid StationHaveBeenUpdateId { get; private set; }
    public string StationDeletionStatus { get; private set; }

    public UpdateStationSuccessAction(Guid stationHaveBeenUpdateId, string stationDeletionStatus)
    {
      StationHaveBeenUpdateId = stationHaveBeenUpdateId;
      StationDeletionStatus = stationDeletionStatus;
    }
  }
}