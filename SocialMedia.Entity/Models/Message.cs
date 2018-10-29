using System;
using System.Collections.Generic;

namespace SocialMedia.Entity.Models
{
    public partial class Message
    {
        public Message()
        {
            this.MessageFiles = new List<MessageFile>();
        }

        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int Receiver { get; set; }
        public string Explain { get; set; }
        public System.DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<MessageFile> MessageFiles { get; set; }
    }
}
