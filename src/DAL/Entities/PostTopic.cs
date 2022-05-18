namespace DAL.Entities;

public class PostTopic
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
}