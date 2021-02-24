using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class DocumentosDAO
    {

        public string fnListaDocumento()
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaDocumento", conexion);
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

        public int fnRegistraDocumento(int iIdEmpresa, string sNombre, string sDescripcion, string sFormato, int iIdTrabajadorCarga, int iIdTrabajadorAsignado, string sRutaOriginal)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistraDocumento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdEmpresa", SqlDbType.VarChar).Value = iIdEmpresa;
                cmd.Parameters.Add("@vNombreDocumento", SqlDbType.Int).Value = sNombre;
                cmd.Parameters.Add("@vDescripcion", SqlDbType.Decimal).Value = sDescripcion;
                cmd.Parameters.Add("@vFormato", SqlDbType.VarChar).Value = sFormato;
                cmd.Parameters.Add("@iIdTrabajadorCarga", SqlDbType.Int).Value = iIdTrabajadorCarga;
                cmd.Parameters.Add("@iIdTrabajadorAsignado", SqlDbType.Decimal).Value = iIdTrabajadorAsignado;
                cmd.Parameters.Add("@vRutaOriginal", SqlDbType.Decimal).Value = sRutaOriginal;
                conexion.Open();
                sResult = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                sResult = -1;
            }
            finally
            {
                conexion.Close();
            }

            return sResult;

        }

        public int fnEliminaDocumento(int iIdDocumento)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminaDocumento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdDocumento", SqlDbType.Int).Value = iIdDocumento;
                conexion.Open();
                sResult = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                sResult = -1;
            }
            finally
            {
                conexion.Close();
            }

            return sResult;

        }


        public string fnListaTrabajadores()
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaTrabajadoresA", conexion);
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
