using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs;

public class HashtagDTO
{
    public Guid Id { get; set; }
    [Required]
    public String Name { get; set; }
}