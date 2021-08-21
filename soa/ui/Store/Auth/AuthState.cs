namespace smart.charger.webui.Store.Auth
{
  public class AuthState
  {
    public bool IsLoggedOn { get; private set; }
    public string ErrorMessage { get; private set; }
    public string JwtToken { get; private set; }
    public bool IsloggedInSucceeded { get; private set; }
    public bool IsloggedInFailed { get; private set; }

    public AuthState(
      bool isLoggedOn,
      string errorMessage, 
      string jwtToken,
      bool isloggedInSucceeded,
      bool isloggedInFailed
    )
    {
      IsLoggedOn = isLoggedOn;
      ErrorMessage = errorMessage;
      JwtToken = jwtToken;
      IsloggedInSucceeded = isloggedInSucceeded;
      IsloggedInFailed = isloggedInFailed;
    }
  }
}