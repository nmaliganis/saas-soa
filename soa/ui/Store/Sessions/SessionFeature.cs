using System;
using System.Collections.Generic;
using Fluxor;
using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Store.Sessions
{
  public class SessionFeature : Feature<SessionState>
  {
    public override string GetName() => "Session";

    protected override SessionState GetInitialState() => new SessionState(
      new List<SessionDto>(), 
      "",
      true,
      new SessionDto(), 
      new SessionForCreationDto(), 
      new SessionForModificationDto(), 
      Guid.Empty
    );
  }
}