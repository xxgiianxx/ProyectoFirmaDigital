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
    public partial class CompraPlan : System.Web.UI.Page
    {
       public static Label milabel = null;
        public static Label milabelTotal = null;


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
                    milabel =  (Label)Master.FindControl("Nombre");
                    milabelTotal = (Label)Master.FindControl("TotalFirmas");
                    milabel.Text = lsSeguridad[0].sPersonal;
                }
            }



        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnListaSaldoFirma()
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
            try
            {
                List<eSeguridad> lstSeguridad = new List<eSeguridad>();
                lstSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
                string sUsuarioAuditoria = lstSeguridad[0].strUsuario;
                int iIdEmpres = Convert.ToInt32(lstSeguridad[0].iIdEmpresa);

               PlanesDAO dao = new PlanesDAO();
                int iresult = dao.fnListafirmaDisponibles(iIdEmpres);
                oeAjax.iTipoResultado = 1;
                oeAjax.sValor1 = Convert.ToString(iresult);
        

            }
            catch (Exception e)
            {
                oeAjax.iTipoResultado = 2;
                oeAjax.sMensajeError = "Ocurrió un error al momento de cargar la información por favor comuníquese con el administrador del sistema. </br>" + e.ToString();
            }

       

            return oeAjax;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnCompraPlan(int iIdPlan,int sMarca)
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
            try
            {
                List<eSeguridad> lstSeguridad = new List<eSeguridad>();
                lstSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
                string sUsuarioAuditoria = lstSeguridad[0].strUsuario;
                int iIdEmpres = Convert.ToInt32(lstSeguridad[0].iIdEmpresa);

                PlanesDAO dao = new PlanesDAO();
                int iresult = dao.fnListafirmaDisponibles(iIdEmpres);
                oeAjax.iTipoResultado = 1;
                oeAjax.sValor1 = Convert.ToString(iresult);


            }
            catch (Exception e)
            {
                oeAjax.iTipoResultado = 2;
                oeAjax.sMensajeError = "Ocurrió un error al momento de cargar la información por favor comuníquese con el administrador del sistema. </br>" + e.ToString();
            }



            return oeAjax;
        }

    }
}