
namespace DAL.Entities;

public class Post
{
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String Body { get; set; }
    public string AuthorId { get; set; }
    public User Author { get; set; }
    public DateTime Date { get; set; }
    public ICollection<Hashtag> Hashtags { get; set; }
    public ICollection<Topic> Topics { get; set; }
    
}