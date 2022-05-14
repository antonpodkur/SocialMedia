using DAL.Abstractions.Repository;
using DAL.Abstractions.UnitOfWork;
using DAL.Context;
using DAL.Repository;

namespace DAL.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly TestContext _context;

    private IUserRepository _userRepository;
    private IPostRepository _postRepository;
    private ITopicRepository _topicRepository;
    private IHashtagRepository _hashtagRepository;
    
    public UnitOfWork(TestContext context)
    {
        _context = context;
    }

    public IUserRepository Users
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_context);
            }

            return _userRepository;
        }
    }

    public IPostRepository Posts
    {
        get
        {
            if (_postRepository == null)
            {
                _postRepository = new PostRepository(_context);
            }

            return _postRepository;
        }
    }

    public ITopicRepository Topics
    {
        get
        {
            if (_topicRepository == null)
            {
                _topicRepository = new TopicRepository(_context);
            }

            return _topicRepository;
        }
    }

    public IHashtagRepository Hashtags
    {
        get
        {
            if (_hashtagRepository == null)
            {
                _hashtagRepository = new HashtagRepository(_context);
            }

            return _hashtagRepository;
        }
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