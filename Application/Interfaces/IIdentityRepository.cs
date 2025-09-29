using Presentation.Dtos;

namespace Presentation.Interfaces;

public interface IIdentityRepository
{
    SignUpResponse SignUp(SignUpRequest accountDto);
}