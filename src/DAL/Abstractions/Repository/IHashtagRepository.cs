using DAL.Entities;

namespace DAL.Abstractions.Repository;

public interface IHashtagRepository: IRepository<Hashtag>
{
    Task<Hashtag> GetByIdAsync(string id);
}