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
    public partial class MantenimientoEmpresas : System.Web.UI.Page
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
        public static eAjax fnListaEmpresas() {

            eAjax oAjax = new eAjax();
            EmpresaDAOcs dao = new EmpresaDAOcs();
            string sresult = dao.fnListaEmpresa();

            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = sresult;

            return oAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnListaUbigeo()
        {

            eAjax oAjax = new eAjax();
            EmpresaDAOcs dao = new EmpresaDAOcs();
            string sresult = dao.fnListaUbigeo();

            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = sresult;

            return oAjax;
        }




    }
}