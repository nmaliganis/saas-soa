using System;

namespace smart.charger.webui.Store.Stations.Actions.FetchVehicle
{
  public class FetchStationAction
  {
    public Guid StationToBeFetchedId { get; private set; }

    public FetchStationAction(Guid stationToBeFetchedId)
    {
      StationToBeFetchedId = stationToBeFetchedId;
    }
  }
}