using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Models;

namespace TwitterClone.Models.Repositories
{
    public interface ITwitterRepository
    {
        bool isValid(Person person);
        void AddPerson(Person person);
        void Update(Person person);
        void Delete(Person person);
        Person GetPerson(string name);
        List<Person> GetPersons(string name);
        int GetTweetsCount(string UserId);
        int GetFollowers(string UserId);
        int GetFollowings(string UserId);
        void FollowPerson(Following follow);
        int GetCount();
        void AddTweet(Tweet tweet);
        IList<PersonTweetsAndFollowingDetails> GetDeatils(string Userid);
    }
}
