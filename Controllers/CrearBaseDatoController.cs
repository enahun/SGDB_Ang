using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC.Controllers
{
    public class CrearBaseDatoController : Controller
    {
        // GET: CrearBaseDato
        public ActionResult Index()
        {
            return View();
        }

        public string crearBaseDatos(string user , string pass,string nombre) {

            conexionBaseDatos manejoDB = new conexionBaseDatos();

            string Query = "create database " + nombre;

            try
            {
                manejoDB.conectar(user, pass);
                manejoDB.EjecutarSQL(Query);
                manejoDB.Desconectar();
                return "Ok";
            }
            catch (Exception)
            {
                return "Error";
                //throw;
            }
        }
    }
}