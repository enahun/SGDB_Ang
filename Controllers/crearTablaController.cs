using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections;
using Newtonsoft.Json;

namespace AngularMVC.Controllers
{
    public class crearTablaController : Controller
    {
        // GET: crearTabla
        public ActionResult Index()
        {
            return View();
        }

        public string GetDataBases()
        {
            ArrayList dataBases = new ArrayList(); 

            conexionBaseDatos manejoDB = new conexionBaseDatos();
            string query = "SELECT name FROM master.dbo.sysdatabases";
            try
            {
                manejoDB.conectar("sa", "root");
                SqlDataReader res =  manejoDB.EjecutarSQL2(query);
                while (res.Read()) {
                    dataBases.Add(res.GetValue(0)) ;
                }

                var json = JsonConvert.SerializeObject(dataBases);
                return json;
            }
            catch (Exception)
            {
                return "false";
                
            }
        }

        public string GetDataTypes()
        {
            ArrayList dataTypes = new ArrayList();

            conexionBaseDatos manejoDB = new conexionBaseDatos();
            string query = "select name from sys.types";
            try
            {
                manejoDB.conectar("sa", "root");
                SqlDataReader res = manejoDB.EjecutarSQL2(query);
                while (res.Read())
                {
                    dataTypes.Add(res.GetValue(0));
                }

                var json = JsonConvert.SerializeObject(dataTypes);
                return json;
            }
            catch (Exception)
            {
                return "false";

            }
        }

        public string crearTabla(string baseDatos,string nombreTabla,string[][] campos)
        {
            string query =   "create table " + baseDatos +".dbo."+ nombreTabla + "(";
            string _campos = "";
            for(int  x = 0;x<campos.Length;x++)
            {
                string tmpTamano = campos[x][2] == "int" ? "" : "  (" + campos[x][3] + ")";
                string tmp = campos[x][1] + " " + campos[x][2] + tmpTamano;
                _campos = _campos + tmp + ",";
            }

            query = query + _campos + " )";

            conexionBaseDatos manejoDB = new conexionBaseDatos();
            manejoDB.conectar("sa", "root");
            manejoDB.EjecutarSQL(query);

            return "";
        }
    }



}