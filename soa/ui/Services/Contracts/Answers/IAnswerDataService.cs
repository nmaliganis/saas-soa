using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using soa.ui.Models.DTOs.Answers;

namespace soa.ui.Services.Contracts.Answers
{
  public interface IAnswerDataService
  {
    Task<List<AnswerDto>> GetAnswerList(string authorizationToken = null);
    Task<AnswerDto> GetAnswer(int actionAnswerId);
    Task<int> GetTotalAnswerCount();

    Task<AnswerDto> CreateAnswer(AnswerForCreationDto answerToBeCreated);
    Task<AnswerDto> UpdateAnswer(Guid answerIdToBeUpdated, AnswerForModificationDto answerToBeUpdated);
    Task<AnswerDto> DeleteAnswer(Guid answerIdToBeDeleted);
  }
}