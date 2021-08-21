namespace smart.charger.webui.Store.Dashboard
{
  public class DashboardState
  {
    public string ErrorMessage { get; private set; }
    public int FinishedSessionCount { get; private set;}
    public int ActiveSessionCount { get; private set;}
    public int AvailableChargersCount { get; private set;}
    public int ChargersInUseCount { get; private set;}

    public DashboardState(string errorMessage, int finishedSessionCount, int activeSessionCount, int availableChargersCount, int chargersInUseCount)
    {
      ErrorMessage = errorMessage;
      FinishedSessionCount = finishedSessionCount;
      ActiveSessionCount = activeSessionCount;
      AvailableChargersCount = availableChargersCount;
      ChargersInUseCount = chargersInUseCount;
    }
  }
}