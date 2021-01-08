namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class CSelectItem
    {
        private ComboBox cmbSelect;
        private int maxBytesCount;

        public CSelectItem()
        {
            this.Other = "其他";
        }

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSelect.Text == this.Other)
            {
                this.Info.ReadOnly = false;
            }
            else
            {
                this.Info.Clear();
                this.Info.ReadOnly = true;
            }
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.Info.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.Info.BackColor = Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.Info.BackColor = Color.WhiteSmoke;
            }
        }

        public void TransInfo(string info, string other)
        {
            if (string.IsNullOrEmpty(info))
            {
                this.cmbSelect.SelectedIndex = 0;
            }
            else
            {
                int num;
                if (int.TryParse(info, out num))
                {
                    this.cmbSelect.SelectedIndex = num - 1;
                }
                this.Info.Text = other;
            }
        }

        public ComboBox CmbSelect
        {
            get
            {
                return this.cmbSelect;
            }
            set
            {
                this.cmbSelect = value;
                if (this.cmbSelect != null)
                {
                    this.cmbSelect.SelectedIndexChanged += new EventHandler(this.cmbSelect_SelectedIndexChanged);
                }
            }
        }

        public bool ErrorInput { get; set; }

        public TextBox Info { get; set; }

        public int MaxBytesCount
        {
            get
            {
                return this.maxBytesCount;
            }
            set
            {
                if (value > 0)
                {
                    this.maxBytesCount = value;
                    this.Info.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public string Name { get; set; }

        public string Other { get; set; }

        public string SelectValue
        {
            get
            {
                return Convert.ToString((int) (this.cmbSelect.SelectedIndex + 1));
            }
        }

        public string SelectValueEX
        {
            get
            {
                return this.Info.Text.Trim();
            }
        }
    }
}

