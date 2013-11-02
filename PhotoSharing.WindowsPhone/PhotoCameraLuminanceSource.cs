using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing;

namespace PhotoSharing.WindowsPhone
{
    /// <summary>
    /// Clase que utiliza la librería ZXing, usada para leer bytes del buffer de 
    /// la cámara
    /// </summary>
    public class PhotoCameraLuminanceSource : LuminanceSource
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] PreviewBufferY { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public PhotoCameraLuminanceSource(int width, int height)
            : base(width, height)
        {
            PreviewBufferY = new byte[width * height];
        }
        /// <summary>
        /// 
        /// </summary>
        public override byte[] Matrix
        {
            get { return (byte[])(Array)PreviewBufferY; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public override byte[] getRow(int y, byte[] row)
        {
            if (row == null || row.Length < Width)
            {
                row = new byte[Width];
            }

            for (int i = 0; i < Height; i++)
                row[i] = (byte)PreviewBufferY[i * Width + y];

            return row;
        }
    }
}
