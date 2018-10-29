using SocialMedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    public class PartialsController : SecurityController
    {
        // GET: Partials
        public PartialViewResult LeftProfil()
        {
            return PartialView();
        }
    }
}