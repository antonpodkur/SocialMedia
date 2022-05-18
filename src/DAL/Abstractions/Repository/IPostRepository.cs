using System.Collections;
using DAL.Entities;

namespace DAL.Abstractions.Repository;

public interface IPostRepository: IRepository<Post>
{
    Task<Post> GetByIdAsync(string id);
    Task<IEnumerable<Post>> GetPostsByAuthor(string authorId);
    Task<IEnumerable<Post>> GetAllPosts();
    Task<IEnumerable<Hashtag>> GetPostHashtags(string postId);
}