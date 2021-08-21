using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using smart.charger.webui.Models.DTOs.Chargers;

namespace smart.charger.webui.Services.Contracts.Chargers
{
  public interface IChargerDataService
  {
    Task<List<ChargerDto>> GetChargerList(string authorizationToken = null);
    Task<ChargerDto> GetCharger(Guid actionChargerId);
    Task<int> GetTotalChargerCount();

    Task<ChargerDto> CreateCharger(ChargerForCreationDto chargerToBeCreated);
    Task<ChargerDto> UpdateCharger(Guid chargerIdToBeUpdated, ChargerForModificationDto chargerToBeUpdated);
    Task<ChargerDto> DeleteCharger(Guid chargerIdToBeDeleted);
    Task<int> FetchAvailableChargersCount(string authorizationToken = null);
    Task<int> FetchChargersInUseCount(string authorizationToken = null);
  }
}