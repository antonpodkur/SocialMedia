using BLL.DTOs;

namespace BLL.Abstractions;

public interface IHashtagService
{
    Task<HashtagDTO> AddAsync(HashtagDTO HashtagDTO);
    Task<IEnumerable<HashtagDTO>> GetAllAsync();
    Task<HashtagDTO> GetByIdAsync(string id);
    Task UpdateAsync(HashtagDTO HashtagDTO);
    Task RemoveAsync(string id);
}