using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class FollowMap : EntityTypeConfiguration<Follow>
    {
        public FollowMap()
        {
            // Primary Key
            this.HasKey(t => t.FollowID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Follow");
            this.Property(t => t.FollowID).HasColumnName("FollowID");
            this.Property(t => t.UserOneID).HasColumnName("UserOneID");
            this.Property(t => t.UserTwoID).HasColumnName("UserTwoID");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Follows)
                .HasForeignKey(d => d.UserOneID);
            this.HasRequired(t => t.User1)
                .WithMany(t => t.Follows1)
                .HasForeignKey(d => d.UserTwoID);

        }
    }
}
