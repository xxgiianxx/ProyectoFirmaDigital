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
    public partial class Index : System.Web.UI.MasterPage
    {
        public string sUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            { 
            
                List<eSeguridad> leSeguridad = new List<eSeguridad>();
            leSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
            if (leSeguridad != null) {

               string sIdRol = Convert.ToString(leSeguridad[0].iIdrol);
                    if (sIdRol == "1")
                    {

                        Panel milabel = (Panel)Master.FindControl("PanelPrincipal");
                        milabel.Visible = true;

                    }
                    else {

                        Panel milabel = (Panel)Master.FindControl("PanelPrincipal");
                        milabel.Visible = false;
                    }
          



             }
            
            }
            

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnListaPlanes()
        {
            eAjax oAjax = new eAjax();

            List<eSeguridad> lsSeguridad = new List<eSeguridad>();
            lsSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
            string sIdRol = Convert.ToString(lsSeguridad[0].iIdrol);
            oAjax.iTipoResultado = 1;

     
            oAjax.sValor1 = sIdRol;
            return oAjax;
        }


    }
}