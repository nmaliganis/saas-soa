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
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Store.Auth;
using smart.charger.webui.Store.Dashboard;
using smart.charger.webui.Store.Dashboard.Actions.FetchDashboards;
using smart.charger.webui.Store.Stations;
using smart.charger.webui.Store.Stations.Actions.FetchStation;
using soa.ui.Models.DTOs.Questions;
using soa.ui.Store.Dashboard;
using soa.ui.Store.Dashboard.Actions.FetchDashboards;
using soa.ui.Store.Questions;
using soa.ui.Store.Questions.Actions.FetchQuestions;
using soa.ui.Store.Questions.Effects.FetchQuestions;

namespace soa.ui.Pages.Dashboard
{
    public class DashboardViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<StationState> StationState { get; set; }
        [Inject] public IState<DashboardState> DashboardState { get; set; }
        [Inject] public IState<QuestionState> QuestionState { get; set; }
        [Inject] public IState<AuthState> AuthState { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IssuesGenerator IssuesGeneratorService { get; set; }

        #region Initialization

        public string[] ZoomToolbar = new string[] {"Zoom", "ZoomIn", "ZoomOut", "Pan", "Reset"};

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new FetchQuestionListAction(AuthState.Value.JwtToken));
            Dispatcher.Dispatch(new FetchDashboardAction(AuthState.Value.JwtToken));
            StateHasChanged();
            return base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!AuthState.Value.IsLoggedOn)
            {
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

        #region Functions Questions

        protected void PageChangedHandlerQuestion(int currentPage)
        {
        }

        public async Task OnConfigureQuestionClickHandler()
        {
            NavigationManager.NavigateTo($"questions");
        }

        public QuestionDto SelectedQuestionItem { get; set; }
        private IEnumerable<QuestionDto> _selectedItemsQuestion;
        public IEnumerable<QuestionDto> SelectedItemsQuestion
        {
            get
            {
                if (_selectedItemsQuestion != null && !Equals(_selectedItemsQuestion, Enumerable.Empty<QuestionDto>()))
                    return _selectedItemsQuestion;

                if (QuestionState.Value.QuestionList == null)
                    return _selectedItemsQuestion = Enumerable.Empty<QuestionDto>();
                SelectedQuestionItem = QuestionState.Value.QuestionList.FirstOrDefault();
                return _selectedItemsQuestion = new List<QuestionDto> { SelectedQuestionItem };
            }
            set => _selectedItemsQuestion = value;
        }

        protected void OnSelectQuestion(IEnumerable<QuestionDto> questionItems)
        {
            SelectedQuestionItem = questionItems.FirstOrDefault();
            SelectedItemsQuestion = new List<QuestionDto> { SelectedQuestionItem };
        }

        #endregion

        #region Functions Unanswereds

        protected void PageChangedHandlerUnanswered(int currentPage)
        {
        }

        public async Task OnConfigureUnansweredClickHandler()
        {
            NavigationManager.NavigateTo($"unanswereds");
        }

        public QuestionDto SelectedUnansweredItem { get; set; }
        private IEnumerable<QuestionDto> _selectedItemsUnanswered;
        public IEnumerable<QuestionDto> SelectedItemsUnanswered
        {
            get
            {
                if (_selectedItemsUnanswered != null && !Equals(_selectedItemsUnanswered, Enumerable.Empty<QuestionDto>()))
                    return _selectedItemsUnanswered;

                if (QuestionState.Value.QuestionUnansweredList == null)
                    return _selectedItemsUnanswered = Enumerable.Empty<QuestionDto>();
                SelectedUnansweredItem = QuestionState.Value.QuestionUnansweredList.FirstOrDefault();
                return _selectedItemsUnanswered = new List<QuestionDto> { SelectedUnansweredItem };
            }
            set => _selectedItemsUnanswered = value;
        }

        protected void OnSelectUnanswered(IEnumerable<QuestionDto> unansweredItems)
        {
            SelectedUnansweredItem = unansweredItems.FirstOrDefault();
            SelectedItemsUnanswered = new List<QuestionDto> { SelectedUnansweredItem };
        }

        #endregion

        #region Recent Questions

        protected async Task OnCheckRecentQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"recent-questions");
        }

        protected async Task OnAskAQuestionRecentQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"askquestion");
        }

        #endregion

        #region Unanswerwed Questions

        protected async Task OnGiveAnAnswerUnansweredQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"unanswered-questions");
        }

        protected async Task OnCheckUnansweredQuestionsClickHandler()
        {
            NavigationManager.NavigateTo($"unanswered-questions");
        }

        #endregion
    }
}