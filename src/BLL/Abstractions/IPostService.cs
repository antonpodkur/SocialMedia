using BLL.DTOs;
using DAL.Entities;

namespace BLL.Abstractions;

public interface IPostService
{
    Task<PostDTO> AddAsync(PostDTO postDto);
    Task<IEnumerable<PostDTO>> GetAllAsync();
    Task<PostDTO> GetByIdAsync(string id);
    Task UpdateAsync(PostDTO postDto);
    Task RemoveAsync(string id);
    Task<Post> GetPostByIdAsync(string id);
    Task<IEnumerable<PostDTO>> CurrentUserGetAllPosts(string id);
}