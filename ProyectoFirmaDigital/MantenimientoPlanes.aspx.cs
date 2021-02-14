using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFirmaDigital
{
    public partial class MantenimientoPlanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Cargar codigo solo en la primera carga
            }

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnListaPlanes()
        {

            eAjax oAjax = new eAjax();
            PlanesDAO dao = new PlanesDAO();
            string sresult = dao.fnListaPlanes();
            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = sresult;

            return oAjax;
        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnRegistraPlanes(string sDescripcion,int iCantidad,decimal dPrecio)
        {

            eAjax oAjax = new eAjax();
            PlanesDAO dao = new PlanesDAO();
            int iresult = dao.fnRegistraPlan(sDescripcion, iCantidad, dPrecio);
            if (iresult > 0)
            {
              oAjax.iTipoResultado = 1;
            }
            else {
                oAjax.iTipoResultado= -1;
                oAjax.sMensajeError = "Ocurrio Un Error Al Registrar Plan";
            }

            return oAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnActualizaPlan(int iIdPlan, string sDescripcion, int iCantidad, decimal dPrecio)
        {

            eAjax oAjax = new eAjax();
            PlanesDAO dao = new PlanesDAO();
            int iresult = dao.fnActualizaPlan(iIdPlan, sDescripcion,iCantidad, dPrecio);
            if (iresult > 0)
            {
                oAjax.iTipoResultado = 1;
            }
            else
            {
                oAjax.iTipoResultado = -1;
                oAjax.sMensajeError = "Ocurrio Un Error Al Actualizar Plan";
            }

            return oAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnEliminaPlan(int iIdPlan)
        {

            eAjax oAjax = new eAjax();
            PlanesDAO dao = new PlanesDAO();
            int iresult = dao.fnEliminaPlan(iIdPlan);
            if (iresult > 0)
            {
                oAjax.iTipoResultado = 1;
            }
            else
            {
                oAjax.iTipoResultado = -1;
                oAjax.sMensajeError = "Ocurrio Un Error Al Eliminar Plan";
            }

            return oAjax;
        }

    }
}