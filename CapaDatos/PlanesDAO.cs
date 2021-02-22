using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class PlanesDAO
    {

        public string fnListaPlanes()
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

        public int fnRegistraPlan(string sDescripcion , int iCantidad,decimal dPrecio)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistraPlan", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@vDescripcion", SqlDbType.VarChar).Value = sDescripcion;
                cmd.Parameters.Add("@iCantidad", SqlDbType.Int).Value = iCantidad;
                cmd.Parameters.Add("@dPrecio", SqlDbType.Decimal).Value = dPrecio;
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

        public int fnActualizaPlan(int iIdPlan,string sDescripcion, int iCantidad, decimal dPrecio)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizaPlan", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdPlan", SqlDbType.Int).Value = iIdPlan;
                cmd.Parameters.Add("@vDescripcion", SqlDbType.VarChar).Value = sDescripcion;
                cmd.Parameters.Add("@iCantidad", SqlDbType.Int).Value = iCantidad;
                cmd.Parameters.Add("@dPrecio", SqlDbType.Decimal).Value = dPrecio;
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

        public int fnListafirmaDisponibles(int iIdEmpresa)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListaFirmasDisponibles", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdEmpresa", SqlDbType.Int).Value = iIdEmpresa;
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

        public int fnEliminaPlan(int iIdPlan)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            int sResult = -1;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminaPlan", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iIdPlan", SqlDbType.Int).Value = iIdPlan;
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
