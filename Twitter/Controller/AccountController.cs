using Microsoft.AspNetCore.Mvc;
using Twitter.Dtos;
using Twitter.Interfaces;

namespace Twitter.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Microsoft.AspNetCore.Mvc.Controller
{
    private IAccountRepository _repository;

    public AccountController(IAccountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult Get(Guid id)
    {
        return _repository.GetById(id) == null
            ? NotFound("Account not found")
            : Ok(_repository.GetById(id));
    }

    [HttpGet("{username}")]
    public ActionResult Get(string username)
    {
        return _repository.GetByUsername(username) == null
            ? NotFound("Account not found")
            : Ok(_repository.GetByUsername(username));
    }

    [HttpPost("{id}")]
    public ActionResult Update(Guid id, [FromBody] SignUpRequest account)
    {
        return _repository.Update(id, account) == false
            ? NotFound("User not found")
            : Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromHeader] Guid id)
    {
        return _repository.Delete(id) == false ? NotFound("User not found") : Ok();
    }
}