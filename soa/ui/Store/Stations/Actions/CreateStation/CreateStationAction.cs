using smart.charger.webui.Models.DTOs.Stations;

namespace smart.charger.webui.Store.Stations.Actions.CreateStation
{
  public class CreateStationAction
  {
    public CreateStationAction(StationForCreationDto stationToBeCreatedPayload)
    {
      StationToBeCreatedPayload = stationToBeCreatedPayload;
    }

    public StationForCreationDto StationToBeCreatedPayload { get; private set; }
  }
}