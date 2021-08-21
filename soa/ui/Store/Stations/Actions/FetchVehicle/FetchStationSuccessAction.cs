using smart.charger.webui.Models.DTOs.Stations;

namespace smart.charger.webui.Store.Stations.Actions.FetchVehicle
{
  public class FetchStationSuccessAction
  {
    public StationDto StationToHaveBeenFetched { get; private set; }

    public FetchStationSuccessAction(StationDto stationToHaveBeenFetched)
    {
      StationToHaveBeenFetched  = stationToHaveBeenFetched;
    }
  }
}