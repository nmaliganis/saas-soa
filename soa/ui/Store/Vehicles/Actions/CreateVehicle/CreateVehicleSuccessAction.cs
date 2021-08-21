using smart.charger.webui.Models.DTOs.Vehicles;

namespace smart.charger.webui.Store.Vehicles.Actions.CreateVehicle
{
  public class CreateVehicleSuccessAction
  {
    public VehicleDto VehicleHaveBeenCreated { get; private set; }

    public CreateVehicleSuccessAction(VehicleDto vehicleHaveBeenCreated)
    {
      VehicleHaveBeenCreated = vehicleHaveBeenCreated;
    }
  }
}