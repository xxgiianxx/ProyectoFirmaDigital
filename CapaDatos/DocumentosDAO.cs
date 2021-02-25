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

        public string fnListaDocumento(int idEmpresa)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("[dbo].[spListaDocumento]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdEmpresa", SqlDbType.Int).Value = idEmpresa;
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


        public string fnListaDocumentoPendientes(int idEmpresa,int iIdTrabajador)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("[dbo].[spListaDocumentoPendientexTrabajador]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdEmpresa", SqlDbType.Int).Value = idEmpresa;
                cmd.Parameters.Add("@iIdTrabajador", SqlDbType.Int).Value = iIdTrabajador;
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

        public string fnListaTrabajadoresfirmantes(int iIdEmpresa)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaTrabajadoresFirmantes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdEmpresa", SqlDbType.Int).Value = iIdEmpresa;
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
                cmd = new SqlCommand("sp_RegistrarDocumento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdEmpresa", SqlDbType.VarChar).Value = iIdEmpresa;
                cmd.Parameters.Add("@vNombreDocumento", SqlDbType.VarChar).Value = sNombre;
                cmd.Parameters.Add("@vDescripcion", SqlDbType.VarChar).Value = sDescripcion;
                cmd.Parameters.Add("@vFormato", SqlDbType.VarChar).Value = sFormato;
                cmd.Parameters.Add("@iIdTrabajadorCarga", SqlDbType.Int).Value = iIdTrabajadorCarga;
                cmd.Parameters.Add("@iIdTrabajadorAsignado", SqlDbType.Int).Value = iIdTrabajadorAsignado;
                cmd.Parameters.Add("@vRutaOriginal", SqlDbType.VarChar).Value = sRutaOriginal;
                conexion.Open();
                sResult = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
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
