using Twitter.Helper;
using Twitter.Data;
using Twitter.Dtos;
using Twitter.Interfaces;

namespace Twitter.Repository;

public class AccountRepository : IAccountRepository
{
    private ApplicationDbContext _dbContext;

    public AccountRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public SignUpRespond SignUp(SignUpRequest accountDto)
    {
        var account = Mapper.MapSignUpRequestToAccount(accountDto);
        _dbContext.Accounts.Add(account);
        _dbContext.SaveChanges();
        return Mapper.MapAccountToSignUpRespond(account);
    }

    public IEnumerable<AllAccountDto> GetAll()
    {
        return _dbContext.Accounts.Select(a => new AllAccountDto
            {
                AccountName = a.AccountName,
                Username = a.Username
            })
            .ToList();
    }

    public AccountDto GetByUsername(string username)
    {
        return Mapper.MapAccountToAccountDto(_dbContext.Accounts.SingleOrDefault(account => account.Username == username));
    }

    public AccountDto GetById(Guid id)
    {
        return Mapper.MapAccountToAccountDto(_dbContext.Accounts.SingleOrDefault(account => account.Id == id));
    }

    public bool Update(Guid id, SignUpRequest account)
    {
        var oldAccount = _dbContext.Accounts.SingleOrDefault(account => account.Id == id);

        if (oldAccount == null)
        {
            return false;
        }

        oldAccount.AccountName = account.AccountName;
        oldAccount.Username = account.Username;
        oldAccount.Biography = account.Biography;
        oldAccount.Email = account.Email;
        oldAccount.Fullname = account.Fullname;

        _dbContext.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var account = _dbContext.Accounts.SingleOrDefault(account => account.Id == id);
        if (account==null)
        {
            return false;
        }

        _dbContext.Accounts.Remove(account);
        _dbContext.SaveChanges();
        
        return true;
    }
}