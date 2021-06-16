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
    public class TwitterController : Controller
    {
        ITwitterRepository _repository = null;
        public TwitterController(ITwitterRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Person person)
        {
            if (ModelState.IsValid)
            {
                person.JoinedDate = DateTime.Now;
                person.Active = true;
                _repository.AddPerson(person);
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }

        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Person person)
        {
            if (_repository.isValid(person))
            {
                HttpContext.Session.SetString("Pid", person.UserId);
                return RedirectToAction("HomePage", person);
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Credentials";
                return View();
            }
        }
        public IActionResult HomePage(Person person)
        {
            string name = HttpContext.Session.GetString("Pid");
            ViewBag.Uname = name;
            ViewBag.Count = _repository.GetTweetsCount(name);
            ViewBag.Followings = _repository.GetFollowings(name);
            ViewBag.Followers = _repository.GetFollowers(name);
            IList<PersonTweetsAndFollowingDetails> details = _repository.GetDeatils(name);
            return View(details);
        }
    }
}
