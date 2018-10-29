using SocialMedia.Bll;
using SocialMedia.Dal.Concreate.Entityframework.Repository;
using SocialMedia.Entity.Models;
using SocialMedia.Entity.PocoModels;
using SocialMedia.Interfaces;
using SocialMedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{

    public class indexController : SecurityController
    {
        private readonly IShareService _shareService = new ShareManager(new EfShareRepository());
        private readonly IShareFileService _shareFileService = new ShareFileManager(new EfShareFileRepository());
        private readonly IUserService _userService = new UserManager(new EfUserRepository());
        private readonly IFollowService _followService = new FollowManager(new EfFollowRepository());
        private readonly ICommentService _commentService = new CommentManager(new EfCommentRepository());
        private readonly ILikeService _likeService = new LikeManager(new EfLikeRepository());

        string FileVideo(HttpPostedFileBase filesVideo)
        {
            if (filesVideo != null)
            {
                filesVideo.SaveAs(Server.MapPath("~/Files/Shares/Videos/") + filesVideo.FileName);
                string yol = "/Files/Shares/Videos/" + filesVideo.FileName;
                return yol;
            }
            return null;
        }

        string FileImage(HttpPostedFileBase filesImage)
        {
            if (filesImage != null)
            {
                filesImage.SaveAs(Server.MapPath("~/Files/Shares/Images/") + filesImage.FileName);
                string yol = "/Files/Shares/Images/" + filesImage.FileName;
                return yol;
            }
            return null;
        }

        public ActionResult Index()
        {  
            return View();
        }

        public PartialViewResult PartialShare()
        {
            List<Share> ins;
            ins = _shareService.GetAll(x=>x.ShareID!=0);

            return PartialView(ins);
        }

        public PartialViewResult PartialUsers()
        {
            List<PocoNoFollowUser> ins;
            ins = _userService.GetUsers(Convert.ToInt32(Session["SNUserID"]));

            return PartialView(ins);
        }

        [HttpPost]
        public PartialViewResult PartialUsers(int userId)
        {
            Follow newFollow = new Follow();

            newFollow.UserOneID = Convert.ToInt32(Session["SNUserID"]);
            newFollow.UserTwoID = userId;
            newFollow.Date = DateTime.Now; 

            var newFllw = _followService.Add(newFollow);

            return PartialView("Index");
        }


        [HttpPost]
        public ActionResult Share(Share model, IEnumerable<HttpPostedFileBase> image, IEnumerable<HttpPostedFileBase> video)
        {
            try
            {
                model.Date = DateTime.Now;
                model.UserID = Convert.ToInt32(Session["SNUserID"]);
                var newshare = _shareService.Add(model);

                ShareFile newFileI = new ShareFile();                 
                if (image != null)
                {
                    foreach(var item in image)
                    {
                        newFileI.ShareID = model.ShareID;
                        newFileI.Link = FileImage(item); 
                    }
                    _shareFileService.Add(newFileI);
                }

                ShareFile newFileV = new ShareFile();
                if (video != null)
                {
                    foreach (var item in video)
                    {
                        newFileV.ShareID = model.ShareID;
                        newFileV.Link = FileVideo(item);
                    }
                    _shareFileService.Add(newFileV);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {

            }   

            return View();
        }

        [HttpPost]
        public ActionResult Comment(Comment model)
        {
            try
            {
                model.Date = DateTime.Now;
                model.UserID = Convert.ToInt32(Session["SNUserID"]);
                var newcomment = _commentService.Add(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

            }

            return View();
        }

        public ActionResult Like(int shareId)
        {
            try
            {
                Like newLike = new Like();

                newLike.Date = DateTime.Now;
                newLike.UserID = Convert.ToInt32(Session["SNUserID"]);
                newLike.ShareID = shareId;
                                                                        
                var newL = _likeService.Add(newLike);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

            }

            return View();
        }
    }




}