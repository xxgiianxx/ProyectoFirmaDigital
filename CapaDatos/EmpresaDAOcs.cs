using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class EmpresaDAOcs
    {


        public string fnListaEmpresa() {
          SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaEmpresa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                sResult = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                sResult = ex.Message;
            }
            finally {
                conexion.Close();
            }

            return sResult;

        }

        public string fnValidaInicio(string sUsuario,string sClave)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@vUsuario", SqlDbType.VarChar).Value = sUsuario;
                cmd.Parameters.Add("@vClave", SqlDbType.VarChar).Value = sClave;
                conexion.Open();

                sResult = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                sResult = ex.Message;
            }
            finally
            {
                conexion.Close();
            }

            return sResult;

        }


        public string fnListaUbigeo()
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("ListaUbigueo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                sResult = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                sResult = ex.Message;
            }
            finally
            {
                conexion.Close();
            }

            return sResult;

        }

    }
}
