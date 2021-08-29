using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.Store.Auth;
using soa.ui.Models.DTOs.Questions;
using soa.ui.Store.Categories;
using soa.ui.Store.Categories.Actions.FetchCategories;
using soa.ui.Store.Questions;
using soa.ui.Store.Tags;
using soa.ui.Store.Tags.Actions.FetchTags;
using Telerik.Blazor.Components;

namespace soa.ui.Pages.Questions
{
    public class AskQuestionViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<QuestionState> AskQuestionState { get; set; }
        [Inject] public IState<CategoryState> CategoryState { get; set; }
        [Inject] public IState<TagState> TagState { get; set; }
        [Inject] public IState<AuthState> AuthState { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        #region Initialization


        protected QuestionDto QuestionToBeAsked = new QuestionDto();

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new FetchCategoryListAction(AuthState.Value.JwtToken));
            Dispatcher.Dispatch(new FetchTagListAction(AuthState.Value.JwtToken));
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


        protected async Task CategorySelected(int? category)
        {

        }

        protected void SaveForTagAskQuestion(ListViewCommandEventArgs args)
        {

        }

        protected List<int> SelectedTagIds = new List<int>();

        protected List<string> SelectedTagsTitles = new List<string>();

        protected void PopulateSelectedTags()
        {
            SelectedTagsTitles = TagState.Value.TagList.Where(p => SelectedTagIds.Contains(p.Id))
                .Select(p => p.Title).ToList();
        }

        public void OnValueBodyChanged(string value)
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected async Task OnSaveNewQuestionClickHandler()
        {
        }

        #endregion
    }
}