using Fluxor;
using smart.charger.webui.Models.DTOs.Account;
using smart.charger.webui.Store.Account.Actions.InitLoginUser;
using soa.ui.Models.DTOs.Account;

namespace smart.charger.webui.Store.Account.Reducers.InitLoginUserReducer
{
  public class InitLoginUserReducer : Reducer<AccountState, InitLoginUserAction>
  {
    public override AccountState Reduce(AccountState state, InitLoginUserAction action)
    {
      return new AccountState(
        true,
        "",
        new LoginDto(), 
        state.JwtToken,
        false, false
      );
    }
  }
}