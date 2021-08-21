using System;

namespace smart.charger.webui.Store.Stations.Actions.DeleteStation
{
  public class DeleteStationAction
  {
    public Guid StationToBeDeletedId { get; private set; }

    public DeleteStationAction(Guid stationToBeDeletedId)
    {
      StationToBeDeletedId = stationToBeDeletedId;
    }
  }
}