using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.Models.DTOs.Chargers;
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Store.Auth;
using smart.charger.webui.Store.Chargers;
using smart.charger.webui.Store.Chargers.Actions.FetchCharger;
using Telerik.Blazor.Components;

namespace smart.charger.webui.Pages.Chargers
{
  public class ChargersViewModel : FluxorComponent
  {
    [Inject] public IDispatcher Dispatcher { get; set; }
    [Inject] public IState<ChargerState> ChargerState { get; set; }
    [Inject] public IState<AuthState> AuthState { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IConfiguration Configuration { get; set; }

    protected void NavigateToSignin()
    {
      NavigationManager.NavigateTo($"signin");
    }

    #region Initialization

    protected override Task OnInitializedAsync()
    {
      Dispatcher.Dispatch(new FetchChargerListAction(AuthState.Value.JwtToken));
      StateHasChanged();
      return base.OnInitializedAsync();
    }

    protected override void Dispose(bool disposing)
    {
      _selectedItems = null;
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

    public ChargerDto SelectedChargerItem { get; set; }
    private IEnumerable<ChargerDto> _selectedItems; 
    public IEnumerable<ChargerDto> SelectedItems 
    {
      get
      {
        if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<VehicleDto>()))
          return _selectedItems;

        if(ChargerState.Value.ChargerList == null)
          return _selectedItems = Enumerable.Empty<ChargerDto>();
        SelectedChargerItem = ChargerState.Value.ChargerList.FirstOrDefault();
        return _selectedItems = new List<ChargerDto> { SelectedChargerItem };
      }
      set => _selectedItems = value;
    }

    protected void OnSelect(IEnumerable<ChargerDto> chargerItems)
    {
      SelectedChargerItem = chargerItems.FirstOrDefault();
      SelectedItems = new List<ChargerDto> { SelectedChargerItem };
    }

    #endregion

    #region Commands

    protected void AddCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"charger-details/{Guid.Empty}");
      StateHasChanged();
    }
    protected void EditCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"charger-details/{SelectedItems?.FirstOrDefault()?.Id}");
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