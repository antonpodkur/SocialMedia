using DAL.Abstractions.Repository;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class PostRepository: Repository<Post>, IPostRepository
{
    public PostRepository(TestContext context) : base(context)
    {
    }

    public async Task<Post> GetByIdAsync(string id)
    {
        var post = await _context.Set<Post>().FindAsync(new Guid(id));

        if (post == null) return post;
        await _context.Entry(post).Collection(p => p.Hashtags).LoadAsync();
        await _context.Entry(post).Collection(p => p.Topics).LoadAsync();

        return post;
    }
}