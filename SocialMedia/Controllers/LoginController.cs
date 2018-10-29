using SocialMedia.Bll;
using SocialMedia.Dal.Concreate.Entityframework.Repository;
using SocialMedia.Entity.Models;
using SocialMedia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService = new UserManager(new EfUserRepository());
        readonly EfUserRepository _efUserRepository = new EfUserRepository();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                var entity = _efUserRepository.Login(user);
                if(entity != null)
                {
                    Session["SNUserID"] = entity.UserID;
                    Session["SNUserName"] = entity.UserName;
                    Session["SNName"] = entity.Name;
                    Session["SNSurName"] = entity.Surname;
                    Session["SNPicture"] = entity.UserPicture;

                    Session["SNShare"] = entity.Shares.Count;
                    Session["SNFollow"] = entity.Follows.Count;

                    return RedirectToAction("Index","index");    
                }
                return View();
            }
            catch(Exception e)
            {

            }

            return View();
        }

        public ActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SingUp(User user, string sifreTekrar)
        {
            user.Date = DateTime.Now;

            if (user.Password == sifreTekrar)
            {
                user.UserName = user.Mail;
                var newuser = _userService.Add(user);

                if(newuser!=null)
                {
                    Session["SNUserID"] = newuser.UserID;
                    Session["SNUserName"] = newuser.UserName;
                    Session["SNName"] = newuser.Name;
                    Session["SNSurName"] = newuser.Surname;
                    Session["SNPicture"] = newuser.UserPicture;

                    return RedirectToAction("Index", "index");
                }
            }
            return View();
        }
    }
}