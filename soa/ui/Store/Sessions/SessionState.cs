using System;
using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Store.Sessions
{
  public class SessionState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<SessionDto> SessionList { get; private set; }
    public SessionDto Session { get; private set; }
    public SessionForCreationDto SessionToBeCreatedPayload { get; private set; }
    public SessionForModificationDto SessionToBeUpdatePayload { get; }
    public Guid SessionId { get; }

    public SessionState(
      List<SessionDto> sessionList, 
      string errorMessage, 
      bool isLoading,
      SessionDto session, 
      SessionForCreationDto sessionToBeCreatedPayload, 
      SessionForModificationDto sessionToBeUpdatePayload, 
      Guid sessionId
    )
    {
      SessionList  = sessionList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Session = Session;
      SessionToBeCreatedPayload = sessionToBeCreatedPayload;
      SessionToBeUpdatePayload = sessionToBeUpdatePayload;
      SessionId = sessionId;
    }
  }
}