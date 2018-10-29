using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Utils
{
    public class SecurityController : System.Web.Mvc.Controller
    {
        // GET: Security
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["SNUserID"] == null)
            {

                filterContext.Result = new RedirectResult("~/Login/Login");

            }

            base.OnActionExecuting(filterContext);
        }
    }
}