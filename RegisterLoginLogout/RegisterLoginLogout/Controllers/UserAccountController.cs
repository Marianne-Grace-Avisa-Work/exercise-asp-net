using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterLoginLogout.Models;

namespace RegisterLoginLogout.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }

        //Registration
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (UserAccountDBContext db = new UserAccountDBContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                using (UserAccountDBContext db = new UserAccountDBContext())
                {
                    var User = db.userAccount.Single(userAccount => userAccount.EmailAddress == account.EmailAddress && userAccount.Password == account.Password);
                    Session["UserID"] = User.UserID.ToString();
                    Session["FirstName"] = User.FirstName.ToString();
                    Session["LastName"] = User.LastName.ToString();
                    return RedirectToAction("LoggedIn");
                }
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (UserAccountDBContext db = new UserAccountDBContext())
            {
                var User = db.userAccount.FirstOrDefault(userAccount => userAccount.EmailAddress == user.EmailAddress && userAccount.Password == user.Password);
                if(User != null)
                {
                    Session["UserID"] = User.UserID.ToString();
                    Session["FirstName"] = User.FirstName.ToString();
                    Session["LastName"] = User.LastName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email Address and Password is wrong. Please try again.");
                }
            }
            return View();
        }

        //Logged In
        public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}