using InstagramCloneBackend.Data;
using InstagramCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly StoryRepository _repository;

        public StoriesController(StoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetStories()
        {
            var stories = _repository.GetStories();
            return Ok(stories);
        }

        [HttpPost]
        public IActionResult AddStory(Story story)
        {
            _repository.AddStory(story);
            return Ok(story);
        }
    }
}
