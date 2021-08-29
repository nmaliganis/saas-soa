using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Chargers;
using smart.charger.webui.Services.Contracts.Sessions;
using smart.charger.webui.Store.Dashboard.Actions.FetchDashboards;
using soa.ui.Services.Contracts.Questions;
using soa.ui.Store.Dashboard.Actions.FetchDashboards;

namespace soa.ui.Store.Dashboard.Effects.FetchDashboard
{
  public class FetchDashboardEffect : Effect<FetchDashboardAction>
  {
    public IChargerDataService ChargerDataService { get; set; }
    public ISessionDataService SessionDataService { get; set; }
    public IQuestionDataService QuestionDataService { get; set; }
    public FetchDashboardEffect(IChargerDataService chargerDataService, ISessionDataService sessionDataService, 
      IQuestionDataService questionDataService)
    {
      ChargerDataService = chargerDataService;
      SessionDataService = sessionDataService;
      
      QuestionDataService = questionDataService;
    }

    public override async Task HandleAsync(FetchDashboardAction action, IDispatcher dispatcher)
    {
      try
      {
        var availableChargersCount = await ChargerDataService.FetchAvailableChargersCount(action.Auth);
        var chargersInUseCount = await ChargerDataService.FetchChargersInUseCount(action.Auth);

        var finishedSessionCount = await SessionDataService.FetchFinishedSessionCount(action.Auth);
        var activeSessionCount = await SessionDataService.FetchActiveSessionCount(action.Auth);
        
        var questionCountTotal = await QuestionDataService.FetchQuestionsTotalCount(action.Auth);
        var questionTodayTotalCount = await QuestionDataService.FetchQuestionsTodayTotalCount(action.Auth);
        var questionUnansweredTotalCount = await QuestionDataService.FetchQuestionsUnansweredTotalCount(action.Auth);

        dispatcher.Dispatch(new FetchDashboardSuccessAction(finishedSessionCount, activeSessionCount, availableChargersCount, chargersInUseCount, 
          questionCountTotal,questionUnansweredTotalCount,questionTodayTotalCount
        ));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchDashboardFailedAction(e.Message));
      }      
    }
  }
}