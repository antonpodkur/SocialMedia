using DAL.Abstractions.Repository;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class HashtagRepository: Repository<Hashtag>, IHashtagRepository
{
    public HashtagRepository(TestContext context) : base(context)
    {
    }
    
    public async Task<Hashtag> GetByIdAsync(string id)
    {
        return await _context.Set<Hashtag>().FindAsync(new Guid(id));
    }
}