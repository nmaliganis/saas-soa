using smart.charger.webui.Models.DTOs.Account;

namespace smart.charger.webui.Store.Account.Actions.LoginUser
{
  public class LoginUserSuccessAction
  {
    public AuthDto LoginUserHaveBeenGranted { get; private set; }

    public LoginUserSuccessAction(AuthDto loginUserHaveBeenGranted)
    {
      LoginUserHaveBeenGranted = loginUserHaveBeenGranted;
    }
  }
}