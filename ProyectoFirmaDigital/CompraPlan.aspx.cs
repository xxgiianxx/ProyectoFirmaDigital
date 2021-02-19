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
        public static eAjax fnActualizaPlan(int iCantidad)
        {

            eAjax oAjax = new eAjax();

            //milabelTotal.Text = "hhh";// Convert.ToString(iCantidad);

            oAjax.iTipoResultado = 1;

            return oAjax;
        }


    }
}