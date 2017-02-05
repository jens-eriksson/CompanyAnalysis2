using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyAnalysis2.Model;
using CompanyAnalysis2.WebApp.ViewModels;
using System.Web.Security;

namespace CompanyAnalysis2.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private CompanyAnalysis2Context db
        {
            get
            {
                CompanyAnalysis2Context context = new CompanyAnalysis2Context();
                context.Configuration.LazyLoadingEnabled = true;
                return context;
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            if(Request.IsAuthenticated == false)
                return View(new LoginViewModel());
            else
                return RedirectToAction("index", "company");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("index", "company");

            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Email == viewModel.Email);
                if (user != null)
                {
                    if (user.Password == viewModel.Password)
                    {
                        FormsAuthentication.SetAuthCookie(user.Id.ToString(), viewModel.RememberMe);
                        return RedirectToAction("index", "company");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Felaktigt användarnamn eller lösenord");
                        return View(viewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Användaren finns inte");
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("about", "help");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.Find(viewModel.Email);
                if (user == null)
                {
                    CompanyAnalysis2Context context = db;
                    user = new User();
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;
                    user.Email = viewModel.Email;
                    user.Password = viewModel.Password;
                    context.Users.Add(user);
                    context.SaveChanges();
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("index", "company");
                }
                else
                {
                    ModelState.AddModelError("Email", "En användare med denna e-postadress finns redan");
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string email)
        {
            email = Server.UrlDecode(email);
            User user = db.Users.Find(email);

            if (Request.IsAuthenticated == false || user == null || user.Email != User.Identity.Name)
                return RedirectToAction("index", "company");

            EditAccountViewModel viewModel = new EditAccountViewModel();
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditAccountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CompanyAnalysis2Context context = db;
                User user = context.Users.Find(viewModel.Email);
                if (user != null)
                {                    
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;
                    context.SaveChanges();
                }

                return RedirectToAction("index", "company");
            }
            return View(viewModel);
        }

        public void SetUserSetting(string email, string name, string value)
        {
            CompanyAnalysis2Context context = db;
            User user = context.Users.Find(email);
            if (user == null)
                return;
            UserSetting userSetting = user.UserSettings.Where(us => us.Name == name).FirstOrDefault();
            if (userSetting == null)
            {
                userSetting = new UserSetting();
                //userSetting.Email = email;
                userSetting.Name = name;
                context.UserSettings.Add(userSetting);
            }

            userSetting.Value = value;
            context.SaveChanges();
        }

        public string GetUserSetting(string email, string name)
        {
            string val = "null";
            UserSetting us = db.UserSettings.Find(email, name);
            if (us != null)
                val = us.Value;
            return val;
        }
    }
}
