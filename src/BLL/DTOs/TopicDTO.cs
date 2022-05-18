using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTOs;

public class TopicDTO
{
    public Guid Id { get; set; }
    [Required]
    public String Name { get; set; }
    public ICollection<PostTopic> Posts { get; set; }
}