using Fluxor;

namespace smart.charger.webui.Store.Auth
{
  public class AuthFeature : Feature<AuthState>
  {
    public override string GetName() => "Auth";

    protected override AuthState GetInitialState() => new AuthState(
      false,
      "",
      "",
      false, 
      false
    );
  }
}