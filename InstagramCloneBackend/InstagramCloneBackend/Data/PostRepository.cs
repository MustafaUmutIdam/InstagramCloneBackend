using InstagramCloneBackend.Models;

namespace InstagramCloneBackend.Data;

public class PostRepository
{
    public IEnumerable<Post> GetPosts()
    {
        return Enumerable.Range(0, 5).Select(index => new Post
        {
            ProfileName = $"User{index}",
            PostDetail = $"Gönderi detay metni {index}",
            Images = new List<string>
            {
                $"https://picsum.photos/400/300?random={index}",
                $"https://picsum.photos/400/300?random={index+10}"
            },
            TimeAgo = $"{index + 1} saat önce",
            LikeCount = 20 + index,
            CommentCount = 5 + index,
            RepostCount = 2 + index
        });
    }
}
