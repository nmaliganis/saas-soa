using smart.charger.webui.Models.DTOs.Stations;

namespace smart.charger.webui.Store.Stations.Actions.CreateStation
{
  public class CreateStationSuccessAction
  {
    public StationDto StationHaveBeenCreated { get; private set; }

    public CreateStationSuccessAction(StationDto stationHaveBeenCreated)
    {
      StationHaveBeenCreated = stationHaveBeenCreated;
    }
  }
}