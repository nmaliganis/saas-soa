using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Account
{
  public class LoginDto
  {
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    [Required(ErrorMessage = "Username is required")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
    public string Password { get; set; }
  }
}