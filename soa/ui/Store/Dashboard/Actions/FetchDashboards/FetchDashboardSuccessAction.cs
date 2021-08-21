namespace smart.charger.webui.Store.Dashboard.Actions.FetchDashboards
{
  public class FetchDashboardSuccessAction
  {
    public int FinishedSessionCount { get; private set;}
    public int ActiveSessionCount { get; private set;}
    public int AvailableChargersCount { get; private set;}
    public int ChargersInUseCount { get; private set;}

    public FetchDashboardSuccessAction(int finishedSessionCount, int activeSessionCount, int availableChargersCount, int chargersInUseCount)
    {
      FinishedSessionCount = finishedSessionCount;
      ActiveSessionCount = activeSessionCount;
      AvailableChargersCount = availableChargersCount;
      ChargersInUseCount = chargersInUseCount;
    }
  }
}