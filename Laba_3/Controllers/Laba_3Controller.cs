using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Laba_3.Controllers
{
    public class HomeController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string action = requestContext.RouteData.Values["action"].ToString();
            int id = -1;
            if (requestContext.RouteData.Values["id"] != null)
            {
                bool bool_id = Int32.TryParse(requestContext.RouteData.Values["id"].ToString(), out id);
            }

            if (action == "start" && id == 0)
            {
                requestContext.HttpContext.Response.Redirect("/Data_Person/Person");
            }
            else
            {
                requestContext.HttpContext.Response.Write("Ошибка. ");
                requestContext.HttpContext.Response.Write("URL: " + requestContext.HttpContext.Request.Url.ToString());
            }
        }
    }

    public class Data_PersonController : Controller
    {
        public ActionResult Person()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Person(string name, string Age, int? id_Person, string info, bool agree)
        {
            if (id_Person != null)
            {
                ViewBag.Name = name;
                ViewBag.Age = Age;
                ViewBag.Gender = Request.Form["gender"];
                ViewBag.Id = id_Person.Value;
                ViewBag.Info = info;
                ViewBag.Agree = agree;
                return View("Result");
            }
            else
            {
                return RedirectToAction("Person");
            }
        }
        public ActionResult Result()
        {
            return View();
        }
    }

}