using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC.Controllers
{
    public class HomeController : Controller
    {




        // GET: Home
        public ActionResult Index()
        {
            return View();
            //return PartialView();
        }

        /*public JsonResult GetProducts() {

            var db = new ProductosDBEntities();
            var products = db.Productos.ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }*/

       



    }
}