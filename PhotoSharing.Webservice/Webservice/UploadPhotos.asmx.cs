using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PhotoSharing.Webservice.Services;
using Microsoft.AspNet.SignalR;
using PhotoSharing.Webservice.SignalR;

namespace PhotoSharing.Webservice.Webservice
{
    /// <summary>
    /// Descripción breve de UploadPhotos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class UploadPhotos : System.Web.Services.WebService
    {
        /// <summary>
        /// Endpoing que sube una imagen al servidor
        /// y la relaciona con un guid (código QR)
        /// </summary>
        /// <param name="imageBase64"></param>
        /// <returns></returns>
        [WebMethod]
        public bool Upload(string imageBase64,string qrCode)
        {
            // Se obtiene el directorio virtual en donde se encuentra la App
            string basePath = Server.MapPath("~/");
            // Se sube la imagen
            return PhotoServices.UploadImage(imageBase64, basePath, qrCode);
        }

        [WebMethod]
        public bool Toggle()
        {
            // aquí directamente mandamos un broadcast
            var hub = GlobalHost.ConnectionManager.GetHubContext<PhotoHub>();
            hub.Clients.All.toggleImage();
            return true;
        }
    }
}
