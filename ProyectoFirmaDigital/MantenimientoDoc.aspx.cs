using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFirmaDigital
{
    public partial class MantenimientoDoc : System.Web.UI.Page
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
                DocumentosDAO dao = new DocumentosDAO();
                string sresult = dao.fnListaTrabajadoresfirmantes(iIdEmpres);
                oeAjax.iTipoResultado = 1;
                oeAjax.sValor1 = sresult;
            }
            catch (Exception ex)
            {
                oeAjax.sMensajeError = ex.Message;

            }
            return oeAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
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
                DocumentosDAO dao = new DocumentosDAO();
                string sresult = dao.fnListaDocumento(iIdEmpres);
                oeAjax.iTipoResultado = 1;
                oeAjax.sValor1 = sresult;
            }
            catch (Exception ex)
            {
                oeAjax.sMensajeError = ex.Message;

            }
            return oeAjax;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnEliminaDocumento(int sCodigo,string sRuta) {
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
                DocumentosDAO dao = new DocumentosDAO();
               var result= dao.fnEliminaDocumento(sCodigo);
                if (result >= 1)
                {

                    DeleteFile("ftp://ftp.site4now.net"+ sRuta, "xxeguxx-001", "tornadesco.1");
                    oeAjax.iTipoResultado = 1;
                }
                else {
                    oeAjax.iTipoResultado = -1;
                    oeAjax.sMensajeError ="Ocurrio Un Error Al Eliminar Documento";
                }


               
            }
            catch (Exception ex) {
                oeAjax.sMensajeError = ex.Message;

            }

            return oeAjax;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnExisteDocumentoPrincipal(string sRutaDocumento, string sNombreDocumento, string sTipoArchivo)
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
                var vDocument = sNombreDocumento + '.' + sTipoArchivo;

                var vresult = DownloadFile("ftp://ftp.site4now.net//documentos//cargados//", vDocument, "xxeguxx-001", "tornadesco.1", @AppDomain.CurrentDomain.BaseDirectory + "Documentos\\");
                oeAjax.iTipoResultado = 1;
                oeAjax.sValor1 = vresult;
            }
            catch (Exception ex)
            {
                oeAjax.sMensajeError = ex.Message;

            }

            return oeAjax;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static eAjax fnGuardaDocumento(string sNombreDocumento,string sDescripcion,int iTrabajador,string sNomDoc,string sFormato)
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
                //DownloadFile("ftp://ftp.site4now.net//documentos//cargados//", "AVISO.pdf", "xxeguxx-001", "tornadesco.1", @AppDomain.CurrentDomain.BaseDirectory + "Documentos\\");

                List<eSeguridad> lstSeguridad = new List<eSeguridad>();
                lstSeguridad = (List<eSeguridad>)HttpContext.Current.Session["leSeguridad"];
                int iIdTrabajador =Convert.ToInt32( lstSeguridad[0].iIdTrabajador);
                int iIdEmpres = Convert.ToInt32(lstSeguridad[0].iIdEmpresa);
                DocumentosDAO dao = new DocumentosDAO();
      
                var vruta = @AppDomain.CurrentDomain.BaseDirectory + "Documentos\\" + sNomDoc;
                var i= dao.fnRegistraDocumento(iIdEmpres, sNombreDocumento, sDescripcion, sFormato, iIdTrabajador, iTrabajador, "\\documentos\\cargados\\" + sNomDoc);
                if (i >= 1) { 
                   UploadFTP(vruta, "ftp://ftp.site4now.net/", "xxeguxx-001", "tornadesco.1");

                    File.Delete(vruta);
                }

                oeAjax.iTipoResultado = 1;
            }
            catch (Exception ex)
            {
                oeAjax.sMensajeError = ex.Message;

            }
            return oeAjax;
        }

        public static void UploadFTP(string FilePath, string RemotePath, string Login, string Password)
        {
            //var vresultas = @AppDomain.CurrentDomain.BaseDirectory + "Documentos\\" + "prueba.txt";
            //FilePath, FileMode.Open, FileAccess.Read, FileShare.Read
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {


                //string url = Path.Combine(RemotePath, Path.GetFileName(FilePath));
                string url = Path.Combine(RemotePath, Path.GetFileName(FilePath));

                // Creo el objeto ftp
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(url);

                // Fijo las credenciales, usuario y contraseña
                ftp.Credentials = new NetworkCredential("gestor", "tornadesco.1");

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

        public static string DownloadFile(string FtpUrl,string FileNameToDownload,
                        string userName, string password, string tempDirPath)
        {
            string file = "";
            string ResponseDescription = "";
            string PureFileName = new FileInfo(FileNameToDownload).Name;
            string DownloadedFilePath = tempDirPath + PureFileName;
            string downloadUrl = String.Format("{0}/{1}", FtpUrl, FileNameToDownload);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.Credentials = new NetworkCredential(userName, password);
            req.UseBinary = true;
            req.Proxy = null;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] buffer = new byte[2048];
                FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
                int ReadCount = stream.Read(buffer, 0, buffer.Length);
                while (ReadCount > 0)
                {
                    fs.Write(buffer, 0, ReadCount);
                    ReadCount = stream.Read(buffer, 0, buffer.Length);
                }
                ResponseDescription = response.StatusDescription;
                fs.Close();
                stream.Close();

                byte[] pdfBytes = File.ReadAllBytes(DownloadedFilePath);
                string pdfBase64 = Convert.ToBase64String(pdfBytes);

                File.Delete(DownloadedFilePath);
                file = pdfBase64;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return file;
            //file = Convert.ToBase64String(buffer);
        }


        public static void DeleteFile(string ftpURL, string UserName, string Password)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpURL);
            ftpRequest.Credentials = new NetworkCredential(UserName, Password);
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
            FtpWebResponse responseFileDelete = (FtpWebResponse)ftpRequest.GetResponse();
        }

    }
}