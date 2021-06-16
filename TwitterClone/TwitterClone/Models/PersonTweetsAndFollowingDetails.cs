using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Models
{
    public class PersonTweetsAndFollowingDetails
    {
        public Person person { get; set; }
        public Following following  { get; set; } 
        public Tweet tweet { get; set; }
    }
}
