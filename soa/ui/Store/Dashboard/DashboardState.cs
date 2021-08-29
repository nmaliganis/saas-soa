namespace soa.ui.Store.Dashboard
{
  public class DashboardState
  {
    public string ErrorMessage { get; private set; }
    public int FinishedSessionCount { get; private set;}
    public int ActiveSessionCount { get; private set;}
    public int AvailableChargersCount { get; private set;}
    public int ChargersInUseCount { get; private set;}
    
    public int QuestionTodayCount { get; private set;}
    public int QuestionUnansweredCount { get; private set;}
    public int QuestionTotalCount { get; private set;}

    public DashboardState(string errorMessage, 
      int finishedSessionCount, int activeSessionCount,
      int availableChargersCount, int chargersInUseCount,
      int questionTodayCount, int questionUnansweredCount,
      int questionTotalCount
      )
    {
      ErrorMessage = errorMessage;
      FinishedSessionCount = finishedSessionCount;
      ActiveSessionCount = activeSessionCount;
      AvailableChargersCount = availableChargersCount;
      ChargersInUseCount = chargersInUseCount;
      
      QuestionTodayCount = questionTodayCount;
      QuestionUnansweredCount = questionUnansweredCount;
      QuestionTotalCount = questionTotalCount;
    }
  }
}