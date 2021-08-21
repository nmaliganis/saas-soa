using System;
using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Vehicles;

namespace soa.ui.Store.Vehicles
{
  public class VehicleState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<VehicleDto> VehicleList { get; private set; }
    public VehicleDto Vehicle { get; private set; }
    public VehicleForCreationDto VehicleToBeCreatedPayload { get; private set; }
    public VehicleForModificationDto VehicleToBeUpdatePayload { get; }
    public Guid VehicleId { get; }

    public VehicleState(
      List<VehicleDto> vehicleList, 
      string errorMessage, 
      bool isLoading,
      VehicleDto vehicle, 
      VehicleForCreationDto vehicleToBeCreatedPayload, 
      VehicleForModificationDto vehicleToBeUpdatePayload, 
      Guid vehicleId
    )
    {
      VehicleList  = vehicleList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Vehicle = vehicle;
      VehicleToBeCreatedPayload = vehicleToBeCreatedPayload;
      VehicleToBeUpdatePayload = vehicleToBeUpdatePayload;
      VehicleId = vehicleId;
    }
  }
}