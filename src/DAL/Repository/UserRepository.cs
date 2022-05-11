using DAL.Abstractions.Repository;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class UserRepository: Repository<User>, IUserRepository
{
    public UserRepository(TestContext context) : base(context)
    {
    }

    public async Task<User> GetByIdAsync(string id)
    {
        var user = await _context.Set<User>().FindAsync(new Guid(id));

        if (user == null) return user;
        await _context.Entry(user).Collection(p => p.Posts).LoadAsync();

        return user;
    }
}