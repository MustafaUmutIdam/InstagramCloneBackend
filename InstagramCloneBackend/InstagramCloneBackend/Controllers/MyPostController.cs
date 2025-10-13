using InstagramCloneBackend.Data;
using InstagramCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstagramCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyPostsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MyPostsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        //  1. Tüm postları getir
        [HttpGet]
        public async Task<IActionResult> GetAllMyPosts()
        {
            var posts = await _context.MyPosts
                .Include(p => p.Profile)
                .ToListAsync();
            return Ok(posts);
        }

        //  2. Tek bir post getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMyPostById(int id)
        {
            var post = await _context.MyPosts
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        //  3. Post oluştur (resimleri URL olarak gönder)
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] MyPost post)
        {
            _context.MyPosts.Add(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        //  4. wwwroot/uploads içine resim yükle
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files uploaded.");

            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            List<string> uploadedUrls = new();

            foreach (var file in files)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var url = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
                uploadedUrls.Add(url);
            }

            return Ok(new { imageUrls = uploadedUrls });
        }

        //  5. Post güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMyPost(int id, [FromBody] MyPost updatedPost)
        {
            if (id != updatedPost.Id)
                return BadRequest();

            _context.MyPosts.Update(updatedPost);
            await _context.SaveChangesAsync();
            return Ok(updatedPost);
        }

        // 6. Post sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyPost(int id)
        {
            var post = await _context.MyPosts.FindAsync(id);
            if (post == null)
                return NotFound();

            _context.MyPosts.Remove(post);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
