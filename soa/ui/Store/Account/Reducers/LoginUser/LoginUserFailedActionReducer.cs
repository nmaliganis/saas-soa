using Fluxor;
using smart.charger.webui.Models.DTOs.Account;
using smart.charger.webui.Store.Account.Actions.LoginUser;
using soa.ui.Models.DTOs.Account;

namespace smart.charger.webui.Store.Account.Reducers.LoginUser
{
  public class LoginUserFailedActionReducer : Reducer<AccountState, LoginUserFailedAction>
  {
    public override AccountState Reduce(AccountState state, LoginUserFailedAction action)
    {
      return new AccountState(
        false,
        action.ErrorMessage,
        new LoginDto(), 
        state.JwtToken,
        false,
        true
      );
    }
  }
}