using DAL.Abstractions.Repository;
using DAL.Abstractions.UnitOfWork;
using DAL.Context;
using DAL.Repository;

namespace DAL.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly TestContext _context;

    public IUserRepository Users { get; }
    public IPostRepository Posts { get; }
    public ITopicRepository Topics { get; }
    public IHashtagRepository Hashtags { get; }

    public UnitOfWork(TestContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        Posts = new PostRepository(context);
        Topics = new TopicRepository(context);
        Hashtags = new HashtagRepository(context);
    }
    
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}