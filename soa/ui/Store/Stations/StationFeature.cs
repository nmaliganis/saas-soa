using System;
using System.Collections.Generic;
using Fluxor;
using smart.charger.webui.Models.DTOs.Stations;

namespace smart.charger.webui.Store.Stations
{
  public class StationFeature : Feature<StationState>
  {
    public override string GetName() => "Station";

    protected override StationState GetInitialState() => new StationState(
      new List<StationDto>(), 
      "",
      true,
      new StationDto(), 
      new StationForCreationDto(), 
      new StationForModificationDto(), 
      new Guid()
    );
  }
}