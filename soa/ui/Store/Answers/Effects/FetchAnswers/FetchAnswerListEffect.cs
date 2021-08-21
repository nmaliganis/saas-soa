using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Answers;
using soa.ui.Store.Answers.Actions.FetchAnswers;

namespace soa.ui.Store.Answers.Effects.FetchAnswers
{
  public class FetchAnswerListEffect : Effect<FetchAnswerListAction>
  {
    public IAnswerDataService AnswerDataService { get; set; }
    public FetchAnswerListEffect(IAnswerDataService answerDataService)
    {
      AnswerDataService = answerDataService;
    }

    public override async Task HandleAsync(FetchAnswerListAction action, IDispatcher dispatcher)
    {
      try
      {
        var Answers = await AnswerDataService.GetAnswerList(action.Auth);
        dispatcher.Dispatch(new FetchAnswerListSuccessAction(Answers));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchAnswerListFailedAction(e.Message));
      }      
    }
  }
}