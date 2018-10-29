using SocialMedia.Bll;
using SocialMedia.Dal.Concreate.Entityframework.Repository;
using SocialMedia.Entity.Models;
using SocialMedia.Interfaces;
using SocialMedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    public class ProfilController : SecurityController
    {
        private readonly IShareService _shareService = new ShareManager(new EfShareRepository());
        private readonly IUserService _userService = new UserManager(new EfUserRepository());
        private readonly IFollowService _followService = new FollowManager(new EfFollowRepository());


        string FileImage(HttpPostedFileBase filesImage)
        {
            if (filesImage != null)
            {
                filesImage.SaveAs(Server.MapPath("~/Files/") + filesImage.FileName);
                string yol = "/Files/" + filesImage.FileName;
                return yol;
            }
            return null;
        }


        // GET: Profil
        public ActionResult Profil()
        {
            return View();
        }

        public ActionResult EditProfil(int userId)
        {
            var edituser = _userService.GetAll(x => x.UserID == userId).SingleOrDefault();
            return View(edituser);
        }

        [HttpPost]
        public ActionResult EditProfil(User model, IEnumerable<HttpPostedFileBase> image)
        {
            if (image != null)
            {
                foreach (var item in image)
                {
                    model.PictureLink = FileImage(item);
                }
            }

            var editprofil = _userService.Add(model);

            Session["SNUserID"] = editprofil.UserID;
            Session["SNUserName"] = editprofil.UserName;
            Session["SNName"] = editprofil.Name;
            Session["SNSurName"] = editprofil.Surname;
            Session["SNPicture"] = editprofil.UserPicture;

            Session["SNShare"] = editprofil.Shares.Count;
            Session["SNFollow"] = editprofil.Follows.Count;

            return RedirectToAction("Profil");
        }

        public PartialViewResult PartialShare()
        {
            List<Share> ins;
            ins = _shareService.GetAll(x => x.ShareID != 0);

            return PartialView(ins.Where(x => x.UserID == Convert.ToInt32(Session["SNUserID"])));
        }

        public PartialViewResult PartialFollow()
        {
            List<User> ins;
            ins = _followService.GetFollow(Convert.ToInt32(Session["SNUserID"]));

            return PartialView(ins);
        }

        public ActionResult DeleteFollow(int userId)
        {
            var deletefollow = _followService.Delete(userId); 

            return RedirectToAction("Profil");
        }

    }
}