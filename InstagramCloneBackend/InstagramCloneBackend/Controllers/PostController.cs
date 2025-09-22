using Microsoft.AspNetCore.Mvc;
using InstagramCloneBackend.Data;
using InstagramCloneBackend.Models;

namespace InstagramCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostRepository _repository;

        public PostsController(PostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _repository.GetPosts();
            return Ok(posts);
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            // id'yi client göndermemeli, DB atayacak
            _repository.AddPost(post);
            return Ok(post);
        }
    }
}
