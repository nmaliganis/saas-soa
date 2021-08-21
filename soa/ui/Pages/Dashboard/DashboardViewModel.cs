using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.DataRetrieval;
using smart.charger.webui.Models;
using smart.charger.webui.Models.DTOs.Stations;
using smart.charger.webui.Store.Auth;
using smart.charger.webui.Store.Dashboard;
using smart.charger.webui.Store.Dashboard.Actions.FetchDashboards;
using smart.charger.webui.Store.Stations;
using smart.charger.webui.Store.Stations.Actions.FetchStation;

namespace smart.charger.webui.Pages.Dashboard
{
  public class DashboardViewModel : FluxorComponent
  {
    [Inject] public IDispatcher Dispatcher { get; set; }
    [Inject] public IState<StationState> StationState { get; set; }
    [Inject] public IState<DashboardState> DashboardState { get; set; }
    [Inject] public IState<AuthState> AuthState { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IConfiguration Configuration { get; set; }
    [Inject] public IssuesGenerator IssuesGeneratorService { get; set; }

    #region Initialization
    public string[] ZoomToolbar = new string[] { "Zoom", "ZoomIn", "ZoomOut", "Pan", "Reset" };
    protected override Task OnInitializedAsync()
    {
      Dispatcher.Dispatch(new FetchStationListAction(AuthState.Value.JwtToken));
      Dispatcher.Dispatch(new FetchDashboardAction(AuthState.Value.JwtToken));
      DateFilterData = IssuesFilter.GetTimeRangeFilterValues();
      LoadIssuesData();
      StateHasChanged();
      return base.OnInitializedAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
      if (!AuthState.Value.IsLoggedOn)
      {
        NavigateToSignin();
      }

      return base.OnAfterRenderAsync(firstRender);
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      StopTimer();
      GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    #endregion

    #region Functions

    protected void NavigateToSignin()
    {
      //NavigationManager.NavigateTo($"signin");
    }

    protected void PageChangedHandler(int currentPage)
    {

    }

    public StationDto SelectedStationItem { get; set; }
    private IEnumerable<StationDto> _selectedItems; 
    //public IEnumerable<StationDto> SelectedItems 
    //{
    //  get
    //  {
    //    if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<StationDto>()))
    //      return _selectedItems;

    //    if(Store.Stations.StationState. Value.StationList == null)
    //      return _selectedItems = Enumerable.Empty<StationDto>();
    //    SelectedStationItem = Store.Stations.StationState.Value.StationList.FirstOrDefault();
    //    return _selectedItems = new List<StationDto> { SelectedStationItem };
    //  }
    //  set => _selectedItems = value;
    //}

    protected void OnSelect(IEnumerable<StationDto> stationItems)
    {
      //SelectedStationItem = stationItems.FirstOrDefault();
      //SelectedItems = new List<StationDto> { SelectedStationItem };
    }

    #endregion

    #region Legacy

    public IEnumerable<Issue> IssuesList { get; set; } = new List<Issue>();
    public IEnumerable<Issue> OpenIssues { get; set; } = new List<Issue>();
    public IEnumerable<Issue> ClosedIssues { get; set; } = new List<Issue>();

    public CancellationTokenSource stopTimer;

    public List<DateFilterModel> DateFilterData;

    public int timeRange { get; set; }

    protected async Task LoadDataOnInterval()
    {
      StopTimer();
      stopTimer = new CancellationTokenSource();

      while (IssuesFilter.ShouldForceGeneration(timeRange))
      {
        await Task.Delay(10000, stopTimer.Token);
        await LoadIssuesData();
        StateHasChanged();
      }
    }

    public void StopTimer()
    {
      stopTimer?.Cancel();
    }

    protected async Task LoadIssuesData(int newTimeRange)
    {
      timeRange = newTimeRange;
      await LoadIssuesData();
    }

    protected async Task LoadIssuesData()
    {
      IssuesList = await IssuesGeneratorService.GetIssues(IssuesFilter.GetRangeFromNumber(timeRange));
      OpenIssues = IssuesFilter.GetOpenIssues(IssuesList);
      ClosedIssues = IssuesFilter.GetClosedIssues(IssuesList);

      StateHasChanged();

      await LoadDataOnInterval();

      StateHasChanged();
    }

    protected MarkupString GetCloseRate()
    {
      double rate = ((double)ClosedIssues.Count() / (double)IssuesList.Count());
      return new MarkupString($"{rate:P0}");
    }

    #endregion
  }
}