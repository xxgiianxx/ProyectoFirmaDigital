using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TrabajadorDAO
    {
        public string fnListaTrabajadores()
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaPlanes", conexion);
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

        public int fnRegistraTrabajador(int iIdTrabajador,
            string vNombre,
            string vApellidoPaterno,
            string vApellidoMaterno,
            string NroDocumento,
            string vClave,
            int vTelefono,
            int iIdRol,
            int iEstado)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistraPlan", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idTrabajador", SqlDbType.Int).Value = iIdTrabajador;
                cmd.Parameters.Add("@vNombre", SqlDbType.VarChar).Value = vNombre;
                cmd.Parameters.Add("@vApellidoPaterno", SqlDbType.VarChar).Value = vApellidoPaterno;
                cmd.Parameters.Add("@vApellidoMaterno", SqlDbType.VarChar).Value = vApellidoMaterno;
                cmd.Parameters.Add("@NroDocumento", SqlDbType.VarChar).Value = NroDocumento;
                cmd.Parameters.Add("@vClave", SqlDbType.VarChar).Value = vClave;
                cmd.Parameters.Add("@vTelefono", SqlDbType.Int).Value = vTelefono;
                cmd.Parameters.Add("@iIdRol", SqlDbType.Int).Value = iIdRol;
                cmd.Parameters.Add("@iEstado", SqlDbType.Int).Value = iEstado;
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

        public int fnActualizaTrabajador(int iIdTrabajador,
            string vNombre,
            string vApellidoPaterno,
            string vApellidoMaterno,
            string NroDocumento,
            string vClave,
            int vTelefono,
            int iIdRol,
            int iEstado)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizaPlan", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idTrabajador", SqlDbType.Int).Value = iIdTrabajador;
                cmd.Parameters.Add("@vNombre", SqlDbType.VarChar).Value = vNombre;
                cmd.Parameters.Add("@vApellidoPaterno", SqlDbType.VarChar).Value = vApellidoPaterno;
                cmd.Parameters.Add("@vApellidoMaterno", SqlDbType.VarChar).Value = vApellidoMaterno;
                cmd.Parameters.Add("@NroDocumento", SqlDbType.VarChar).Value = NroDocumento;
                cmd.Parameters.Add("@vClave", SqlDbType.VarChar).Value = vClave;
                cmd.Parameters.Add("@vTelefono", SqlDbType.Int).Value = vTelefono;
                cmd.Parameters.Add("@iIdRol", SqlDbType.Int).Value = iIdRol;
                cmd.Parameters.Add("@iEstado", SqlDbType.Int).Value = iEstado;
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


        public int fnEliminaTrabajador(int iIdTrabajador)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminaTrabajador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdTrabajador", SqlDbType.Int).Value = iIdTrabajador;
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
    }
}
