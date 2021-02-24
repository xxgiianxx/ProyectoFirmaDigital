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
    public partial class MantenimientoPlanes : System.Web.UI.Page
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
        public static eAjax fnListaPlanes()
        {

            eAjax oAjax = new eAjax();
            PlanesDAO dao = new PlanesDAO();
            string iresult = dao.fnListaPlanes();

            oAjax.iTipoResultado = 1;
            oAjax.sValor1 = iresult;
            return oAjax;
        }

        //Codigo Funcionando
        //UploadFTP(@"C:\DATOSCLIENTE.xlsx", "ftp://ftp.site4now.net/", "xxeguxx-001", "tornadesco.1");
        public static void UploadFTP(string FilePath, string RemotePath, string Login, string Password)
        { 
            var vresultas = @AppDomain.CurrentDomain.BaseDirectory + "Documentos\\" +"prueba.txt";
            //FilePath, FileMode.Open, FileAccess.Read, FileShare.Read
            using (FileStream fs = new FileStream(vresultas, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
               

                //string url = Path.Combine(RemotePath, Path.GetFileName(FilePath));
                string url = Path.Combine(RemotePath, Path.GetFileName(vresultas));

                // Creo el objeto ftp
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(url);

                // Fijo las credenciales, usuario y contraseña
                ftp.Credentials = new NetworkCredential("firmante", "tornadesco.1");

                // Le digo que no mantenga la conexión activa al terminar.
                ftp.KeepAlive = false;

                // Indicamos que la operación es subir un archivo...
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                // … en modo binario … (podria ser como ASCII)
                ftp.UseBinary = true;

                // Indicamos la longitud total de lo que vamos a enviar.
                ftp.ContentLength = fs.Length;

                // Desactivo cualquier posible proxy http.
                // Ojo pues de saltar este paso podría usar 
                // un proxy configurado en iexplorer
                ftp.Proxy = null;

                // Pongo el stream al inicio
                fs.Position = 0;

                // Configuro el buffer a 2 KBytes
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];

                int contentLen;

                // obtener el stream del socket sobre el que se va a escribir.
                using (Stream strm = ftp.GetRequestStream())
                {
                    // Leer del buffer 2kb cada vez
                    contentLen = fs.Read(buff, 0, buffLength);

                    // mientras haya datos en el buffer ….
                    while (contentLen != 0)
                    {
                        // escribir en el stream de conexión
                        //el contenido del stream del fichero
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                }
            }
        }


        //public static eArchivo CrearArchivo(string sRuta, string sdocumento)
        //{
        //    //eArchivo archivo = new eArchivo();
        //    archivo.sRuta = "C:\\DropX\\Dropbox\\DOC\\" + sRuta;

        //    //C:\\Users\\Administrador\\Dropbox\\DOC\\
        //    var vresultas = @AppDomain.CurrentDomain.BaseDirectory + "Documentos\\" + sdocumento;
        //    archivo.sArchivo = Convert.ToBase64String(File.ReadAllBytes(vresultas));
        //    var url = $"http://192.168.10.2/ApiArchivo/apiArchivo/Archivo/Crear";
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    string json = "";
        //    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        //    javaScriptSerializer.MaxJsonLength = 500000000;
        //    json = javaScriptSerializer.Serialize(archivo);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    request.Accept = "application/json";

        //    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        //    {
        //        streamWriter.Write(json);
        //        streamWriter.Flush();
        //        streamWriter.Close();
        //    }
        //    try
        //    {
        //        using (WebResponse response = request.GetResponse())
        //        {
        //            using (Stream strReader = response.GetResponseStream())
        //            {
        //                if (strReader == null) return archivo;
        //                using (StreamReader objReader = new StreamReader(strReader))
        //                {
        //                    string responseBody = objReader.ReadToEnd();
        //                    //Do something with responseBody
        //                    Console.WriteLine(responseBody);
        //                    //archivo = javaScriptSerializer.Deserialize<eArchivo>(responseBody);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        archivo = new eArchivo();
        //        archivo.sResultado = ex.Message;
        //    }
        //    return archivo;
        //}

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