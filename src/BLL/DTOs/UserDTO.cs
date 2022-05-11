using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTOs;

public class UserDTO
{
    public string Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public ICollection<Post> Posts { get; set; }
}