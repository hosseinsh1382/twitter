﻿using Twitter.Dtos;

namespace Twitter.Interfaces;

public interface IAccountRepository
{
    IEnumerable<AllAccountDto> GetAll();
    AccountDto GetByUsername(string username);
    AccountDto GetById(Guid id);
    bool Update(Guid id,SignUpRequest account);
    bool Delete(Guid id);
}