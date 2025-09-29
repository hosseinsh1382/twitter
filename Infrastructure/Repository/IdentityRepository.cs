using System.Text.RegularExpressions;
using Presentation.Data;
using Presentation.Dtos;
using Presentation.Interfaces;

namespace Presentation.Repository;

public partial class IdentityRepository : IIdentityRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public IdentityRepository(IMapper mapper, ApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public SignUpResponse SignUp(SignUpRequest accountDto)
    {
        if (!CheckEmailValidation(accountDto.Email))
            return new SignUpResponse
            {
                Message = "Invalid email address"
            };
        if (!CheckEmailExistent(accountDto.Email))
            return new SignUpResponse
            {
                Message = "Email already exist"
            };
        if (!CheckUsernameExistent(accountDto.Username))
            return new SignUpResponse
            {
                Message = "username already exist"
            };
        var account = _mapper.MapSignUpRequestToAccount(accountDto);
        _dbContext.Accounts.Add(account);
        _dbContext.SaveChanges();
        return _mapper.MapAccountToSignUpRespond(account);

    }

    private bool CheckEmailExistent(string email)
    {
        var emails = _dbContext.Accounts.Select(account => account.Email);
        return emails.Contains(email);
    }

    private bool CheckUsernameExistent(string username)
    {
        var usernames = _dbContext.Accounts.Select(account => account.Email);
        return usernames.Contains(username);
    }

    private bool CheckEmailValidation(string email)
    {
        var regex = EmailRegex();
        return regex.IsMatch(email);
    }

    [GeneratedRegex(@"^\\w+@\\w+.\\w")]
    private static partial Regex EmailRegex();
}