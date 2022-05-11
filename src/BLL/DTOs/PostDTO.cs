using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTOs;

public class PostDTO
{
    public Guid Id { get; set; }
    [Required]
    public String Title { get; set; }
    [Required]
    public String Body { get; set; }
    public string AuthorId { get; set; }
    public User Author { get; set; }
    public DateTime Date { get; set; }
    public ICollection<Hashtag> Hashtags { get; set; }
    public ICollection<Topic> Topics { get; set; }
}