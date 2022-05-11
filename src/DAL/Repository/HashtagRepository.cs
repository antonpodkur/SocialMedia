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
}