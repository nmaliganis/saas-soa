using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.Models.DTOs.Stations;
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Store.Auth;
using smart.charger.webui.Store.Stations;
using smart.charger.webui.Store.Stations.Actions.FetchStation;
using Telerik.Blazor.Components;

namespace smart.charger.webui.Pages.Stations
{
  public class StationsViewModel : FluxorComponent
  {
    [Inject] public IDispatcher Dispatcher { get; set; }
    [Inject] public IState<StationState> StationState { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IState<AuthState> AuthState { get; set; }
    [Inject] public IConfiguration Configuration { get; set; }

    protected void NavigateToSignin()
    {
      NavigationManager.NavigateTo($"signin");
    }

    #region Initialization

    protected override Task OnInitializedAsync()
    {
      Dispatcher.Dispatch(new FetchStationListAction(AuthState.Value.JwtToken));
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

    public StationDto SelectedStationItem { get; set; }
    private IEnumerable<StationDto> _selectedItems; 
    public IEnumerable<StationDto> SelectedItems 
    {
      get
      {
        if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<VehicleDto>()))
          return _selectedItems;

        if (StationState.Value.StationList == null)
          return _selectedItems = Enumerable.Empty<StationDto>();
        SelectedStationItem = StationState.Value.StationList.FirstOrDefault();
        return _selectedItems = new List<StationDto> { SelectedStationItem };
      }
      set => _selectedItems = value;
    }

    protected void OnSelect(IEnumerable<StationDto> vehicleItems)
    {
      SelectedStationItem = vehicleItems.FirstOrDefault();
      SelectedItems = new List<StationDto> { SelectedStationItem };
    }

    #endregion

    #region Commands

    protected void AddCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"station-details/{Guid.Empty}");
      StateHasChanged();
    }
    protected void EditCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"station-details/{SelectedItems?.FirstOrDefault()?.Id}");
      StateHasChanged();
    }

    protected void DeleteCommandFromToolbar(GridCommandEventArgs args)
    {
      StateHasChanged();
    }

    #endregion

    #region Buttons

    [Parameter] public bool SaveBtnEnabled { get; set; }

    protected async Task OnSaveClickHandler()
    {
    }
    protected async Task OnCancelClickHandler()
    {
    }

    #endregion
  }
}