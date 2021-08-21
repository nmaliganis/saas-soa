using System;
using System.Collections.Generic;
using Fluxor;
using smart.charger.webui.Models.DTOs.Vehicles;
using soa.ui.Store.Vehicles;

namespace smart.charger.webui.Store.Vehicles
{
  public class VehicleFeature : Feature<VehicleState>
  {
    public override string GetName() => "Vehicle";

    protected override VehicleState GetInitialState() => new VehicleState(
      new List<VehicleDto>(), 
      "",
      true,
      new VehicleDto(), 
      new VehicleForCreationDto(), 
      new VehicleForModificationDto(), 
      Guid.Empty
    );
  }
}