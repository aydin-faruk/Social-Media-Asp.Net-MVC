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
    public class MessageController : SecurityController
    {
        private readonly IFollowService _followService = new FollowManager(new EfFollowRepository());
        private readonly IMessageService _messageService = new MessageManager(new EfMessageRepository());

        // GET: Message
        public ActionResult Index(int? userId)
        {
            if(userId != null)
            {
                userId = Convert.ToInt32(Session["SNUserID"]);
            }

            List<Message> ins;
            ins = _messageService.GetAll(x => x.SenderID == userId);

            return View(ins);
        }

        public ActionResult Write()
        {
            
            IEnumerable<SelectListItem> items = _followService.GetFollow(Convert.ToInt32(Session["SNUserID"]))
              .Select(c => new SelectListItem
              {
                  Value = c.UserID.ToString(),
                  Text = c.Name + " " + c.Surname
              });

            ViewBag.Receiver = items;

            return View();
        }
        [HttpPost]
        public ActionResult Write(Message model)
        {
            model.Date = DateTime.Now;
            model.SenderID = Convert.ToInt32(Session["SNUserID"]);

            var newmessage = _messageService.Add(model);

            return RedirectToAction("Index");
        }

        public ActionResult Read(int messageId)
        {
            var m = _messageService.GetAll(x => x.MessageID == messageId).SingleOrDefault();

            return View(m);
        }
    }
}