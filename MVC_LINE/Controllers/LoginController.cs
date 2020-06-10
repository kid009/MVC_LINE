using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_LINE.Models;

namespace MVC_LINE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Title = "Login to WorkFlow";
            ViewBag.Head = "Welcome";

            UserData data = new UserData();
            data.Username = "Please input Username";
            data.Password = "Please input Password";

            return View(data); 
        }

        [HttpPost]
        public ActionResult Index(UserData data)
        {
            ViewBag.Title = "Login to WorkFlow";
            ViewBag.Head = "Welcome";

            if (data.Username == "admin" && data.Password == "123456")
            {
                TempData["usernameTemp"] = data.Username;

                Session["usernameSession"] = data.Username;

                return RedirectToAction("Index", "Main");
            }
            else
            {
                data.Username = "Please input Username";
                data.Password = "Please input Password";
            }

            return View(data);
        }

    }
}