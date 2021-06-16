using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Models;

namespace TwitterClone.Models.Repositories
{
    public class TwitterRepository : ITwitterRepository
    {
        private TwitterDBContext _context;
        public TwitterRepository(TwitterDBContext context)
        {
            _context = context;
        }

        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void AddTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            _context.SaveChanges();
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
        }

        public void FollowPerson(Following follow)
        {
            _context.Followings.Add(follow);
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.Followings.Count();
        }

        public IList<PersonTweetsAndFollowingDetails> GetDeatils(string id)
        {
            using (_context)
            {
                List<Person> persons = _context.Persons.ToList();
                List<Tweet> tweets = _context.Tweets.ToList();
                List<Following> followings = _context.Followings.Where(item=>item.UserId==id).ToList();

                var details = (from t in tweets
                               join k in followings on t.UserId equals k.FollowingId
                               select new PersonTweetsAndFollowingDetails
                               {
                                   tweet = t
                               }).ToList();
                var selfdetails = (from item in tweets where item.UserId == id select new PersonTweetsAndFollowingDetails { tweet = item }).ToList();
                var results = details.Union(selfdetails);
                return results.ToList();
            }
        }

        public int GetFollowers(string UserId)
        {
            return _context.Followings.Where(item => item.FollowingId == UserId).Count();
        }

        public int GetFollowings(string UserId)
        {
            return _context.Followings.Where(item => item.UserId == UserId).Count();
        }

        public Person GetPerson(string name)
        {
            return _context.Persons.Find(name);
        }

        public List<Person> GetPersons(string name)
        {
            return _context.Persons.Where(temp => temp.FullName.Contains(name)).ToList();
        }

        public int GetTweetsCount(string UserId)
        {
            return _context.Tweets.Where(item => item.UserId == UserId).Count();
        }

        public bool isValid(Person person)
        {
            return _context.Persons.Any(temp => temp.UserId == person.UserId && temp.Password == person.Password);
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }
    }
}
