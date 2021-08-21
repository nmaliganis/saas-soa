using Fluxor;
using smart.charger.webui.Store.Account.Actions.LoginUser;

namespace smart.charger.webui.Store.Account.Reducers.LoginUser
{
  public class LoginUserReducer : Reducer<AccountState, LoginUserAction>
  {
    public override AccountState Reduce(AccountState state, LoginUserAction action)
    {
      return new AccountState(
          true,
          "",
          action.LoginDtoPayload,
          "",
          false, false
        );
    }
  }
}