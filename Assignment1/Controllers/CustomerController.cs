using Assignment1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public static class CartDetails  //make list
    {
       public static List<Product> addlist = new List<Product>();
    }
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Store()
        {
            var db = new Assignment1Entities();
            var data = db.Products.ToList();
            return View(data);
        }
       public ActionResult AddToCart(int ID)
        {
            Assignment1Entities db = new Assignment1Entities();
            var data = db.Products.Find(ID);
            data.Quantity = 1;
            CartDetails.addlist.Add(data);
            return RedirectToAction("Store");

            
        }


        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Auth");
        }
        public ActionResult Profiles()
        {
            Assignment1Entities db = new Assignment1Entities();
            var data = db.Users.Find(Session["ID"]);
            return View(data);
        }

         public ActionResult CustomerOrderlist()
        {
            var db = new Assignment1Entities();
            var data = db.Users.Find(Session["ID"]);
            return View(data);
        }

        public ActionResult Cart()
        {

            return View(CartDetails.addlist);
        }
        
        public ActionResult CheckOut()
        {
            var db = new Assignment1Entities();
            int Id = (int)Session["ID"];

            TemporaryOrder order = new TemporaryOrder();
            order.CustomerID = Id;
            order.Status = "Pending";
            db.TemporaryOrders.Add(order);
            db.SaveChanges();

            foreach (var product in CartDetails.addlist)
            {

                var tempOrder = new TempOrder()
                {
                    OrderID = order.ID,
                    ProductID = product.ID,
                    Price = product.Price,
                    Quantity = product.Quantity,
                };
                db.TempOrders.Add(tempOrder);
            }
            db.SaveChanges();
            return RedirectToAction("Orders");
        }
    }
}