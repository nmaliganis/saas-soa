using smart.charger.webui.Models.DTOs.Account;

namespace smart.charger.webui.Store.Account
{
  public class AccountState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public LoginDto Login { get; private set; }
    public string JwtToken { get; private set; }
    public bool IsloggedInSucceeded { get; private set; }
    public bool IsloggedInFailed { get; private set; }

    public AccountState(
      bool isLoading,
      string errorMessage, 
      LoginDto login,
      string jwtToken,
      bool isloggedInSucceeded, bool isloggedInFailed
    )
    {
      IsLoading = isLoading;
      ErrorMessage = errorMessage;
      Login = login;
      JwtToken = jwtToken;
      IsloggedInSucceeded = isloggedInSucceeded;
      IsloggedInFailed = isloggedInFailed;
    }
  }
}