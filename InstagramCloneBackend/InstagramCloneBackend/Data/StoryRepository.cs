using InstagramCloneBackend.Models;

namespace InstagramCloneBackend.Data
{
    public class StoryRepository
    {
        private readonly AppDbContext _context;

        public StoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Story> GetStories()
        {
            return _context.Stories.ToList();
        }

        public void AddStory(Story story)
        {
            _context.Stories.Add(story);
            _context.SaveChanges();
        }
    }
}
