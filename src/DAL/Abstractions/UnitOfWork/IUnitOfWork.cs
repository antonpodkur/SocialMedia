using DAL.Abstractions.Repository;

namespace DAL.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IPostRepository Posts { get; }
    ITopicRepository Topics { get; }
    IHashtagRepository Hashtags { get; }

    Task<int> CompleteAsync();
}