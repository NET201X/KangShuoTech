namespace VideoSource
{
    using System;
    using System.Drawing;

    public class CameraEventArgs : EventArgs
    {
        private System.Drawing.Bitmap bmp;

        public CameraEventArgs(System.Drawing.Bitmap bmp)
        {
            this.bmp = bmp;
        }

        public System.Drawing.Bitmap Bitmap
        {
            get
            {
                return this.bmp;
            }
        }
    }
}

