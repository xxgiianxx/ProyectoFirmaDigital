using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;

namespace ProyectoFirmaDigital
{
    public partial class MantenimientoDocumentos : System.Web.UI.Page
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
        public static eAjax fnListaDocumentos() {

            eAjax oAjax = new eAjax();
            DocumentosDAO dao = new DocumentosDAO();
            string sresult = dao.fnListaDocumento();

            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = sresult;

            return oAjax;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnListaTrabajadores()
        {

            eAjax oAjax = new eAjax();
            DocumentosDAO dao = new DocumentosDAO();
            string sresult = dao.fnListaTrabajadores();

            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = sresult;

            return oAjax;
        }

    }
}