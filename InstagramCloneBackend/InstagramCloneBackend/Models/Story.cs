namespace InstagramCloneBackend.Models
{
    public class Story
    {
        public int Id { get; set; }  // DB otomatik atar
        public string ProfileName { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public bool IsMine { get; set; } = false;
        public bool HasStory { get; set; } = true;
    }
}
