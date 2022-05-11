using BLL.DTOs;

namespace BLL.Abstractions;

public interface IPostService
{
    Task<PostDTO> AddAsync(PostDTO postDto);
    Task<IEnumerable<PostDTO>> GetAllAsync();
    Task<PostDTO> GetByIdAsync(string id);
    Task UpdateAsync(PostDTO postDto);
    Task RemoveAsync(string id);
}