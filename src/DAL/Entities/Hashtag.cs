namespace DAL.Entities;

public class Hashtag
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public ICollection<PostHashtag> Posts { get; set; }
}