using System;

namespace smart.charger.webui.Store.Vehicles.Actions.DeleteVehicle
{
  public class DeleteVehicleSuccessAction
  {
    public Guid VehicleHaveBeenDeletedId { get; private set; }
    public string VehicleDeletionStatus { get; private set; }

    public DeleteVehicleSuccessAction(Guid vehicleHaveBeenDeletedId, string vehicleDeletionStatus)
    {
      VehicleHaveBeenDeletedId = vehicleHaveBeenDeletedId;
      VehicleDeletionStatus = vehicleDeletionStatus;
    }
  }
}