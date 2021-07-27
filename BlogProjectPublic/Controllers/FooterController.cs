using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class FooterController : Controller
    {
        SettingManager sm = new SettingManager(new EfSettingDal());
        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            var setfot = sm.GetList();
            return PartialView(setfot);
        }
    }
}