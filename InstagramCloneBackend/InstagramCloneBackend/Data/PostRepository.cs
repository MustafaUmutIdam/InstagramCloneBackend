using InstagramCloneBackend.Models;

namespace InstagramCloneBackend.Data
{
    public class PostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);  // Id DB tarafından otomatik atanacak
            _context.SaveChanges();
        }
    }
}
