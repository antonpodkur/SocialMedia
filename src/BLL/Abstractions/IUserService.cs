using BLL.DTOs;
using DAL.Entities;

namespace BLL.Abstractions;

public interface IUserService
{
    Task<UserDTO> AddAsync(UserDTO userDto);
    Task<IEnumerable<UserDTO>> GetAllAsync();
    Task<UserDTO> GetByIdAsync(string id);
    Task UpdateAsync(UserDTO userDto);
    Task RemoveAsync(string id);
    Task<User> GetUserByIdAsync(string id);
}