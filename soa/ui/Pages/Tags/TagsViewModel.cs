using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.Store.Auth;
using soa.ui.Models.DTOs.Tags;
using soa.ui.Store.Tags;
using soa.ui.Store.Tags.Actions.FetchTags;
using Telerik.Blazor.Components;

namespace soa.ui.Pages.Tags
{
    public class TagsViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<TagState> TagState { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IState<AuthState> AuthState { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        protected void NavigateToSignin()
        {
            //NavigationManager.NavigateTo($"signin");
        }

        #region Initialization

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new FetchTagListAction(AuthState.Value.JwtToken));
            StateHasChanged();
            return base.OnInitializedAsync();
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

        protected void PageChangedHandler(int currentPage)
        {

        }

        public TagDto SelectedTagItem { get; set; }
        private IEnumerable<TagDto> _selectedItems;

        public IEnumerable<TagDto> SelectedItems
        {
            get
            {
                if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<TagDto>()))
                    return _selectedItems;

                if (TagState.Value.TagList == null)
                    return _selectedItems = Enumerable.Empty<TagDto>();
                SelectedTagItem = TagState.Value.TagList.FirstOrDefault();
                return _selectedItems = new List<TagDto> {SelectedTagItem};
            }
            set => _selectedItems = value;
        }

        protected void OnSelect(IEnumerable<TagDto> tagItems)
        {
            SelectedTagItem = tagItems.FirstOrDefault();
            SelectedItems = new List<TagDto> {SelectedTagItem};
        }

        #endregion

        #region Commands

        protected void AddCommandFromToolbar(GridCommandEventArgs args)
        {
            NavigationManager.NavigateTo($"Tag-details/{Guid.Empty}");
            StateHasChanged();
        }

        protected void EditCommandFromToolbar(GridCommandEventArgs args)
        {
            NavigationManager.NavigateTo($"Tag-details/{SelectedItems?.FirstOrDefault()?.Id}");
            StateHasChanged();
        }

        protected void DeleteCommandFromToolbar(GridCommandEventArgs args)
        {
            StateHasChanged();
        }

        #endregion

        public bool SaveBtnEnabled { get; set; } = true;

        protected async Task OnAddClickHandler()
        {
            NavigationManager.NavigateTo($"Tag-details/{Guid.Empty}");
            StateHasChanged();
        }

        protected async Task OnUpdateClickHandler()
        {
            NavigationManager.NavigateTo($"Tag-details/{SelectedItems?.FirstOrDefault()?.Id}");
            StateHasChanged();
        }

        protected async Task OnDeleteClickHandler()
        {
        }
    }
}