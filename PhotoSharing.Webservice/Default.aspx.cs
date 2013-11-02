using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhotoSharing.Webservice.Services;

namespace PhotoSharing.Webservice
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si es la primera vez que se carga, se genera un nuevo Id para el código QR y se guarda la 
            // imagen en el servidor
            if (!IsPostBack)
            {
                string qrCode = PhotoServices.CreateImage();
                this.qrImage.ImageUrl = PhotoServices.CreateQr(qrCode,Server.MapPath("~/"));
            }
        }
    }
}