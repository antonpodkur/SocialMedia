using DAL.Entities;

namespace DAL.Abstractions.Repository;

public interface IHashtagRepository: IRepository<Hashtag>
{
    Task<Hashtag> GetByIdAsync(string id);
    Hashtag FindOneByName(string name);
    IEnumerable<Hashtag> FindAllByName(string name);
    Task<Hashtag> AddAsync(Hashtag hashtag);
    Task AddHashtagToPost(string postId, string hashtagId);
    Task RemoveHashtagFromPost(string postId, string hashtagId);
    Task CreateHashtagAndAddToPost(string postId, Hashtag hashtag);
}