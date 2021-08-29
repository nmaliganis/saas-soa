namespace soa.ui.Store.Dashboard.Actions.FetchDashboards
{
  public class FetchDashboardSuccessAction
  {
    public int FinishedSessionCount { get; private set;}
    public int ActiveSessionCount { get; private set;}
    public int AvailableChargersCount { get; private set;}
    public int ChargersInUseCount { get; private set;}
    public int QuestionTotalCount { get; private set;}
    public int QuestionUnansweredTotalCount { get; private set;}
    public int QuestionTodayTotalCount { get; private set;}
    public int AnswerTotalCount { get; private set;}

    public FetchDashboardSuccessAction(int finishedSessionCount, 
      int activeSessionCount, int availableChargersCount, int chargersInUseCount,
      int questionTotalCount, int questionUnansweredTotalCount, int questionTodayTotalCount, int answerTotalCount
      )
    {
      FinishedSessionCount = finishedSessionCount;
      ActiveSessionCount = activeSessionCount;
      AvailableChargersCount = availableChargersCount;
      ChargersInUseCount = chargersInUseCount;
      QuestionTotalCount = questionTotalCount;
      QuestionUnansweredTotalCount = questionUnansweredTotalCount;
      QuestionTodayTotalCount = questionTodayTotalCount;
      AnswerTotalCount = answerTotalCount;
    }
  }
}