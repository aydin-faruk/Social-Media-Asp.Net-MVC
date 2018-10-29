using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => t.MessageID);

            // Properties
            this.Property(t => t.Explain)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Message");
            this.Property(t => t.MessageID).HasColumnName("MessageID");
            this.Property(t => t.SenderID).HasColumnName("SenderID");
            this.Property(t => t.Receiver).HasColumnName("Receiver");
            this.Property(t => t.Explain).HasColumnName("Explain");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.SenderID);
            this.HasRequired(t => t.User1)
                .WithMany(t => t.Messages1)
                .HasForeignKey(d => d.Receiver);

        }
    }
}
