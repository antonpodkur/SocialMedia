using DAL.Entities;

namespace DAL.Abstractions.Repository;

public interface IPostRepository: IRepository<Post>
{
    Task<Post> GetByIdAsync(string id);
}