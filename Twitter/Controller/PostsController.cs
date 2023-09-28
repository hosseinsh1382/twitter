using Microsoft.AspNetCore.Mvc;
using Twitter.Dtos;
using Twitter.Interfaces;

namespace Twitter.Controller;

[ApiController]
[Route("api/[controller]")]
public class PostsController : Microsoft.AspNetCore.Mvc.Controller
{
    private IPostRepository _repository;

    public PostsController(IPostRepository repository)
    {
        _repository = repository;
    }


    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_repository.ReadAll());
    }

    [HttpGet("{username}")]
    public ActionResult Get([FromHeader] string username)
    {
        return Ok(_repository.ReadAllByUsername(username));
    }

    [HttpGet("{id}")]
    public ActionResult Get([FromHeader] Guid id)
    {
        return Ok(_repository.Read(id));
    }

    [HttpPost]
    public ActionResult Create([FromBody] PostRequest postRequest)
    {
        return Ok(_repository.Create(postRequest));
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromHeader] Guid id, [FromBody] PostRequest postRequest)
    {
        if (_repository.Update(id, postRequest))
            return Ok();
        return NotFound("Post not found");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromHeader] Guid id)
    {
        if (_repository.Delete(id))
            return Ok();
        return NotFound("Post not found");

    }
}