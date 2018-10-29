using SocialMedia.Dal.Concrete.Entityfamework.Mapping;
using SocialMedia.Entity.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SocialMedia.Dal.Concrete.Entityfamework.Context
{
    public partial class SocialMediaDbContext : DbContext
    {
        static SocialMediaDbContext()
        {
            Database.SetInitializer<SocialMediaDbContext>(null);
        }

        public SocialMediaDbContext()
            : base("Name=SocialMediaDbContext")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageFile> MessageFiles { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<ShareFile> ShareFiles { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new FollowMap());
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new MessageFileMap());
            modelBuilder.Configurations.Add(new ShareMap());
            modelBuilder.Configurations.Add(new ShareFileMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
