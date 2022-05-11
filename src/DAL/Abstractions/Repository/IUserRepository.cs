using DAL.Entities;

namespace DAL.Abstractions.Repository;

public interface IUserRepository: IRepository<User>
{
    Task<User> GetByIdAsync(string id);
}