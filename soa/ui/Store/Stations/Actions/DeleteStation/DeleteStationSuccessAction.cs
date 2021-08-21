using System;

namespace smart.charger.webui.Store.Stations.Actions.DeleteStation
{
  public class DeleteStationSuccessAction
  {
    public Guid StationHaveBeenDeletedId { get; private set; }
    public string StationDeletionStatus { get; private set; }

    public DeleteStationSuccessAction(Guid stationHaveBeenDeletedId, string stationDeletionStatus)
    {
      StationHaveBeenDeletedId = stationHaveBeenDeletedId;
      StationDeletionStatus = stationDeletionStatus;
    }
  }
}