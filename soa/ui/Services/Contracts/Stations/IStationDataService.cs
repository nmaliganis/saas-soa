using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using smart.charger.webui.Models.DTOs.Stations;

namespace smart.charger.webui.Services.Contracts.Stations
{
  public interface IStationDataService
  {
    Task<List<StationDto>> GetStationList(string authorizationToken = null);
    Task<StationDto> GetStation(Guid actionStationId);
    Task<int> GetTotalStationCount();

    Task<StationDto> CreateStation(StationForCreationDto stationToBeCreated);
    Task<StationDto> UpdateStation(Guid stationIdToBeUpdated, StationForModificationDto stationToBeUpdated);
    Task<StationDto> DeleteStation(Guid stationIdToBeDeleted);
  }
}