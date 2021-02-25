using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProyectoFirmaDigital
{
    /// <summary>
    /// Descripción breve de FileLoad
    /// </summary>
    public class FileLoad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection oHttpFileCollection = context.Request.Files;
                HttpPostedFile oFile = oHttpFileCollection[0];
                //Set the Folder Path.
                string sCarpeta = context.Request["Carpeta"];
                string sRuta = context.Server.MapPath("~/" + sCarpeta + "/");

                //Set the File Name.
                string fileName = Path.GetFileName(oFile.FileName);

                //Save the File in Folder.
                oFile.SaveAs(sRuta + fileName);

                string sNewRuta = sRuta.Replace("\\", "¬");
                context.Response.ContentType = "texto/normal";
                context.Response.Write("1|" + fileName);
            }
            else
            {
                context.Response.ContentType = "texto/normal";
                context.Response.Write("2|");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}