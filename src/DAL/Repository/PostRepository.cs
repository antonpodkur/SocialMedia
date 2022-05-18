using DAL.Abstractions.Repository;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        var posts = _context.Set<Post>().ToList();
        if (posts == null)
        {
            return posts;
        }

        foreach (var post in posts)
        {
            await _context.Entry(post).Reference(p => p.Author).LoadAsync();
        }

        return posts;
    }

    public async Task<IEnumerable<Post>> GetPostsByAuthor(string authorId)
    {
        var posts = _context.Set<Post>().Where(p => p.AuthorId == authorId).ToList();

        if (posts == null)
        {
            return posts;
        }

        foreach (var post in posts)
        {
            await _context.Entry(post).Reference(p => p.Author).LoadAsync();
        }
        return posts.ToList();
    }

    public async Task<IEnumerable<Hashtag>> GetPostHashtags(string postId)
    {
        var post = await GetByIdAsync(postId);
        var hashtags = new List<Hashtag>();
        foreach (var postHashtag in post.Hashtags)
        {
            var hashtag = await _context.Set<Hashtag>().FindAsync(postHashtag.HashtagId);
            if (hashtag != null)
            {
                hashtags.Add(hashtag);
            }
        }

        return hashtags;
    }

}