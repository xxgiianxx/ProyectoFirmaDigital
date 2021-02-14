using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
   public class Conexion
    {

        #region "Patron Singleton"
        public static Conexion conexion = null;
        private Conexion() { }

        public static Conexion getInstance() {

            if (conexion == null) {
                conexion = new Conexion();
            }
            return conexion;
        
        }
        #endregion


        public SqlConnection ConexionBD(){

            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = GetConnectionString();

            return conexion;
        }

        public String GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["connBd"].ConnectionString;
        }


    }
}
