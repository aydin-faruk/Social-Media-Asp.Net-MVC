using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class ShareMap : EntityTypeConfiguration<Share>
    {
        public ShareMap()
        {
            // Primary Key
            this.HasKey(t => t.ShareID);

            // Properties
            this.Property(t => t.Explain)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Share");
            this.Property(t => t.ShareID).HasColumnName("ShareID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Explain).HasColumnName("Explain");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Shares)
                .HasForeignKey(d => d.UserID);

        }
    }
}
