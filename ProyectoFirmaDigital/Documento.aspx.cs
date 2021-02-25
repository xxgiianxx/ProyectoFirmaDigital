using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFirmaDigital
{
    public partial class Documento : System.Web.UI.Page
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

        public static eAjax fnListaDocumento()
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
                int iIdTrabajador = Convert.ToInt32(lstSeguridad[0].iIdTrabajador);
                DocumentosDAO dao = new DocumentosDAO();
                string sresult = dao.fnListaDocumentoPendientes(iIdEmpres,iIdTrabajador);
                oeAjax.iTipoResultado = 1;
                oeAjax.sValor1 = sresult;
            }
            catch (Exception ex)
            {
                oeAjax.sMensajeError = ex.Message;

            }
            return oeAjax;
        }








    }
}