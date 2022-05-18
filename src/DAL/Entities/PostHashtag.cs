namespace DAL.Entities;

public class PostHashtag
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Post? Post { get; set; }
    public Guid HashtagId { get; set; }
    public Hashtag? Hashtag { get; set; }
}