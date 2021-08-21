using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Services.Contracts.Sessions
{
  public interface ISessionDataService
  {
    Task<List<SessionDto>> GetSessionList(string authorizationToken = null);
    Task<SessionDto> GetSession(int actionSessionId);
    Task<int> GetTotalSessionCount();

    Task<SessionDto> CreateSession(SessionForCreationDto sessionToBeCreated);
    Task<SessionDto> UpdateSession(Guid sessionIdToBeUpdated, SessionForModificationDto sessionToBeUpdated);
    Task<SessionDto> DeleteSession(Guid sessionIdToBeDeleted);
    Task<int> FetchFinishedSessionCount(string authorizationToken = null);
    Task<int> FetchActiveSessionCount(string authorizationToken = null);
  }
}