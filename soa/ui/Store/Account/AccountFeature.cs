using Fluxor;
using smart.charger.webui.Models.DTOs.Account;
using soa.ui.Models.DTOs.Account;

namespace smart.charger.webui.Store.Account
{
  public class AccountFeature : Feature<AccountState>
  {
    public override string GetName() => "Account";

    protected override AccountState GetInitialState() => new AccountState(
      true,
      "",
      new LoginDto(), 
      "",
      false, false
      );
  }
}