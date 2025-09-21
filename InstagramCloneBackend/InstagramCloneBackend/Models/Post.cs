namespace InstagramCloneBackend.Models
{
    public class Post
    {
        public string ProfileName { get; set; }
        public string PostDetail { get; set; }
        public List<string> Images { get; set; }
        public string TimeAgo { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int RepostCount { get; set; }
    }
}
