using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Models.Repositories;
using TwitterClone.Models;
using Microsoft.AspNetCore.Http;

namespace TwitterClone.Controllers
{
    public class PersonController : Controller
    {
        ITwitterRepository _repository = null;
        public PersonController(ITwitterRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Search(string SearchName)
        {
            List<Person> persons = _repository.GetPersons(SearchName);
            if(persons.Count > 0)
            {
                return View(persons);
            }
            else
            {
                ViewBag.Message = "No record found";
                return RedirectToAction("HomePage", "twitter");
            }
        }
        [HttpGet]
        public IActionResult SearchResults(string id)
        {
            ViewBag.Uname = HttpContext.Session.GetString("Pid");
            Person person = _repository.GetPerson(id);
            if(person != null)
            {
                int Fid = _repository.GetCount();
                if(Fid == 0)
                {
                    Fid = 1;
                }
                else
                {
                    Fid += 1;
                }
                Following following = new Following() { Id = Fid, UserId = ViewBag.Uname, FollowingId = person.UserId };
                _repository.FollowPerson(following);
                return RedirectToAction("HomePage", "Twitter");
            }
            else
            {
                ViewBag.Message = "Not Followed";
                return RedirectToAction("HomePage", "Twitter");
            }
        }

        public IActionResult Tweet(string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                ViewBag.Uname = HttpContext.Session.GetString("Pid");
                Tweet tweet = new Tweet() { UserId = ViewBag.Uname, Message = message, CreatedDate = DateTime.Now };
                _repository.AddTweet(tweet);
                return RedirectToAction("HomePage", "Twitter");
            }
            else
            {
                ViewBag.ErrMessage = "Message is Empty";
                return RedirectToAction("HomePage", "Twitter");
            }
        }

        public IActionResult Edit()
        {
            string id = HttpContext.Session.GetString("Pid");
            Person person = _repository.GetPerson(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            _repository.Update(person);
            return RedirectToAction("HomePage", "Twitter");
        }
    }
}
