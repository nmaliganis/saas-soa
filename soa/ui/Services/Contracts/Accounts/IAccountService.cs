using System.Threading.Tasks;
using smart.charger.webui.Models.DTOs.Account;

namespace smart.charger.webui.Services.Contracts.Accounts
{
  public interface IAccountService
  {
    Task<AuthDto> TryToLogin(LoginDto login);
  }
}