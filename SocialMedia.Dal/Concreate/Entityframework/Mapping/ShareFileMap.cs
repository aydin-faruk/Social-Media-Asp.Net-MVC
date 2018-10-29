using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class ShareFileMap : EntityTypeConfiguration<ShareFile>
    {
        public ShareFileMap()
        {
            // Primary Key
            this.HasKey(t => t.FileID);

            // Properties
            this.Property(t => t.Link)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ShareFile");
            this.Property(t => t.FileID).HasColumnName("FileID");
            this.Property(t => t.ShareID).HasColumnName("ShareID");
            this.Property(t => t.Link).HasColumnName("Link");

            // Relationships
            this.HasRequired(t => t.Share)
                .WithMany(t => t.ShareFiles)
                .HasForeignKey(d => d.ShareID);

        }
    }
}
