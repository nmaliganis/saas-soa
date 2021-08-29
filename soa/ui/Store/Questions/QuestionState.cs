using System;
using System.Collections.Generic;
using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Store.Questions
{
  public class QuestionState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<QuestionDto> QuestionList { get; private set; }
    public List<QuestionDto> QuestionTodayList { get; private set; }
    public List<QuestionDto> QuestionUnansweredList { get; private set; }
    public QuestionDto Question { get; private set; }
    public QuestionForCreationDto QuestionToBeCreatedPayload { get; private set; }
    public QuestionForModificationDto QuestionToBeUpdatePayload { get; }
    public Guid QuestionId { get; }

    public QuestionState(
      List<QuestionDto> questionList, 
      List<QuestionDto> questionTodayList, 
      List<QuestionDto> questionUnansweredList, 
      string errorMessage, 
      bool isLoading,
      QuestionDto question, 
      QuestionForCreationDto questionToBeCreatedPayload, 
      QuestionForModificationDto questionToBeUpdatePayload, 
      Guid questionId
    )
    {
      QuestionList  = questionList;
      QuestionTodayList = questionTodayList;
      QuestionUnansweredList = questionUnansweredList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Question = question;
      QuestionToBeCreatedPayload = questionToBeCreatedPayload;
      QuestionToBeUpdatePayload = questionToBeUpdatePayload;
      QuestionId = questionId;
    }
  }
}