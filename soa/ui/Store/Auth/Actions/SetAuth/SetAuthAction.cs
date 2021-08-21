namespace smart.charger.webui.Store.Auth.Actions.SetAuth
{
  public class SetAuthAction
  {   
    public SetAuthAction(bool isLoggedIn, string jwtToken)
    {
      IsLoggedIn = isLoggedIn;
      JwtToken = jwtToken;
    }

    public bool IsLoggedIn { get; private set; }
    public string JwtToken { get; }
  }
}