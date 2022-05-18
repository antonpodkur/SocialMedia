namespace DAL.Entities;

public class Topic
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public ICollection<PostTopic> Posts { get; set; }
}