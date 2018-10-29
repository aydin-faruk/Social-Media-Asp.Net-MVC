using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.CommentID);

            // Properties
            this.Property(t => t.Explain)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Comment");
            this.Property(t => t.CommentID).HasColumnName("CommentID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ShareID).HasColumnName("ShareID");
            this.Property(t => t.Explain).HasColumnName("Explain");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasRequired(t => t.Share)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.ShareID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.UserID);

        }
    }
}
