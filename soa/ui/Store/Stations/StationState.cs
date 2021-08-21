using System;
using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Stations;

namespace smart.charger.webui.Store.Stations
{
  public class StationState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<StationDto> StationList { get; private set; }
    public StationDto Station { get; private set; }
    public StationForCreationDto StationToBeCreatedPayload { get; private set; }
    public StationForModificationDto StationToBeUpdatePayload { get; }
    public Guid StationId { get; }

    public StationState(
      List<StationDto> stationList, 
      string errorMessage, 
      bool isLoading,
      StationDto station, 
      StationForCreationDto stationToBeCreatedPayload, 
      StationForModificationDto stationToBeUpdatePayload, 
      Guid stationId
    )
    {
      StationList  = stationList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      StationToBeUpdatePayload = stationToBeUpdatePayload;
      Station = station;
      StationToBeCreatedPayload = stationToBeCreatedPayload;
      StationToBeUpdatePayload = stationToBeUpdatePayload;
      StationId = stationId;
    }
  }
}