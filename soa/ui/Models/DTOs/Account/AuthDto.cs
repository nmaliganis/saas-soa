using System.ComponentModel.DataAnnotations;

namespace smart.charger.webui.Models.DTOs.Account
{
  public class AuthDto
  {
    [Required(AllowEmptyStrings = false)]
    [Editable(false)]
    public string Token { get; set; }
  }
}
