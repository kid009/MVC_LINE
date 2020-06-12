using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_LINE.Models;

namespace MVC_LINE.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            ViewBag.Title = "HTML Helper";

            if (TempData["usernameTemp"] != null && Session["usernameSession"] != null)
            {
                string usernameTemp = TempData["usernameTemp"].ToString();
                string usernameSession = Session["usernameSession"].ToString();

                var data = new Dictionary<string, UserDATA>()
                {
                    {"K001", new UserDATA{ USERID = "0001", Name = "Pongpoom"} },
                    {"K002", new UserDATA{ USERID = "0002", Name = "Tomas"} },
                    {"K003", new UserDATA{ USERID = "0003", Name = "Jinny"} }
                };

                ViewData["dataDic"] = data;
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDATA data)
        {
            ViewBag.Title = "HTML Helper";

            return View();
        }

    }
}