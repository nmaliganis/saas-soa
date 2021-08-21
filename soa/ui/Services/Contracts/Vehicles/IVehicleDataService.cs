using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using smart.charger.webui.Models.DTOs.Vehicles;

namespace smart.charger.webui.Services.Contracts.Vehicles
{
  public interface IVehicleDataService
  {
    Task<List<VehicleDto>> GetVehicleList(string authorizationToken = null);
    Task<VehicleDto> GetVehicle(int actionVehicleId);
    Task<int> GetTotalVehicleCount();

    Task<VehicleDto> CreateVehicle(VehicleForCreationDto vehicleToBeCreated);
    Task<VehicleDto> UpdateVehicle(Guid vehicleIdToBeUpdated, VehicleForModificationDto vehicleToBeUpdated);
    Task<VehicleDto> DeleteVehicle(Guid vehicleIdToBeDeleted);
  }
}