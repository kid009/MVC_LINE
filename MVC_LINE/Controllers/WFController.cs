using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_LINE.Models;
using MVC_LINE.DataAccess;
using Newtonsoft.Json;

namespace MVC_LINE.Controllers
{
    public class WFController : Controller
    {
        // GET: WF
        public ActionResult Index()
        {
            EmployeeDATA employeeDATA = new EmployeeDATA();
            RequestDATA requestDATA = new RequestDATA();

            if (Session["userid"] != null)
            {
                string userid = Session["userid"].ToString();

                EmployeeDAL employeeDAL = new EmployeeDAL();

                employeeDATA = employeeDAL.GetUserInfo(userid);

                if (employeeDATA != null)
                {
                    RequestDAL requestDAL = new RequestDAL();

                    List<RequestDATA> listData = requestDAL.GetRequestByUserId(userid);

                    requestDATA.LSTREQ = listData;

                    //แปลงเป็น JSON
                    string json = JsonConvert.SerializeObject(requestDATA);
                    requestDATA.JSON = json;

                    //แปลงเป็น OBJECT
                    requestDATA = JsonConvert.DeserializeObject<RequestDATA>(json);

                    if (requestDATA.LSTREQ.Count > 0)
                    {
                        ViewData["REQDATA"] = requestDATA.LSTREQ;
                    }
                }
            }

            return View(employeeDATA);
        }
    }
}