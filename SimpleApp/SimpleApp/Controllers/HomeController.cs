using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(HttpContext.Application["events"]);
        }

        [HttpPost]
        public ActionResult Index(Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null)
            {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
            return View(HttpContext.Application["events"]);
        }
    }
}