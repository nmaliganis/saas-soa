using Fluxor;
using smart.charger.webui.Store.Auth.Actions.ClearAuth;

namespace smart.charger.webui.Store.Auth.Reducers.ClearAuth
{
  public class ClearAuthReducer : Reducer<AuthState, ClearAuthAction>
  {
    public override AuthState Reduce(AuthState state, ClearAuthAction action)
    {
      return new AuthState(
        false,
        "",
        "",
        false, 
        false
      );
    }
  }
}