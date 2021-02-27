using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProyectoFirmaDigital
{
    public partial class MantenimientoTrabajadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["leSeguridad"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    List<eSeguridad> lsSeguridad = new List<eSeguridad>();
                    lsSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
                    Label milabel = (Label)Master.FindControl("Nombre");
                    milabel.Text = lsSeguridad[0].sPersonal;
                }
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnListaTrabajadores()
        {

            eAjax oAjax = new eAjax();
            TrabajadorDAO dao = new TrabajadorDAO();
            List<eSeguridad> lstSeguridad = new List<eSeguridad>();
            lstSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
            int idEmpresa = Convert.ToInt32(lstSeguridad[0].iIdEmpresa);
            string iresult = dao.fnListaTrabajadores(idEmpresa);

            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = iresult;
            return oAjax;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnListaroles()
        {

            eAjax oAjax = new eAjax();
            TrabajadorDAO dao = new TrabajadorDAO();

            List<eSeguridad> lstSeguridad = new List<eSeguridad>();
            lstSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
            string sUsuarioAuditoria = lstSeguridad[0].strUsuario;
            int iIdCargo = Convert.ToInt32(lstSeguridad[0].iIdrol);
            string iresult = dao.fnListaRoles(iIdCargo);
            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = iresult;
            return oAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnRegistraTrabajador(string vNombre,string vApellidoPaterno,string vApellidoMaterno,string vDni,string vUsuario,string vClave,string vTelefono,int vRol)
        {

            eAjax oeAjax = new eAjax();
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            context.Response.ContentType = "application/json";
            if (HttpContext.Current.Session["leSeguridad"] == null)
            {
                oeAjax.iTipoResultado = 99;
                oeAjax.sMensajeError = "Fin Session";
                return oeAjax;
            }

            eAjax oAjax = new eAjax();
            TrabajadorDAO dao = new TrabajadorDAO();
            List<eSeguridad> lstSeguridad = new List<eSeguridad>();
            lstSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
            string sUsuarioAuditoria = lstSeguridad[0].strUsuario;
            int iIdCargo = Convert.ToInt32(lstSeguridad[0].iIdCargo);
            int iIdempresa = Convert.ToInt32(lstSeguridad[0].iIdEmpresa);
            int iresult = dao.fnRegistraTrabajador(vNombre, vApellidoPaterno, vApellidoMaterno, vDni, vUsuario, vClave, vTelefono, vRol, iIdCargo, iIdempresa);
            if (iresult > 0)
            {
                oAjax.iTipoResultado = 1;

            }
            else
            {
                oAjax.iTipoResultado = -1;
                oAjax.sMensajeError = "Ocurrio Un Error Al Registrar Plan";
            }

            return oAjax;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnActualizaTrabajador(int iIdTrabajador,string vNombre, string vApellidoPaterno, string vApellidoMaterno, string vDni, string vUsuario, string vClave, string vTelefono, int vRol)
        {

            eAjax oeAjax = new eAjax();
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            context.Response.ContentType = "application/json";
            if (HttpContext.Current.Session["leSeguridad"] == null)
            {
                oeAjax.iTipoResultado = 99;
                oeAjax.sMensajeError = "Fin Session";
                return oeAjax;
            }

            eAjax oAjax = new eAjax();
            TrabajadorDAO dao = new TrabajadorDAO();
            List<eSeguridad> lstSeguridad = new List<eSeguridad>();
            lstSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
            string sUsuarioAuditoria = lstSeguridad[0].strUsuario;
            int iIdCargo = Convert.ToInt32(lstSeguridad[0].iIdCargo);
            int iIdempresa = Convert.ToInt32(lstSeguridad[0].iIdEmpresa);
            int iresult = dao.fnActualizaTrabajador(iIdTrabajador,vNombre, vApellidoPaterno, vApellidoMaterno, vDni, vUsuario, vClave, vTelefono, iIdCargo);
            if (iresult > 0)
            {
                oAjax.iTipoResultado = 1;

            }
            else
            {
                oAjax.iTipoResultado = -1;
                oAjax.sMensajeError = "Ocurrio Un Error Al Registrar Trabajador";
            }

            return oAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnEliminaTrabajador(int iIdTrabajador)
        {

            eAjax oAjax = new eAjax();
            TrabajadorDAO dao = new TrabajadorDAO();
            int iresult = dao.fnEliminaTrabajador(iIdTrabajador);
            if (iresult > 0)
            {
                oAjax.iTipoResultado = 1;
            }
            else
            {
                oAjax.iTipoResultado = -1;
                oAjax.sMensajeError = "Ocurrio Un Error Al Eliminar Trabajador";
            }

            return oAjax;
        }


    }
}