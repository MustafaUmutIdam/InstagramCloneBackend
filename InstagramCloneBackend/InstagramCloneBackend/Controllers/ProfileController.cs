using Microsoft.AspNetCore.Mvc;
using InstagramCloneBackend.Data;
using InstagramCloneBackend.Models;

namespace InstagramCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfileRepository _repository;

        public ProfilesController(ProfileRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetProfiles()
        {
            var profiles = _repository.GetProfiles();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfileById(int id)
        {
            var profile = _repository.GetProfileById(id);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public IActionResult AddProfile(Profile profile)
        {
            _repository.AddProfile(profile);
            return Ok(profile);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, Profile profile)
        {
            var existing = _repository.GetProfileById(id);
            if (existing == null) return NotFound();

            existing.Username = profile.Username;
            existing.FullName = profile.FullName;
            existing.PostCount = profile.PostCount;
            existing.FollowersCount = profile.FollowersCount;
            existing.FollowingCount = profile.FollowingCount;
            existing.Bio = profile.Bio;
            existing.ProfileNote = profile.ProfileNote;

            _repository.UpdateProfile(existing);
            return Ok(existing);
        }
    }
}
