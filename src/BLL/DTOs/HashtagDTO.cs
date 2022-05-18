using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTOs;

public class HashtagDTO
{
    public Guid? Id { get; set; }
    [Required]
    public String Name { get; set; }
    public ICollection<PostHashtag>? Posts { get; set; }
}