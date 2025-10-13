using InstagramCloneBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace InstagramCloneBackend.Data
{
    public class MyPostRepository
    {
        private readonly AppDbContext _context;

        public MyPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MyPost> GetMyPosts()
        {
            return _context.MyPosts
                .Include(p => p.Profile) // ilişkili profil verisini getir
                .ToList();
        }

        public MyPost? GetMyPostById(int id)
        {
            return _context.MyPosts
                .Include(p => p.Profile)
                .FirstOrDefault(p => p.Id == id);
        }

        public void AddMyPost(MyPost post)
        {
            _context.MyPosts.Add(post);
            _context.SaveChanges();
        }

        public void UpdateMyPost(MyPost post)
        {
            _context.MyPosts.Update(post);
            _context.SaveChanges();
        }

        public void DeleteMyPost(int id)
        {
            var post = _context.MyPosts.Find(id);
            if (post != null)
            {
                _context.MyPosts.Remove(post);
                _context.SaveChanges();
            }
        }
    }
}
