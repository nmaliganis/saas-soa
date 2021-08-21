using System;

namespace smart.charger.webui.Store.Stations.Actions.UpdatesStation
{
  public class UpdateStationAction
  {
    public Guid StationToBeUpdateId { get; private set; }

    public UpdateStationAction(Guid stationToBeUpdateId)
    {
      StationToBeUpdateId = stationToBeUpdateId;
    }
  }
}