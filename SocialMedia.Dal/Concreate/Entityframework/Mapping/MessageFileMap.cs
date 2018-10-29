using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class MessageFileMap : EntityTypeConfiguration<MessageFile>
    {
        public MessageFileMap()
        {
            // Primary Key
            this.HasKey(t => t.FileID);

            // Properties
            this.Property(t => t.Link)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("MessageFile");
            this.Property(t => t.FileID).HasColumnName("FileID");
            this.Property(t => t.MessageID).HasColumnName("MessageID");
            this.Property(t => t.Link).HasColumnName("Link");

            // Relationships
            this.HasRequired(t => t.Message)
                .WithMany(t => t.MessageFiles)
                .HasForeignKey(d => d.MessageID);

        }
    }
}
