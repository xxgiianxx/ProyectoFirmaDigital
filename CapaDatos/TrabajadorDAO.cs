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

        public string fnListaRoles(int irol)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaRol", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdrol", SqlDbType.Int).Value = irol;
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

        public string fnListaTrabajadores(int idEmpresa)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            string sResult = "";
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListatrabajadores", conexion);
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

        public int fnRegistraTrabajador(string vNombre, string vApellidoPaterno, string vApellidoMaterno, string vDni, string vUsuario, string vClave, string vTelefono, int vRol,int iIdCargo,int iIdEmpresa)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spInsertaTrabajador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdEmpresa", SqlDbType.Int).Value = iIdEmpresa;
                cmd.Parameters.Add("@vNombre", SqlDbType.VarChar).Value = vNombre;
                cmd.Parameters.Add("@vApellidPaterno", SqlDbType.VarChar).Value = vApellidoPaterno;
                cmd.Parameters.Add("@vApellidoMaterno", SqlDbType.VarChar).Value = vApellidoPaterno;
                cmd.Parameters.Add("@vNroDocumento", SqlDbType.VarChar).Value = vDni;
                cmd.Parameters.Add("@vUsuario", SqlDbType.VarChar).Value = vUsuario;
                cmd.Parameters.Add("@vClave", SqlDbType.VarChar).Value = vClave;
                cmd.Parameters.Add("@vTelefono", SqlDbType.VarChar).Value = vTelefono;
                cmd.Parameters.Add("@iIdRol", SqlDbType.Int).Value = vRol;
                cmd.Parameters.Add("@iIdCargo", SqlDbType.Int).Value = iIdCargo;


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

        public int fnActualizaTrabajador(int iIdTrabajador,string vNombre, string vApellidoPaterno, string vApellidoMaterno, string vDni, string vUsuario, string vClave, string vTelefono, int iIdCargo)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizatrabajador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdTrabajador", SqlDbType.Int).Value = iIdTrabajador;
                cmd.Parameters.Add("@vNombre", SqlDbType.VarChar).Value = vNombre;
                cmd.Parameters.Add("@vApellidPaterno", SqlDbType.VarChar).Value = vApellidoPaterno;
                cmd.Parameters.Add("@vApellidoMaterno", SqlDbType.VarChar).Value = vApellidoPaterno;
                cmd.Parameters.Add("@vNroDocumento", SqlDbType.VarChar).Value = vDni;
                cmd.Parameters.Add("@vUsuario", SqlDbType.VarChar).Value = vUsuario;
                cmd.Parameters.Add("@vClave", SqlDbType.VarChar).Value = vClave;
                cmd.Parameters.Add("@vTelefono", SqlDbType.VarChar).Value = vTelefono;
                cmd.Parameters.Add("@iIdCargo", SqlDbType.Int).Value = iIdCargo;
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
                cmd = new SqlCommand("spEliminaTrabaajdor", conexion);
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
