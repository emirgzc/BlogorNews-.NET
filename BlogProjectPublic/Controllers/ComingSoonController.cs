using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    [AllowAnonymous]
    public class ComingSoonController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}