namespace KangShuoTech.Utilities.CommonControl
{
    using System;

    public class CommonSettings
    {
        public static int MillimeterConvertPixel(float Millimeter)
        {
            return (((int) ((((double) Millimeter) / 25.4) * 96.0)) + 1);
        }

        public static float PixelConvertMillimeter(float Pixel)
        {
            return (float) ((((double) Pixel) / 96.0) * 25.3999996185303);
        }
    }
}

