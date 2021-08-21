using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Stations;

namespace smart.charger.webui.Store.Stations.Actions.FetchStation
{
  public class FetchStationListSuccessAction
  {
    public List<StationDto> StationList { get; private set; }

    public FetchStationListSuccessAction(List<StationDto> stationList)
    {
      StationList  = stationList;
    }
  }
}