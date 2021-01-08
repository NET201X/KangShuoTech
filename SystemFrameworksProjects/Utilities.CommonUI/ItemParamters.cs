namespace KangShuoTech.Utilities.CommonUI
{
    using System.Drawing;
    using System.Windows.Forms;

    public class ItemParamters
    {
        public ItemParamters(string txt, Image[] img)
        {
            this.Text = txt;
            this.Images = new ImageList();
            this.Images.ColorDepth = ColorDepth.Depth32Bit;
            this.Images.ImageSize = new Size(110, 127);

            foreach (Image image in img)
            {
                this.Images.Images.Add(image);
            }
        }

        public ImageList Images { get; set; }

        public string Text { get; set; }
    }
}

