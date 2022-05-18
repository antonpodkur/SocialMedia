
namespace DAL.Entities;

public class Post
{
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String Body { get; set; }
    public string AuthorId { get; set; }
    public User Author { get; set; }
    public DateTime Date { get; set; }
    public ICollection<PostHashtag> Hashtags { get; set; }
    public ICollection<PostTopic> Topics { get; set; }
    
}