using Twitter.Dtos;
using Twitter.Models;

namespace Twitter.Helper;

public static class Mapper
{
    public static Account MapSignUpRequestToAccount(SignUpRequest accountDto)
    {
        return new Account
        {
            AccountName = accountDto.AccountName,
            Username = accountDto.Username,
            Email = accountDto.Email,
            Fullname = accountDto.Fullname,
            Password = accountDto.Password,
            Biography = "",
            JoinedDate = DateTime.Now,
        };
    }

    public static SignUpRespond MapAccountToSignUpRespond(Account account)
    {
        return new SignUpRespond
        {
            Username = account.Username,
            Fullname = account.Fullname,
            AccountName = account.AccountName,
            Email = account.Email,
            JoinedDate = account.JoinedDate
        };
    }

    public static AccountDto MapAccountToAccountDto(Account? account)
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
}