using BLL.DTOs;
using DAL.Entities;

namespace BLL.Abstractions;

public interface ITopicService
{
    Task<TopicDTO> AddAsync(TopicDTO topicDTO);
    Task<IEnumerable<TopicDTO>> GetAllAsync();
    Task<TopicDTO> GetByIdAsync(string id);
    Task UpdateAsync(TopicDTO topicDTO);
    Task RemoveAsync(string id);
    Task<Topic> GetTopicByIdAsync(string id);
    
    Task<IEnumerable<TopicDTO>> GetPostTopics(string postId);
    Task AddTopicToPost(string postId, TopicDTO topicDto);
    Task RemoveTopicFromPost(string postId, string topicId);
}