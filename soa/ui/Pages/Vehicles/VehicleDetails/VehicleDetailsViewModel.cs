using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Store.Vehicles;
using soa.ui.Store.Vehicles;

namespace soa.ui.Pages.Vehicles.VehicleDetails
{
    public class VehicleDetailsViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IState<VehicleState> VehicleState { get; set; }
        [Parameter] public Guid Id { get; set; }
        public bool BatteryValueEnabled { get; set; } = false;
        public string HeaderLabel { get; set; }
        public bool SaveBtnEnabled { get; set; }

        #region Validation

        public Dictionary<string, bool> ValidationActions { get; set; } = new Dictionary<string, bool>();
        public bool ValidationSuccess { get; set; } = false;

        public string SuccessMessage = string.Empty;

        public VehicleDto ValidationModel { get; set; } = new VehicleDto();

        protected async void HandleValidSubmit()
        {
            SuccessMessage = "Form Submitted Successfully!";
            await Task.Delay(2000);
            SuccessMessage = string.Empty;
            StateHasChanged();
        }

        protected void HandleInvalidSubmit()
        {
            SuccessMessage = string.Empty;
        }

        #endregion



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

        private void NavigateBackToVehicles()
        {
            NavigationManager.NavigateTo($"vehicles");
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
            NavigateBackToVehicles();
        }

        #endregion

        #region Actions

        protected async Task OnCancelClickHandler()
        {
            NavigateBackToVehicles();
        }

        protected async Task OnSaveClickHandler()
        {
            //Validation
        }

        #endregion

        #region Controls

        public IEnumerable<VehicleChargerConnectionType> ConnectionTypeData { get; set; } =
            new List<VehicleChargerConnectionType>()
            {
                new VehicleChargerConnectionType()
                {
                    Type = "Bev",
                },
                new VehicleChargerConnectionType()
                {
                    Type = "Phev",
                },
            };

        public string SelectedConnectionType { get; set; }

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
