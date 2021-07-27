using BusinessLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjectPublic.Controllers
{
    public class TeamController : Controller
    {
        TeamValidator validationRules = new TeamValidator();
        TeamManager tm = new TeamManager(new EfTeamDal());
        Context c = new Context();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var team = tm.GetListTrue();
            return View(team);
        }
        [Authorize(Roles = "A,B")]
        public ActionResult ATeamList()
        {
            var team = tm.GetList();
            return View(team);
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult ATeamAdd()
        {
            return View();
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult ATeamAdd(Team s)
        {
            string filename = Path.GetFileName(Request.Files[0].FileName);
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            Random rand = new Random();
            filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 99999999).ToString() + uzanti;
            string way = "~/Image/Team/" + filename;
            s.Image = "/Image/Team/" + filename;

            ValidationResult results = validationRules.Validate(s);

            if (Request.Files.Count > 0)
            {
                if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
                {
                    Request.Files[0].SaveAs(Server.MapPath(way));
                    if (results.IsValid)
                    {
                        s.Status = true;
                        tm.TeamAdd(s);
                        return RedirectToAction("ATeamList");
                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }
                    }                    
                }
                else
                {
                    ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
                }
            }
            return View();
        }
        [Authorize(Roles = "A,B")]
        public ActionResult ATeamStatusDoFalse(int id)
        {
            var idteam = tm.GetByID(id);
            idteam.Status = false;
            tm.TeamDelete(idteam);
            return RedirectToAction("ATeamList");
        }
        [Authorize(Roles = "A,B")]
        public ActionResult ATeamStatusDoTrue(int id)
        {
            var idteam = tm.GetByID(id);
            idteam.Status = true;
            tm.TeamDelete(idteam);
            return RedirectToAction("ATeamList");
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]
        public ActionResult ATeamUpdate(int id)
        {
            var idteam = tm.GetByID(id);
            return View(idteam);
        }
        [Authorize(Roles = "A,B")]
        [HttpPost]
        public ActionResult ATeamUpdate(Team t)
        {
            ValidationResult result = validationRules.Validate(t);
            if (result.IsValid)
            {
                string ımage = c.Teams.Where(x => x.Id == t.Id).Select(z => z.Image).FirstOrDefault();
                t.Image = ımage;
                t.Status = false;
                tm.TeamUpdate(t);
                return RedirectToAction("ATeamList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();            
        }
    }
}