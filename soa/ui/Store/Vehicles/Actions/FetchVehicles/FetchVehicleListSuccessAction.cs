using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Vehicles;

namespace smart.charger.webui.Store.Vehicles.Actions.FetchVehicles
{
  public class FetchVehicleListSuccessAction
  {
    public List<VehicleDto> VehicleList { get; private set; }

    public FetchVehicleListSuccessAction(List<VehicleDto> vehicleList)
    {
      VehicleList  = vehicleList;
    }
  }
}