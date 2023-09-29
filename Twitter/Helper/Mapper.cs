using Twitter.Dtos;
using Twitter.Interfaces;
using Twitter.Models;

namespace Twitter.Helper;

public class Mapper:IMapper
{

    public Account MapSignUpRequestToAccount(SignUpRequest accountDto)
    {
        return new Account
        {
            AccountName = accountDto.AccountName,
            Username = accountDto.Username,
            Email = accountDto.Email,
            Fullname = accountDto.Fullname,
            Password = accountDto.Password
        };
    }

    public SignUpResponse MapAccountToSignUpRespond(Account account)
    {
        return new SignUpResponse
        {
            Username = account.Username,
            Fullname = account.Fullname,
            AccountName = account.AccountName,
            Email = account.Email,
            JoinedDate = account.JoinedDate
        };
    }

    public AccountDto MapAccountToAccountDto(Account? account)
    {
        if (account is null)
            return null;
        return new AccountDto
        {
            AccountName = account.AccountName,
            Biography = account.Biography,
            JoinedDate = account.JoinedDate,
            Email = account.Email,
            Fullname = account.Fullname,
            Username = account.Username,
            Following = account.Following,
            Follower = account.Follower
        };
    }

    public Post MapPostRequestToPost(PostRequest postRequest)
    {
        return new Post
        {
            AccountId = postRequest.accountId,
            Text = postRequest.Text
        };
    }

    public  PostResponse MapPostToPostResponse(Post post)
    {
        return new PostResponse
        {
            Account = post.Account,
            Text = post.Text,
            Likes = post.Likes,
            Viewers = post.Viewers,
            Comments = post.Comments,
            PublishDateTime = post.PublishDateTime
        };
    }

    public  IEnumerable<PostResponse> MapAllPostToPostResponse(IEnumerable<Post> posts)
    {
        return posts.Select(post => new PostResponse
        {
            Account = post.Account,
            Text = post.Text,
            Likes = post.Likes,
            Viewers = post.Viewers,
            Comments = post.Comments,
            PublishDateTime = post.PublishDateTime
        });
    }
}