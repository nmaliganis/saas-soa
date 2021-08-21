using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Store.Auth;
using smart.charger.webui.Store.Vehicles;
using smart.charger.webui.Store.Vehicles.Actions.FetchVehicles;
using Telerik.Blazor.Components;

namespace smart.charger.webui.Pages.Vehicles
{
  public class VehiclesViewModel : FluxorComponent
  {
    [Inject] public IDispatcher Dispatcher { get; set; }
    [Inject] public IState<VehicleState> VehicleState { get; set; }
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

    public VehicleDto SelectedVehicleItem { get; set; }
    private IEnumerable<VehicleDto> _selectedItems; 
    public IEnumerable<VehicleDto> SelectedItems 
    {
      get
      {
        if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<VehicleDto>()))
          return _selectedItems;

        if(VehicleState.Value.VehicleList == null)
          return _selectedItems = Enumerable.Empty<VehicleDto>();
        SelectedVehicleItem = VehicleState.Value.VehicleList.FirstOrDefault();
        return _selectedItems = new List<VehicleDto> { SelectedVehicleItem };
      }
      set => _selectedItems = value;
    }

    protected void OnSelect(IEnumerable<VehicleDto> vehicleItems)
    {
      SelectedVehicleItem = vehicleItems.FirstOrDefault();
      SelectedItems = new List<VehicleDto> { SelectedVehicleItem };
    }

    #endregion

    #region Commands

    protected void AddCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"vehicle-details/{Guid.Empty}");
      StateHasChanged();
    }
    protected void EditCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"vehicle-details/{SelectedItems?.FirstOrDefault()?.Id}");
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
      NavigationManager.NavigateTo($"vehicle-details/{Guid.Empty}");
      StateHasChanged();
    }
    protected async Task OnUpdateClickHandler()
    {
      NavigationManager.NavigateTo($"vehicle-details/{SelectedItems?.FirstOrDefault()?.Id}");
      StateHasChanged();
    }

    protected async Task OnDeleteClickHandler()
    {
    }
  }
}