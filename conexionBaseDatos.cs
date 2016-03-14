using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AngularMVC
{
    public class conexionBaseDatos
    {
        public string user;
        public string pass;

        public SqlConnection MiConexion;


        public void conectar(string usuario, string password)
        {
            user = usuario;
            pass = password;

            MiConexion = new SqlConnection("Data Source=NAHUN-PC\\SQLEXPRESS;Initial Catalog=master;User ID='" + user + "';Password='" + pass + "'");
            MiConexion.Open();

        }

        public void EjecutarSQL(String Query)
        {
            SqlCommand MiComando = new SqlCommand(Query, this.MiConexion);
            MiComando.ExecuteNonQuery();

        }

        public SqlDataReader EjecutarSQL2(String Query)
        {
            SqlCommand MiComando = new SqlCommand(Query, this.MiConexion);
            return MiComando.ExecuteReader();
        }

        public void Desconectar()
        {
            MiConexion.Close();
        }


    }
}