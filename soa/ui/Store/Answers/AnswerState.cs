using System;
using System.Collections.Generic;
using soa.ui.Models.DTOs.Answers;

namespace soa.ui.Store.Answers
{
  public class AnswerState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<AnswerDto> AnswerList { get; private set; }
    public AnswerDto Answer { get; private set; }
    public AnswerForCreationDto AnswerToBeCreatedPayload { get; private set; }
    public AnswerForModificationDto AnswerToBeUpdatePayload { get; }
    public Guid AnswerId { get; }

    public AnswerState(
      List<AnswerDto> answerList, 
      string errorMessage, 
      bool isLoading,
      AnswerDto answer, 
      AnswerForCreationDto answerToBeCreatedPayload, 
      AnswerForModificationDto answerToBeUpdatePayload, 
      Guid answerId
    )
    {
      AnswerList  = answerList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Answer = answer;
      AnswerToBeCreatedPayload = answerToBeCreatedPayload;
      AnswerToBeUpdatePayload = answerToBeUpdatePayload;
      AnswerId = answerId;
    }
  }
}