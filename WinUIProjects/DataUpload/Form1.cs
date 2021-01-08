using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DataUpload
{
    public partial class Form1 : Form
    {
        // 取得屏幕分辨率的宽高
        private int SW = Screen.PrimaryScreen.Bounds.Width;
        private int SH = Screen.PrimaryScreen.Bounds.Height;

        public Form1()
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;

            //if (SW > 1400)
            //{
            //    this.SW -= 970;
            //    this.SH -= 480;
            //}
            //else
            //{
            //    this.SW -= 570;
            //    this.SH -= 380;
            //}
            
            this.ClientSize = new Size(SW, SH);
        }
    }
}
