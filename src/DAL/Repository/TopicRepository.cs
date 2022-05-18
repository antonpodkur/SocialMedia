using DAL.Abstractions.Repository;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class TopicRepository: Repository<Topic>, ITopicRepository
{
    public TopicRepository(TestContext context) : base(context)
    {
    }
    
    public async Task<Topic> GetByIdAsync(string id)
    {
        return await _context.Set<Topic>().FindAsync(new Guid(id));
    }

    public Topic FindOneByName(string name)
    {
        var topic = _context.Set<Topic>().First(h => h.Name == name);
        return topic;
    }

    public IEnumerable<Topic> FindAllByName(string name)
    {
        var topics = _context.Set<Topic>().Where(h => h.Name == name).ToList();
        return topics;
    }

    public async Task<Topic> AddAsync(Topic topic)
    {
        await _context.Set<Topic>().AddAsync(topic);
        await _context.SaveChangesAsync();
        return topic;
    }

    public async Task AddTopicToPost(string postId, string topicId)
    {
        var postTopic = new PostTopic()
        {
            Id = Guid.NewGuid(),
            TopicId = new Guid(topicId),
            PostId = new Guid(postId)
        };
        
        await _context.Set<PostTopic>().AddAsync(postTopic);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveTopicFromPost(string postId, string topicId)
    {
        var postTopic = _context.Set<PostTopic>().First(p => p.TopicId == new Guid(topicId) && p.PostId == new Guid(postId));
        if (postTopic != null)
        {
            _context.Set<PostTopic>().Remove(postTopic);
            await _context.SaveChangesAsync();
        }
    }

    public async Task CreateTopicAndAddToPost(string postId, Topic topic)
    {
        await _context.Set<Topic>().AddAsync(topic);
        
        var postTopic = new PostTopic()
        {
            Id = Guid.NewGuid(),
            TopicId = topic.Id,
            PostId = new Guid(postId)
        };
        
        await _context.Set<PostTopic>().AddAsync(postTopic);
        await _context.SaveChangesAsync();    }
}