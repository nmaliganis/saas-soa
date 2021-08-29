using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Services.Contracts.Questions
{
  public interface IQuestionDataService
  {
    Task<List<QuestionDto>> GetQuestionList(string authorizationToken = null);
    Task<QuestionDto> GetQuestion(int actionQuestionId);
    Task<int> GetTotalQuestionCount();

    Task<QuestionDto> CreateQuestion(QuestionForCreationDto questionToBeCreated);
    Task<QuestionDto> UpdateQuestion(Guid questionIdToBeUpdated, QuestionForModificationDto questionToBeUpdated);
    Task<QuestionDto> DeleteQuestion(Guid questionIdToBeDeleted);
    
    Task<int> FetchQuestionsTotalCount(string authorizationToken = null);
    Task<int> FetchQuestionsUnansweredTotalCount(string authorizationToken = null);
    Task<int> FetchQuestionsTodayTotalCount(string authorizationToken = null);
  }
}