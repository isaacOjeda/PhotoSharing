using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using PhotoSharing.WindowsPhone.UploadService;

namespace PhotoSharing.WindowsPhone
{
    public partial class ImagePicker : PhoneApplicationPage
    {
        /// <summary>
        /// Task para seleccionar una imagen
        /// </summary>
        PhotoChooserTask photoChooserTask;
        /// <summary>
        /// Id del código QR que se leyó
        /// </summary>
        public string QrId { get; set; }
        /// <summary>
        /// Init del Task
        /// </summary>
        public ImagePicker()
        {
            InitializeComponent();

            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.ShowCamera = true;
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            photoChooserTask.Show();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.QrId = NavigationContext.QueryString["qr"];

            base.OnNavigatedTo(e);
        }
        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                byte[] imageBytes = new byte[e.ChosenPhoto.Length];
                e.ChosenPhoto.Read(imageBytes, 0, imageBytes.Count());

                string imageBase64 = Convert.ToBase64String(imageBytes);

                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                selectedImage.Source = bmp;

                UploadPhotosSoapClient proxy = new UploadPhotosSoapClient();
                proxy.UploadCompleted += proxy_UploadCompleted;

                proxy.UploadAsync(imageBase64, this.QrId);
            }
        }

        void proxy_UploadCompleted(object sender, UploadCompletedEventArgs e)
        {
            MessageBox.Show("Resultado: " + e.Result);
        }
    }
}