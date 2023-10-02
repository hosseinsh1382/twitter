using Twitter.Dtos;

namespace Twitter.Interfaces;

public interface IIdentityRepository
{
    SignUpResponse SignUp(SignUpRequest accountDto);
}