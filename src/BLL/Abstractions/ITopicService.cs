using BLL.DTOs;

namespace BLL.Abstractions;

public interface ITopicService
{
    Task<TopicDTO> AddAsync(TopicDTO TopicDTO);
    Task<IEnumerable<TopicDTO>> GetAllAsync();
    Task<TopicDTO> GetByIdAsync(string id);
    Task UpdateAsync(TopicDTO TopicDTO);
    Task RemoveAsync(string id);
}