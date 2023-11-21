using Assignment1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class AuthController : Controller
    {

        // GET: Auth


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(int id)
        {
            Assignment1Entities db = new Assignment1Entities();
            var data = db.Users.Find(id);

            if(data != null)
            {
                if(data.UserType == "Admin")
                {
                    Session["ID"] = id;

                    return RedirectToAction("List","Admin");
                }

                if(data.UserType == "Customer")
                {
                    Session["ID"]=id;
                    return RedirectToAction("Store", "Customer");
                }
            }

            else 
            {

                return View();
            }
            return View();
        }

        
    }
}