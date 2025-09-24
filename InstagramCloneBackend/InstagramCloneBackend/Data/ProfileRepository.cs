using InstagramCloneBackend.Models;

namespace InstagramCloneBackend.Data
{
    public class ProfileRepository
    {
        private readonly AppDbContext _context;

        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _context.Profiles.ToList();
        }

        public Profile? GetProfileById(int id)
        {
            return _context.Profiles.FirstOrDefault(p => p.Id == id);
        }

        public void AddProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
        }

        public void UpdateProfile(Profile profile)
        {
            _context.Profiles.Update(profile);
            _context.SaveChanges();
        }
    }
}
