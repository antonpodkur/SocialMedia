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
    
    public async Task<Hashtag>? GetByIdAsync(string id)
    {
        return await _context.Set<Hashtag>().FindAsync(new Guid(id));
    }

    public Hashtag? FindOneByName(string name)
    {
        var hashtag = _context.Set<Hashtag>().First(h => h.Name == name);
        return hashtag;
    }
    
    public IEnumerable<Hashtag> FindAllByName(string name)
    {
        var hashtags = _context.Set<Hashtag>().Where(h => h.Name == name).ToList();
        return hashtags;
    }

    public async Task<Hashtag> AddAsync(Hashtag hashtag)
    {
        await _context.Set<Hashtag>().AddAsync(hashtag);
        await _context.SaveChangesAsync();
        return hashtag;
    }
    
    public async Task AddHashtagToPost(string postId, string hashtagId)
    {
        var postHashtag = new PostHashtag()
        {
            Id = Guid.NewGuid(),
            HashtagId = new Guid(hashtagId),
            PostId = new Guid(postId)
        };
        
        await _context.Set<PostHashtag>().AddAsync(postHashtag);
        await _context.SaveChangesAsync();
    }

    public async Task CreateHashtagAndAddToPost(string postId, Hashtag hashtag)
    {
        await _context.Set<Hashtag>().AddAsync(hashtag);
        
        var postHashtag = new PostHashtag()
        {
            Id = Guid.NewGuid(),
            HashtagId = hashtag.Id,
            PostId = new Guid(postId)
        };
        
        await _context.Set<PostHashtag>().AddAsync(postHashtag);
        await _context.SaveChangesAsync();

    }

    public async Task RemoveHashtagFromPost(string postId, string hashtagId)
    {
        var postHashtag = _context.Set<PostHashtag>().First(p => p.HashtagId == new Guid(hashtagId) && p.PostId == new Guid(postId));
        if (postHashtag != null)
        {
            _context.Set<PostHashtag>().Remove(postHashtag);
            await _context.SaveChangesAsync();
        }
    }
}

//TODO Add repositories for PostHashtag and PostTopic to store logic in them.