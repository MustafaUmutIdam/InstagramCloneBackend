using Microsoft.AspNetCore.Mvc;
using InstagramCloneBackend.Data;

namespace InstagramCloneBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostRepository _repository;

    public PostsController()
    {
        _repository = new PostRepository();
    }

    [HttpGet]
    public IActionResult GetPosts()
    {
        var posts = _repository.GetPosts();
        return Ok(posts);
    }
}
