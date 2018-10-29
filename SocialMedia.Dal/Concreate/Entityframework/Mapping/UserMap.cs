using SocialMedia.Entity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SocialMedia.Dal.Concrete.Entityfamework.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.School)
                .HasMaxLength(50);

            this.Property(t => t.Company)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Hometown)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Birtdate).HasColumnName("Birtdate");
            this.Property(t => t.About).HasColumnName("About");
            this.Property(t => t.School).HasColumnName("School");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Hometown).HasColumnName("Hometown");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PictureLink).HasColumnName("PictureLink");
            this.Property(t => t.CoverPhotoLink).HasColumnName("CoverPhotoLink");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
