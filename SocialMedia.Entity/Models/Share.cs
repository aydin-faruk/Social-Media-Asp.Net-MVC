using System;
using System.Collections.Generic;

namespace SocialMedia.Entity.Models
{
    public partial class Share
    {
        public Share()
        {
            this.Comments = new List<Comment>();
            this.Likes = new List<Like>();
            this.ShareFiles = new List<ShareFile>();
        }

        public int ShareID { get; set; }
        public int UserID { get; set; }
        public string Explain { get; set; }
        public System.DateTime Date { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ShareFile> ShareFiles { get; set; }
    }
}
