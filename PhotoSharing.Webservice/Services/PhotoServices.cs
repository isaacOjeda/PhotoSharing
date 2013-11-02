using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using PhotoSharing.Webservice.Data;
using System.Drawing;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using Microsoft.AspNet.SignalR;
using PhotoSharing.Webservice.SignalR;

namespace PhotoSharing.Webservice.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PhotoServices
    {
        /// <summary>
        /// Guarda la imagen en disco duro y crea un enlace para 
        /// guardarlo en la base de datos para despues mandarlo 
        /// a todos los clientes por SignalR
        /// </summary>
        /// <param name="imageBase64">Imagen en base 64</param>
        /// <param name="basePath">Path base</param>
        /// <param name="qrCode">Guid que almacenaba el código QR</param>
        /// <returns></returns>
        public static bool UploadImage(string imageBase64, string basePath,string qrCode)
        {
            bool isSuccess = true;
            // nombre del archivo
            string fileName = String.Format("Storage/{0}.bmp", qrCode);
            // ruta completa en donde se guardardá el archivo
            string filePath = Path.Combine(basePath, fileName);
            // Url que se enviará a los clientes para que descarguen la imagen
            string urlToSend = Path.Combine(ConfigurationManager.AppSettings["PhotoPath"], fileName);
            try
            {                
                PhotoData.SavePhotoFile(imageBase64, filePath);
                PhotoData.UpdatePhotoInfo(urlToSend, qrCode);                  
                // Se envía el URL a los clientes
                var hub = GlobalHost.ConnectionManager.GetHubContext<PhotoHub>();
                hub.Clients.All.onImageUploaded(urlToSend);
            }
            catch (Exception)
            {
                isSuccess = false;
                throw;
            }
            return isSuccess;
        }
        /// <summary>
        /// Crea un registro que estará en espera de una imagen para que se muestre
        /// </summary>
        /// <returns>Guid de la imagen en una cadena</returns>
        public static string CreateImage()
        {
            return PhotoData.InsertPhoto();
        }
        /// <summary>
        /// Utilizando la librería Gma.QrCodeNet creamos una nueva imagen en PNG 
        /// que será un código QR con el texto que se le de
        /// </summary>
        /// <param name="guid">Texto que tendrá el código QR</param>
        /// <param name="basePath">Base path</param>
        /// <returns>Regresa el URL en el que se podrá encontrar la imagen recien
        /// guardada</returns>
        public static string CreateQr(string guid,string basePath)
        {
            // Se crea un Stream que tendrá la imagen en JPG utilizando QrCodeNet
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode(guid);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(20, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            MemoryStream stream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream, new Point(100, 100));
            // Se crea un path donde se guardará el archivo en el disco duro
            string filePath = Path.Combine(basePath, String.Format("Storage/Qrs/{0}.png",guid));
            PhotoData.SaveQrImageFile(filePath, stream.ToArray());
            stream.Close();
            // Construimos el URL en el que el navegador podrá descargar la imagen
            return Path.Combine(ConfigurationManager.AppSettings["PhotoPath"], String.Format("Storage/Qrs/{0}.png",guid));
        }
    }
}