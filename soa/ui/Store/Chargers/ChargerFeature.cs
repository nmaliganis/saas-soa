using System;
using System.Collections.Generic;
using Fluxor;
using smart.charger.webui.Models.DTOs.Chargers;
using smart.charger.webui.Store.Chargers;

namespace smart.charger.webui.Store.Chargers
{
  public class ChargerFeature : Feature<ChargerState>
  {
    public override string GetName() => "Charger";

    protected override ChargerState GetInitialState() => new ChargerState(
      new List<ChargerDto>(), 
      "",
      true,
      new ChargerDto(), 
      new ChargerForCreationDto(), 
      new ChargerForModificationDto(), 
      Guid.Empty
    );
  }
}