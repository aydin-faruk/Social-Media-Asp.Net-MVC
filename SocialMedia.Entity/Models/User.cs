using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Entity.Models
{
    public partial class User
    {
        public User()
        {
            this.Comments = new List<Comment>();
            this.Follows = new List<Follow>();
            this.Follows1 = new List<Follow>();
            this.Likes = new List<Like>();
            this.Messages = new List<Message>();
            this.Messages1 = new List<Message>();
            this.Shares = new List<Share>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birtdate { get; set; }
        public string About { get; set; }
        public string School { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Hometown { get; set; }
        public string Phone { get; set; }

        [NotMapped]
        public string UserPicture
        {
            get
            {
                return string.IsNullOrEmpty(PictureLink) ? "/Content/empty.png" : PictureLink;
            }
        }

        public string PictureLink { get; set; }
        public string CoverPhotoLink { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
        public virtual ICollection<Follow> Follows1 { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
    }
}
