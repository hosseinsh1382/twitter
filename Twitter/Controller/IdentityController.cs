using Microsoft.AspNetCore.Mvc;
using Twitter.Dtos;
using Twitter.Interfaces;

namespace Twitter.Controller;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IIdentityRepository _repository;

    public IdentityController(IIdentityRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public ActionResult SignUp(SignUpRequest account)
    {
        var result = _repository.SignUp(account);
        if (result is null)
            return BadRequest();
        return Ok(result);
    }
}