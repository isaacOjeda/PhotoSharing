using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhotoSharing.WindowsPhone.Resources;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace PhotoSharing.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        /// <summary>
        /// Timer
        /// </summary>
        private readonly DispatcherTimer timer;
        /// <summary>
        /// Texto leido de un código QR
        /// </summary>
        private string qrCodeText;
        /// <summary>
        /// Clase helper para leer el buffer de la camara
        /// y revisar si hay un código QR
        /// </summary>
        private PhotoCameraLuminanceSource luminance;
        /// <summary>
        /// Clase de ZXing para decodificar el código QR
        /// </summary>
        private QRCodeReader reader;
        /// <summary>
        /// Clase para mostrar la camara
        /// </summary>
        private PhotoCamera photoCamera;
        /// <summary>
        /// Init...
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
                  
            // Timer que se ejecutará cada 250 milisegundos
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(250);
            timer.Tick += (o, arg) => ScanPreviewBuffer();

        }
        /// <summary>
        /// Al estar visible la vista, se inicializará la cámara
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            photoCamera = new PhotoCamera();
            photoCamera.Initialized += OnPhotoCameraInitialized;
            previewVideo.SetSource(photoCamera);
            CameraButtons.ShutterKeyHalfPressed += (o, arg) => photoCamera.Focus();

            base.OnNavigatedTo(e);
        }
        /// <summary>
        /// Evento que se ejecuta al inicializarse la cámara.
        /// Inicializa el timer y la lectura del buffer de la cámara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
        {
            int width = Convert.ToInt32(photoCamera.PreviewResolution.Width);
            int height = Convert.ToInt32(photoCamera.PreviewResolution.Height);

            luminance = new PhotoCameraLuminanceSource(width, height);
            reader = new QRCodeReader();

            Dispatcher.BeginInvoke(() =>
            {
                previewTransform.Rotation = photoCamera.Orientation;
                timer.Start();
            });
        }
        /// <summary>
        /// Escanea el buffer de la cámara y si
        /// detectó un código QR lo manda a la vista ImagePicker
        /// </summary>
        private void ScanPreviewBuffer()
        {
            try
            {
                photoCamera.GetPreviewBufferY(luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                var result = reader.decode(binBitmap);
                if (result == null)
                {
                    return;
                }
                // Se leyó el código QR 
                this.qrCodeText = result.Text;
                this.Dispatcher.BeginInvoke(() =>
                    {
                        timer.Stop();
                        photoCamera.Dispose();
                        NavigationService.Navigate(new Uri(String.Format("/ImagePicker.xaml?qr={0}",qrCodeText), UriKind.Relative));
                    });
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al tratar de decodificar el código QR", "Photo Sharing", MessageBoxButton.OK);
            }
        }
    }
}