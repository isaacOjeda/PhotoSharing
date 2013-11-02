using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using MySql.Data.MySqlClient;

namespace PhotoSharing.Webservice.Data
{
    /// <summary>
    /// Acceso a datos de fotos
    /// </summary>
    public class PhotoData
    {
        /// <summary>
        /// Actualiza en la base de datos el url de la nueva foto
        /// </summary>
        /// <param name="url">Url donde se encuentra la imagen</param>
        /// <param name="idPhoto">Id de la foto, que viene siendo el código QR escaneado</param>
        public static void UpdatePhotoInfo(string url,string idPhoto)
        {            
            using (MySqlConnection con = Database.GetDatabase())
            {
                MySqlCommand command = new MySqlCommand("UPDATE photos set url=@url where idPhotos=@idPhoto", con);

                command.Parameters.AddWithValue("@url", url);
                command.Parameters.AddWithValue("@idPhoto", idPhoto);

                command.ExecuteNonQuery();
            }            
        }
        /// <summary>
        /// Crea un nuevo registro y regresa un Guid
        /// que será usado para crear el código QR
        /// </summary>
        /// <returns>Guid en una cadena</returns>
        public static string InsertPhoto()
        {
            string guid = String.Empty;

            using (MySqlConnection con = Database.GetDatabase())
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO photos VALUES(@id,null)", con);
                guid = Guid.NewGuid().ToString();
                command.Parameters.AddWithValue("@id",guid);

                command.ExecuteNonQuery();
            }
            return guid;
        }
        /// <summary>
        /// Guarda una imagen que está en base64 en 
        /// el disco duro en formato BMP
        /// </summary>
        /// <param name="photoInBase64">Imagen convertida a base64</param>
        /// <param name="filePath">Ruta completa donde se guardará el archivo</param>
        public static void SavePhotoFile(string photoInBase64, string filePath)
        {
            // Se convierte a bytes y se guarda en un archivo
            byte[] imageBytes = Convert.FromBase64String(photoInBase64);            
            using (FileStream stream = new FileStream(filePath,FileMode.Create,FileAccess.ReadWrite))
            {
                stream.Write(imageBytes,0,imageBytes.Count());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="guid"></param>
        /// <param name="image"></param>
        public static void SaveQrImageFile(string filePath, byte[] image)
        {
            using (FileStream stream = new FileStream(filePath,FileMode.Create,FileAccess.ReadWrite))
            {
                stream.Write(image, 0, image.Count());
            }
        }
    }
}