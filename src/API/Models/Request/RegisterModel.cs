using System.ComponentModel.DataAnnotations;

namespace API.Models.Request;

public class RegisterModel
{
    [Required(ErrorMessage = "Username is required!")]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "Email is required!")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Password is required!")]
    public string? Password { get; set; }
}