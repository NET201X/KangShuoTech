namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class CSingleItem
    {
        private TextBox _info;
        private RadioButton _Unusual;
        private RadioButton _Usual;
        private decimal m_maxValue;
        private int maxBytesCount;
        private bool UState;
        private Action<bool> usual_onchecked;

        public CSingleItem()
        {
        }

        public CSingleItem(Action<bool> act)
        {
            this.usual_onchecked = act;
        }

        private void _info_TextChanged(object sender, EventArgs e)
        {
            this.SetEnabled((sender as TextBox).Text.Trim() != "");
        }

        protected virtual void _Usual_CheckedChanged(object sender, EventArgs e)
        {
            if (this._Usual.Checked)
            {
                this.Info.Text = "";
            }
            if (this.usual_onchecked != null)
            {
                this.usual_onchecked(this.Usual.Checked);
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

        private void SetEnabled(bool p_enabled)
        {
            if (this.UState != p_enabled)
            {
                if (p_enabled)
                {
                    this.Unusual.Checked = true;
                }
                else
                {
                    this.Usual.Checked = true;
                }
                this.UState = p_enabled;
            }
        }

        public void TransInfo(string change, string info)
        {
            if (!string.IsNullOrEmpty(change))
            {
                if (change == "1")
                {
                    this.Usual.Checked = true;
                }
                else if (change == "2")
                {
                    this.Unusual.Checked = true;
                    this.Info.Text = info;
                }
            }
        }

        public string Choose
        {
            get
            {
                if (this.Usual.Checked)
                {
                    return this.Usual.Tag.ToString();
                }
                if (this.Unusual.Checked)
                {
                    return this.Unusual.Tag.ToString();
                }
                return null;
            }
            set
            {
                if (this.Usual.Tag.ToString() == value)
                {
                    this.Usual.Checked = true;
                }
                else if (this.Unusual.Tag.ToString() == value)
                {
                    this.Unusual.Checked = true;
                }
            }
        }

        public string Choose_EX
        {
            get
            {
                return this.Info.Text;
            }
            set
            {
                this.Info.Text = value;
            }
        }

        public bool Enableed
        {
            set
            {
                this.Info.Enabled = value;
                this.Unusual.Enabled = value;
                this.Unusual.Checked = false;
                this.Usual.Enabled = value;
                this.Usual.Checked = false;
            }
        }

        public bool ErrorInput { get; set; }

        public TextBox Info
        {
            get
            {
                return this._info;
            }
            set
            {
                this._info = value;
                if (this._info != null)
                {
                    this._info.ReadOnly = false;
                    this._info.TextChanged += new EventHandler(this._info_TextChanged);
                }
            }
        }

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

        public string StrUnusual
        {
            get
            {
                return this.Unusual.Tag.ToString();
            }
            set
            {
                this.Unusual.Tag = value;
            }
        }

        public string StrUsual
        {
            get
            {
                return this._Usual.Tag.ToString();
            }
            set
            {
                this._Usual.Tag = value;
            }
        }

        public RadioButton Unusual
        {
            get
            {
                return this._Unusual;
            }
            set
            {
                this._Unusual = value;
                this._Unusual.Tag = "2";
            }
        }

        public RadioButton Usual
        {
            get
            {
                return this._Usual;
            }
            set
            {
                this._Usual = value;
                this._Usual.Tag = "1";
                this._Usual.CheckedChanged += new EventHandler(this._Usual_CheckedChanged);
            }
        }
    }
}

