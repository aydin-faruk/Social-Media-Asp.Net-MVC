using System;
using System.Collections.Generic;

namespace SocialMedia.Entity.Models
{
    public partial class Follow
    {
        public int FollowID { get; set; }
        public int UserOneID { get; set; }
        public int UserTwoID { get; set; }
        public System.DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
