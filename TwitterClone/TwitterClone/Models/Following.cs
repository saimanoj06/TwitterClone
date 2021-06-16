using System;
using System.Collections.Generic;

#nullable disable

namespace TwitterClone.Models
{
    public partial class Following
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FollowingId { get; set; }

        public virtual Person FollowingNavigation { get; set; }
        public virtual Person User { get; set; }
    }
}
