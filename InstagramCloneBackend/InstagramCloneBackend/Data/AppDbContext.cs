using InstagramCloneBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace InstagramCloneBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }  // Tablo adı Posts
        public DbSet<Story> Stories { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<MyPost> MyPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);

                // Images alanını JSON string olarak sakla
                entity.Property(p => p.Images)
                      .HasConversion(
                          v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                          v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                      );
            });

            modelBuilder.Entity<MyPost>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Images)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)!
                    );

                // Foreign key bağlantısı
                entity.HasOne(p => p.Profile)
                      .WithMany()
                      .HasForeignKey(p => p.ProfileId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }


    }
}
