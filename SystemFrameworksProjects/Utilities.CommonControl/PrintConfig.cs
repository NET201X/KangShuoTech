namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing.Printing;

    [Serializable]
    public class PrintConfig
    {
        private int copies = 1;
        private string printName = string.Empty;
        private int xoffset;
        private int yoffset;
        private float zoom = 1f;

        public int Copies
        {
            get
            {
                return this.copies;
            }
            set
            {
                this.copies = value;
            }
        }

        public string PrintName
        {
            get
            {
                if (string.IsNullOrEmpty(this.printName))
                {
                    this.printName = new PrintDocument().PrinterSettings.PrinterName;
                }
                return this.printName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.printName = new PrintDocument().PrinterSettings.PrinterName;
                }
                else
                {
                    this.printName = value;
                }
            }
        }

        public int XOFFSET
        {
            get
            {
                return this.xoffset;
            }
            set
            {
                this.xoffset = value;
            }
        }

        public int YOFFSET
        {
            get
            {
                return this.yoffset;
            }
            set
            {
                this.yoffset = value;
            }
        }

        public float ZOOM
        {
            get
            {
                return this.zoom;
            }
            set
            {
                this.zoom = value;
            }
        }
    }
}

