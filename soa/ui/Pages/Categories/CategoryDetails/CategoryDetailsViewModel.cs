using System;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using smart.charger.webui.Store.Sessions;

namespace soa.ui.Pages.Categories.CategoryDetails
{
    public class CategoryDetailsViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IState<SessionState> SessionState { get; set; }
        [Parameter] public Guid Id { get; set; }
        public string HeaderLabel { get; set; }
        public bool SaveBtnEnabled { get; set; }

        #region General

        protected override Task OnInitializedAsync()
        {
            this.SaveBtnEnabled = true;
            if (Id == Guid.Empty)
            {
                InitializeForCreation();
            }
            else
            {
                InitializeForModification();
            }

            StateHasChanged();
            return base.OnInitializedAsync();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region Common

        private void NavigateBackToSessions()
        {
            NavigationManager.NavigateTo($"sessions");
            StateHasChanged();
        }

        #endregion

        #region Events

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        protected async Task OnBackIconClick()
        {
            NavigateBackToSessions();
        }

        #endregion

        private void InitializeForCreation()
        {
            this.HeaderLabel = "Create";
        }

        private void InitializeForModification()
        {
            this.HeaderLabel = "Update";
        }
    }
}