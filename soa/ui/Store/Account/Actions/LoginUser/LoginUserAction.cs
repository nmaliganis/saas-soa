using smart.charger.webui.Models.DTOs.Account;
using soa.ui.Models.DTOs.Account;

namespace smart.charger.webui.Store.Account.Actions.LoginUser
{
  public class LoginUserAction
  {
    public LoginUserAction(LoginDto loginDto)
    {
      LoginDtoPayload = loginDto;
    }

    public LoginDto LoginDtoPayload { get; private set; }
  }
}