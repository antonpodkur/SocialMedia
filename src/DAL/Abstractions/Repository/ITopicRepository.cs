using DAL.Entities;

namespace DAL.Abstractions.Repository;

public interface ITopicRepository: IRepository<Topic>
{
    Task<Topic> GetByIdAsync(string id);
}