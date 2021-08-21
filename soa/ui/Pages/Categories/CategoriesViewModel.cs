using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.Models.DTOs.Sessions;
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Store.Auth;
using smart.charger.webui.Store.Sessions;
using smart.charger.webui.Store.Sessions.Actions.FetchSessions;
using smart.charger.webui.Store.Vehicles;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicles;
using soa.ui.Store.Vehicles;
using Telerik.Blazor.Components;

namespace soa.ui.Pages.Categories
{
    public class CategoriesViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<SessionState> SessionState { get; set; }
        [Inject] public IState<VehicleState> VehicleState { get; set; }
        [Inject] public IState<AuthState> AuthState { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        #region List Vehicle

        public DateTime? StartValue { get; set; } = DateTime.Now;
        public DateTime? EndValue { get; set; } = DateTime.Now.AddDays(10);

        protected VehicleDto BindVehicle { get; set; }

        public async Task OnChangeHandler(DateRangePickerChangeEventArgs e)
        {
            Console.WriteLine($"The range is from {e.StartValue} to {e.EndValue}");
        }

        public void VehicleOnChangeHandler(object theUserInput)
        {

        }

        #endregion

        #region Dates

        public DateTime FromDateInputValue { get; set; } = DateTime.Now;

        public TelerikDateInput<DateTime> From;

        public DateTime ToDateInputValue { get; set; } = DateTime.Now;

        public TelerikDateInput<DateTime> To;

        #endregion

        protected void NavigateToSignin()
        {
            //NavigationManager.NavigateTo($"signin");
        }

        #region Initialization

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new FetchSessionListAction(AuthState.Value.JwtToken));
            Dispatcher.Dispatch(new FetchVehicleListAction(AuthState.Value.JwtToken));
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

        public SessionDto SelectedSessionItem { get; set; }
        private IEnumerable<SessionDto> _selectedItems;

        public IEnumerable<SessionDto> SelectedItems
        {
            get
            {
                if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<VehicleDto>()))
                    return _selectedItems;

                // if(Store.Sessions.SessionState.Value.SessionList == null)
                //   return _selectedItems = Enumerable.Empty<SessionDto>();
                // SelectedSessionItem = Store.Sessions.SessionState.Value.SessionList.FirstOrDefault();
                return _selectedItems = new List<SessionDto> {SelectedSessionItem};
            }
            set => _selectedItems = value;
        }

        protected void OnSelect(IEnumerable<SessionDto> vehicleItems)
        {
            SelectedSessionItem = vehicleItems.FirstOrDefault();
            SelectedItems = new List<SessionDto> {SelectedSessionItem};
        }

        #endregion

        #region Commands

        protected void AddCommandFromToolbar(GridCommandEventArgs args)
        {
            NavigationManager.NavigateTo($"session-details/{Guid.Empty}");
            StateHasChanged();
        }

        protected void EditCommandFromToolbar(GridCommandEventArgs args)
        {
            NavigationManager.NavigateTo($"session-details/{SelectedItems?.FirstOrDefault()?.Id}");
            StateHasChanged();
        }

        protected void DeleteCommandFromToolbar(GridCommandEventArgs args)
        {
            StateHasChanged();
        }

        #endregion

        #region Buttons

        [Parameter] public bool SaveBtnEnabled { get; set; } = true;

        protected async Task OnAddCategoryClickHandler()
        {
            NavigationManager.NavigateTo($"category-details/{Guid.Empty}");
            StateHasChanged();
        }
        protected async Task OnEditCategoryClickHandler()
        {
            NavigationManager.NavigateTo($"category-details/{SelectedItems?.FirstOrDefault()?.Id}");
            StateHasChanged();
        }

        protected async Task OnDeleteCategoryClickHandler()
        {
            NavigationManager.NavigateTo($"category-details/{Guid.Empty}");
            StateHasChanged();
        }

        #endregion
    }
}