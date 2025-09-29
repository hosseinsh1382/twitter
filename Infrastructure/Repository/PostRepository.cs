using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Dtos;
using Presentation.Interfaces;

namespace Presentation.Repository;

public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public PostRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public PostResponse Create(PostRequest post)
    {
        _dbContext.Add(_mapper.MapPostRequestToPost(post));
        _dbContext.SaveChanges();
        return _mapper.MapPostToPostResponse(_mapper.MapPostRequestToPost(post));
    }

    public IEnumerable<PostResponse> ReadAll()
    {
        return _mapper.MapAllPostToPostResponse(_dbContext.Posts.Include(post => post.Account));
    }

    public IEnumerable<PostResponse> ReadAllByUsername(string username)
    {
        var posts = _dbContext.Posts.Include(post => post.Account)
            .Where(post => post.Account.Username == username);
        return _mapper.MapAllPostToPostResponse(posts);
    }

    public PostResponse Read(Guid id)
    {
        var post = _dbContext.Posts.SingleOrDefault(post => post.Id == id);
        if (post is null)
            return null;
        return _mapper.MapPostToPostResponse(post);
    }

    public bool Update(Guid id, PostRequest post)
    {
        var oldPost = _dbContext.Posts.SingleOrDefault(post => post.Id == id);
        if (oldPost is null)
            return false;
        /*if (CheckPostEditAbility(oldPost.PublishDateTime))
            return false;*/

        oldPost.Text = post.Text;

        _dbContext.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var post = _dbContext.Posts.SingleOrDefault(post => post.Id == id);
        
        if (post is null) return false;
        
        _dbContext.Posts.Remove(post);
        _dbContext.SaveChanges();
        return true;
    }

    /*private bool CheckPostEditAbility(DateTime postedDateTime)
    {
        return DateTime.Now <= postedDateTime.AddMinutes(Constants.EditTimeMinutes);
    }*/
}