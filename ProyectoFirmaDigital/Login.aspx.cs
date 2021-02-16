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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnValida(string sUsuario, string sClave)
        {


            eAjax oAjax = new eAjax();
            EmpresaDAOcs dao = new EmpresaDAOcs();

            string sresult = dao.fnValidaInicio(sUsuario, sClave);
            if (sresult != "")
            {

                var vsplit = sresult.Split('|');
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                context.Response.ContentType = "application/json";

                List<eSeguridad> leSeguridad = new List<eSeguridad>();
                eSeguridad oe = new eSeguridad();
                oe.strUsuario = vsplit[0];
                oe.strPassword = vsplit[1];
                oe.sPersonal = vsplit[2];
                oe.iIdrol = Convert.ToInt32(vsplit[3]);
                leSeguridad.Add(oe);
                HttpContext.Current.Session["leSeguridad"] = leSeguridad;
                oAjax.iTipoResultado = 1;


            }
            else {
                oAjax.iTipoResultado = -1;
                oAjax.sMensajeError = "Usuario Contrasena Incorrecto";

            }
           

            return oAjax;
        }

    }
}