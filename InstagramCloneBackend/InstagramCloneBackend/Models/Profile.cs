namespace InstagramCloneBackend.Models
{
    public class Profile
    {
        public int Id { get; set; }  // Identity column, DB otomatik atar
        public string Username { get; set; } = string.Empty;   // kullanıcı adı
        public string FullName { get; set; } = string.Empty;   // isim
        public int PostCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public string Bio { get; set; } = string.Empty;        // biyografi
        public string ProfileNote { get; set; } = string.Empty; // profil notu
    }
}
