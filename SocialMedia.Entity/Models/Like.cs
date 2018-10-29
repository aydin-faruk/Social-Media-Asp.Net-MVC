using System;
using System.Collections.Generic;

namespace SocialMedia.Entity.Models
{
    public partial class Like
    {
        public int LikeID { get; set; }
        public int UserID { get; set; }
        public int ShareID { get; set; }
        public System.DateTime Date { get; set; }
        public virtual Share Share { get; set; }
        public virtual User User { get; set; }
    }
}
