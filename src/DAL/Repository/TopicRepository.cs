using DAL.Abstractions.Repository;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class TopicRepository: Repository<Topic>, ITopicRepository
{
    public TopicRepository(TestContext context) : base(context)
    {
    }
}