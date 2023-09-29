using Twitter.Dtos;
using Twitter.Models;

namespace Twitter.Interfaces;

public interface IMapper
{
    Account MapSignUpRequestToAccount(SignUpRequest accountDto);
    SignUpResponse MapAccountToSignUpRespond(Account account);
    AccountDto MapAccountToAccountDto(Account? account);
    Post MapPostRequestToPost(PostRequest postRequest);
    PostResponse MapPostToPostResponse(Post post);
    IEnumerable<PostResponse> MapAllPostToPostResponse(IEnumerable<Post> posts);
}