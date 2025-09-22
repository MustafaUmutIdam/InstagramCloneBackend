namespace InstagramCloneBackend.Models
{
    public class Post
    {
        public int Id { get; set; }  // Identity column, DB otomatik atar
        public string ProfileName { get; set; } = string.Empty;
        public string PostDetail { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new(); // JSON string olarak DB’de saklanacak
        public string TimeAgo { get; set; } = string.Empty;
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int RepostCount { get; set; }
    }
}
