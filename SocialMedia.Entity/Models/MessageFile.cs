using System;
using System.Collections.Generic;

namespace SocialMedia.Entity.Models
{
    public partial class MessageFile
    {
        public int FileID { get; set; }
        public int MessageID { get; set; }
        public string Link { get; set; }
        public virtual Message Message { get; set; }
    }
}
