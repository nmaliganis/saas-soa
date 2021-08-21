using System;

namespace smart.charger.webui.Store.Vehicles.Actions.UpdateVehicle
{
  public class UpdateVehicleSuccessAction
  {
    public Guid VehicleHaveBeenUpdateId { get; private set; }
    public string VehicleDeletionStatus { get; private set; }

    public UpdateVehicleSuccessAction(Guid vehicleHaveBeenUpdateId, string vehicleDeletionStatus)
    {
      VehicleHaveBeenUpdateId = vehicleHaveBeenUpdateId;
      VehicleDeletionStatus = vehicleDeletionStatus;
    }
  }
}