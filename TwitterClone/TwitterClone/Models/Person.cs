using System;
using System.Collections.Generic;

#nullable disable

namespace TwitterClone.Models
{
    public partial class Person
    {
        public Person()
        {
            FollowingFollowingNavigations = new HashSet<Following>();
            FollowingUsers = new HashSet<Following>();
            Tweets = new HashSet<Tweet>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Following> FollowingFollowingNavigations { get; set; }
        public virtual ICollection<Following> FollowingUsers { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
