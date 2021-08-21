﻿using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Questions;
using soa.ui.Store.Questions.Actions.FetchQuestions;

namespace soa.ui.Store.Questions.Effects.FetchQuestions
{
  public class FetchQuestionListEffect : Effect<FetchQuestionListAction>
  {
    public IQuestionDataService QuestionDataService { get; set; }
    public FetchQuestionListEffect(IQuestionDataService questionDataService)
    {
      QuestionDataService = questionDataService;
    }

    public override async Task HandleAsync(FetchQuestionListAction action, IDispatcher dispatcher)
    {
      try
      {
        var questions = await QuestionDataService.GetQuestionList(action.Auth);
        dispatcher.Dispatch(new FetchQuestionListSuccessAction(questions));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchQuestionListFailedAction(e.Message));
      }      
    }
  }
}