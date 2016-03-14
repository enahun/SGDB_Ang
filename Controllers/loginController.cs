using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC.Controllers
{
    public class loginController : Controller
    { 
        // GET: login
        public ActionResult Index()
        {
            return View();
            
        }

       
        
        
        //Funcion para que recibe el usuario de la base de dato e intenta logearse 
        //User:sa, Pass:root
        public bool logearse(string user,string pass) {

            conexionBaseDatos manejoDB = new conexionBaseDatos();

            try
            {
                manejoDB.conectar(user, pass);
                return true;
                
                
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
            

        }

        
        
    }
}