using System;
using System.Collections.Generic;

namespace SocialMedia.Entity.Models
{
    public partial class ShareFile
    {
        public int FileID { get; set; }
        public int ShareID { get; set; }
        public string Link { get; set; }
        public virtual Share Share { get; set; }
    }
}
