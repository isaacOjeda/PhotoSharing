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
using System.Windows.Media;

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
        /// 
        /// </summary>
        private ApplicationBarIconButton toggleButton;
        /// <summary>
        /// 
        /// </summary>
        private bool flag;
        /// <summary>
        /// Init del Task
        /// </summary>
        public ImagePicker()
        {
            InitializeComponent();

            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.ShowCamera = true;
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);

            this.toggleButton = (ApplicationBarIconButton) this.ApplicationBar.Buttons[1];
            this.toggleButton.IsEnabled = false;
            this.flag = false;
            this.progressBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.progressBar.Visibility = System.Windows.Visibility.Collapsed;
            this.progressBar.IsIndeterminate = true;
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
                this.progressBar.Visibility = System.Windows.Visibility.Visible;
                this.toggleButton.IsEnabled = true;
                
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
            // ok            
            this.progressBar.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            UploadPhotosSoapClient soapClient = new UploadPhotosSoapClient();
            this.toggleButton.IsEnabled = false;
            this.flag = !this.flag;
            this.toggleButton.IconUri = this.flag ? new Uri("/Assets/AppBar/add.png", UriKind.Relative) : new Uri("/Assets/AppBar/minus.png", UriKind.Relative);            
            soapClient.ToggleCompleted += (o, args) =>
                {
                    this.toggleButton.IsEnabled = true;
                };

            soapClient.ToggleAsync();
        }
    }
}