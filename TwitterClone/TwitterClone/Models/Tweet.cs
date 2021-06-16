using System;
using System.Collections.Generic;

#nullable disable

namespace TwitterClone.Models
{
    public partial class Tweet
    {
        public int TweetId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Person User { get; set; }
    }
}
