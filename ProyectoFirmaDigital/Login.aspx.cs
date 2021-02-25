using CapaDatos;
using CapaEntidad;
using ProyectoFirmaDigital.Firma;
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
        public static eAjax  fnHola() {
            eAjax oAjax = new eAjax();

            var certificado = new Certificado(@"c:\demos\certificado.pfx");
            var firmante = new Firmante(certificado);
            firmante.Firmar(@"c:\demos\documento.pdf", @"c:\demos\documento-firmado.pdf");

            oAjax.iTipoResultado = 1;
            return oAjax;

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
                oe.iIdCargo = Convert.ToInt32(vsplit[4]);
                oe.iIdEmpresa = Convert.ToInt32(vsplit[5]);
                oe.sNombreEmpresa = Convert.ToString(vsplit[6]);
                oe.iIdTrabajador= Convert.ToInt32(vsplit[7]);
                leSeguridad.Add(oe);
                HttpContext.Current.Session["leSeguridad"] = leSeguridad;
                oAjax.sValor1 = vsplit[3]+'|'+ vsplit[4];
                oAjax.iTipoResultado = 1;


            }
            else {
                oAjax.iTipoResultado = -1;
                oAjax.sMensajeError = "Usuario Contrasena Incorrecto";

            }
           

            return oAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax CerrarSesion()
        {
            eAjax oeAjax = new eAjax();
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            context.Response.ContentType = "application/json";
            try
            {
                //var sesion = HttpContext.Current.Session["leSeguridad"];

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                oeAjax.iTipoResultado = 1;
            }
            catch (Exception e)
            {
                oeAjax.iTipoResultado = 2;
                oeAjax.sMensajeError = "Ocurrió un error al Cerrar Sesion por favor comuníquese con el administrador del sistema. </br>" + e.ToString();
            }
            return oeAjax;

        }

    }
}