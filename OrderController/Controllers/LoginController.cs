using OrderController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderController.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(OrderController.Models.users usermodel)
        {

            using (order_control db = new order_control())
            {
                var user = db.users.Where(u => u.name == usermodel.name && u.password == usermodel.password).FirstOrDefault();

                if (user != null)
                {
                    Session["id"] = user.id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    usermodel.LoginErrorMessage = "name or password is not correct";
                    return View("Index", usermodel);
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}