using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PhotoSharing.Webservice.SignalR
{
    public class PhotoHub : Hub
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public void SendUrl(string url)
        {
            Clients.All.onImageUploaded(url);
        }
    }
}