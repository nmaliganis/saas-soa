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

namespace soa.ui.Pages.Dashboard
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

        public string[] ZoomToolbar = new string[] {"Zoom", "ZoomIn", "ZoomOut", "Pan", "Reset"};

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new FetchStationListAction(AuthState.Value.JwtToken));
            Dispatcher.Dispatch(new FetchDashboardAction(AuthState.Value.JwtToken));
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


        #region Recent Questions

        public async Task OnCheckRecentQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"recent-questions");
        }

        public async Task OnAskAQuestionRecentQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"unanswered-questions");
        }

        #endregion

        #region Unanswerwed Questions

        public async Task OnGiveAnAnswerUnansweredQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"unanswered-questions");
        }

        public async Task OnCheckUnansweredQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"unanswered-questions");
        }

        #endregion

    }
}