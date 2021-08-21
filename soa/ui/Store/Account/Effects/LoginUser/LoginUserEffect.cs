using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Contracts.Accounts;
using smart.charger.webui.Store.Account.Actions.LoginUser;

namespace smart.charger.webui.Store.Account.Effects.LoginUser
{
  public class LoginUserEffect : Effect<LoginUserAction>
  {
    public IAccountService AccountService { get; set; }
    public LoginUserEffect(IAccountService accountService)
    {
      AccountService = accountService;
    }

    public override async Task HandleAsync(LoginUserAction action, IDispatcher dispatcher)
    {
      try
      {
        var accountDetails = await AccountService.TryToLogin(action.LoginDtoPayload);

        dispatcher.Dispatch(new LoginUserSuccessAction(accountDetails));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new LoginUserFailedAction(e.Message, e.InnerException?.Message));
      }
    }
  }
}