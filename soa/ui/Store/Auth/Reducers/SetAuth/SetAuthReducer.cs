using Fluxor;
using smart.charger.webui.Store.Auth.Actions.SetAuth;

namespace smart.charger.webui.Store.Auth.Reducers.SetAuth
{
  public class SetAuthReducer : Reducer<AuthState, SetAuthAction>
  {
    public override AuthState Reduce(AuthState state, SetAuthAction action)
    {
      return new AuthState(
        true,
        "",
        action.JwtToken,
        action.IsLoggedIn, 
        false
      );
    }
  }
}