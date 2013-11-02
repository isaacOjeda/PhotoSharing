using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PhotoSharing.Tests.ServiceReference1;

namespace PhotoSharing.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] image = File.ReadAllBytes("1.jpg");

            UploadPhotosSoapClient soapClient = new UploadPhotosSoapClient();

            var result = soapClient.Upload(Convert.ToBase64String(image), "c240b8f4-5598-4d60-bf67-d649b489205c");
        }
    }
}
