using Twitter.Helper;
using Twitter.Data;
using Twitter.Dtos;
using Twitter.Interfaces;

namespace Twitter.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public AccountRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public SignUpResponse SignUp(SignUpRequest accountDto)
    {
        var account = _mapper.MapSignUpRequestToAccount(accountDto);
        _dbContext.Accounts.Add(account);
        _dbContext.SaveChanges();
        return _mapper.MapAccountToSignUpRespond(account);
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
        return _mapper.MapAccountToAccountDto(_dbContext.Accounts.SingleOrDefault(account => account.Username == username));
    }

    public AccountDto GetById(Guid id)
    {
        return _mapper.MapAccountToAccountDto(_dbContext.Accounts.SingleOrDefault(account => account.Id == id));
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
        if (account is null)
        {
            return false;
        }

        _dbContext.Accounts.Remove(account);
        _dbContext.SaveChanges();
        
        return true;
    }
}