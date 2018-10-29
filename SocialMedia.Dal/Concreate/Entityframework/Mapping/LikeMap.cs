using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class LikeMap : EntityTypeConfiguration<Like>
    {
        public LikeMap()
        {
            // Primary Key
            this.HasKey(t => t.LikeID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Like");
            this.Property(t => t.LikeID).HasColumnName("LikeID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ShareID).HasColumnName("ShareID");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasRequired(t => t.Share)
                .WithMany(t => t.Likes)
                .HasForeignKey(d => d.ShareID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Likes)
                .HasForeignKey(d => d.UserID);

        }
    }
}
