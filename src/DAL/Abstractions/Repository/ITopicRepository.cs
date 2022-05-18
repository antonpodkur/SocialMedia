using DAL.Entities;

namespace DAL.Abstractions.Repository;

public interface ITopicRepository: IRepository<Topic>
{
    Task<Topic> GetByIdAsync(string id);
    Topic FindOneByName(string name);
    IEnumerable<Topic> FindAllByName(string name);
    Task<Topic> AddAsync(Topic topic);
    Task AddTopicToPost(string postId, string topicId);
    Task RemoveTopicFromPost(string postId, string topicId);
    Task CreateTopicAndAddToPost(string postId, Topic topic);
}