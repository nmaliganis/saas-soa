using Fluxor;
using smart.charger.webui.Models.DTOs.Account;
using smart.charger.webui.Store.Account.Actions.LoginUser;
using soa.ui.Models.DTOs.Account;

namespace smart.charger.webui.Store.Account.Reducers.LoginUser
{
  public class LoginUserSuccessActionReducer : Reducer<AccountState, LoginUserSuccessAction>
  {
    public override AccountState Reduce(AccountState state, LoginUserSuccessAction action)
    {
      return new AccountState(
        false,
        "",
        new LoginDto(), 
        action.LoginUserHaveBeenGranted.Token,
        true,
        false
        );
    }
  }
}