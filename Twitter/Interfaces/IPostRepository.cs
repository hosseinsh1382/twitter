using Twitter.Dtos;

namespace Twitter.Interfaces;

public interface IPostRepository
{
    PostResponse Create(PostRequest post);
    IEnumerable<PostResponse> ReadAll();
    IEnumerable<PostResponse> ReadAllByUsername(string username);
    PostResponse Read(Guid id);
    bool Update(Guid id, PostRequest post);
    bool Delete(Guid id);
}