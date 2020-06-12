using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_LINE.Models;
using MVC_LINE.DataAccess;

namespace MVC_LINE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Title = "Login to WorkFlow";
            ViewBag.Head = "Welcome";

            UserDATA data = new UserDATA();
            data.USERID = "Please input Username";
            data.PASSWORD = "Please input Password";

            return View(data); 
        }

        [HttpPost]
        public ActionResult Index(UserDATA data)
        {
            ViewBag.Title = "Login to WorkFlow";
            ViewBag.Head = "Welcome";

            EmployeeDAL dal = new EmployeeDAL();

            bool checkLogin = dal.CheckLogin(data.USERID, data.PASSWORD);

            if (checkLogin == true)
            {
                TempData["usernameTemp"] = data.USERID;

                Session["userid"] = data.USERID;

                return RedirectToAction("Index", "WF");
            }
            else
            {
                data.USERID = "Please input Username";
                data.PASSWORD = "Please input Password";
            }

            return View(data);
        }

    }
}