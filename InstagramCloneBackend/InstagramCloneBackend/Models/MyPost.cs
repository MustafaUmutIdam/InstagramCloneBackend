using System.Text.Json.Serialization;

namespace InstagramCloneBackend.Models
{
    public class MyPost
    {
        public int Id { get; set; }

        // Foreign Key
        public int ProfileId { get; set; }

        // Navigation property (profil verilerine erişim için)
        [JsonIgnore]
        public Profile? Profile { get; set; }

        public string ProfileName { get; set; } = string.Empty;
        public string PostDetail { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new();
        public string TimeAgo { get; set; } = string.Empty;
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int RepostCount { get; set; }
    }
}
