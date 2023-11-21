using Assignment1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
       

        public ActionResult List()
        {
            var db = new Assignment1Entities();
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpGet]

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Add(Product product)
        {
            var db = new Assignment1Entities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {

            Assignment1Entities db = new Assignment1Entities();
            var data = db.Products.Find(ID);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Assignment1Entities db = new Assignment1Entities();
            var data = db.Products.Find(product.ID);
            data.Name = product.Name;
            data.Price = product.Price;
            data.CategoryID = product.CategoryID;
            data.Quantity = product.Quantity;

            db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult Delete(int ID)
        {
            Assignment1Entities db = new Assignment1Entities();

            var data = db.Products.Find(ID);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult OrderList()
        {
            var db = new Assignment1Entities();
            var data = db.Orders.ToList();
            return View(data);

           
        }
        public ActionResult CustomerList()
        {
            var db = new Assignment1Entities();
            var data = db.Users.Where(cus=>cus.UserType== "Customer").ToList();
            return View(data);
        }

        public ActionResult OrderDetails(int ID)  
        {
            Assignment1Entities db = new Assignment1Entities();
            var data = db.Orders.Find(ID);
            return View(data);
        
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login","Auth");
        }

        public ActionResult AcceptedOrderList()
        {

            var db = new Assignment1Entities();
            var data = db.Orders.ToList();

            return View(data);
        }

    }
}