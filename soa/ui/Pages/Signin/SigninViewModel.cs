using System;
using System.Threading.Tasks;
using System.Timers;
using Blazored.LocalStorage;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using smart.charger.webui.Store.Account;
using smart.charger.webui.Store.Account.Actions.InitLoginUser;
using smart.charger.webui.Store.Account.Actions.LoginUser;
using smart.charger.webui.Store.Auth;
using smart.charger.webui.Store.Auth.Actions.ClearAuth;
using smart.charger.webui.Store.Auth.Actions.SetAuth;
using Telerik.Blazor.Components;

namespace smart.charger.webui.Pages.Signin
{
  public class SigninViewModel : FluxorComponent
  {
    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public IState<AccountState> AccountState { get; set; }
    [Inject] public IState<AuthState> AuthState { get; set; }
    [Inject] public ILocalStorageService Storage { get; set; }
    public bool HidePassword { get; set; } = true;
    public bool SubmitValidated { get; set; } = false;
    public bool UsernameEnabled { get; set; } = true;
    public bool PasswordEnabled { get; set; } = true;
    public bool SubmitEnabled { get; set; } = true;

    public bool IsLoggedOn { get; set; } = false;

    [Inject] public NavigationManager NavigationManager { get; set; }

    public TelerikNotification NotificationComponent { get; set; }

    #region Func

    public void ShowSuccessLogin()
    {
      NotificationComponent.Show(new NotificationModel()
      {
        Text = "Success Login!",
        ThemeColor = "success",
        ShowIcon = true,
        Icon = "file-add",
      });
      ValidateStatusControlAfterLoginValidation();
    }

    private void ValidateStatusControlAfterLoginValidation()
    {
      SubmitValidated = false;
      SubmitEnabled = true;
      PasswordEnabled = true;
      UsernameEnabled = true;
    }

    public void ShowErrorLogin()
    {
      NotificationComponent.Show(new NotificationModel()
      {
        Text = "Error Login!",
        ThemeColor = "error",
        ShowIcon = true,
        Icon = "file-error",
      });
      ValidateStatusControlAfterLoginValidation();
    }

    #endregion


    public void HandleValidEditSubmit()
    {
      SubmitValidated = true;
      SubmitEnabled = false;
      PasswordEnabled = false;
      UsernameEnabled = false;
      Dispatcher.Dispatch(new LoginUserAction(AccountState.Value.Login));
    }

    public void DispatcherInitLogin()
    {
      Dispatcher.Dispatch(new InitLoginUserAction());
    }

    public async void StoreCredentialToStorage()
    {
      await Storage.SetItemAsync("JWT-Token", AccountState.Value.JwtToken);
      IsLoggedOn = true;
      Dispatcher.Dispatch(new SetAuthAction(true, AccountState.Value.JwtToken));
      SetTimer(1000);
    }

    protected string LoginButton { get; set; } = "Login";

    #region Timer

    private Timer _timer;

    public void SetTimer(double interval)
    {
      _timer = new Timer(interval);
      _timer.Elapsed += NotifyTimerElapsed;
      _timer.Enabled = true;
    }

    private void NotifyTimerElapsed(object sender, ElapsedEventArgs e)
    {
      _timer.Enabled = false;
      OnElapsed?.Invoke();
      InvokeAsync(() => NavigationManager.NavigateTo($"dashboard"));
      _timer.Dispose();
    }

    public event Action OnElapsed;

    #endregion

    protected override Task OnInitializedAsync()
    {
      this.IsLoggedOn = false;
      Dispatcher.Dispatch(new ClearAuthAction());

      StateHasChanged();
      return base.OnInitializedAsync();
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      GC.SuppressFinalize(this);
    }
  }
}
