using BLL.DTOs;
using DAL.Entities;

namespace BLL.Abstractions;

public interface IHashtagService
{
    Task<HashtagDTO> AddAsync(HashtagDTO hashtagDTO);
    Task<IEnumerable<HashtagDTO>> GetAllAsync();
    Task<HashtagDTO> GetByIdAsync(string id);
    Task UpdateAsync(HashtagDTO hashtagDTO);
    Task RemoveAsync(string id);
    Task<Hashtag> GetHashtagByIdAsync(string id);
}