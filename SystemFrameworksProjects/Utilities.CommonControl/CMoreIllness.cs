namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class CMoreIllness
    {
        private List<CheckBox> _list_ckx;
        private int maxBytesCount;

        public string GetResult()
        {
            return "";
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.TbOther.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.TbOther.BackColor = Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.TbOther.BackColor = Color.WhiteSmoke;
            }
        }

        private void temp_CheckedChanged(object sender, EventArgs e)
        {
            CheckState @unchecked;
            bool flag;
            CheckBox box = sender as CheckBox;
            if (box.Checked)
            {
                @unchecked = CheckState.Unchecked;
                flag = false;
            }
            else
            {
                @unchecked = CheckState.Unchecked;
                flag = true;
                this.TbOther.Clear();
            }
            for (int i = 0; i < this.list_ckx.Count; i++)
            {
                if (this.list_ckx[i] != box)
                {
                    this.list_ckx[i].CheckState = @unchecked;
                    this.list_ckx[i].Enabled = flag;
                }
            }
        }

        private void temp_other_checkedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                this.TbOther.ReadOnly = false;
            }
            else
            {
                this.TbOther.Clear();
                this.TbOther.ReadOnly = true;
            }
        }

        public void TransInfo(string info, string other)
        {
            if (!string.IsNullOrEmpty(info))
            {
                string str = info;
                char[] separator = new char[] { ',' };
                foreach (string str2 in str.Split(separator))
                {
                    int num;
                    if (int.TryParse(str2, out num) && num > 0)
                    {
                        this.list_ckx[num - 1].Checked = true;
                    }
                }
                if (!string.IsNullOrEmpty(other))
                {
                    this.list_ckx[this.list_ckx.Count - 1].Checked = true;
                    this.TbOther.Text = other;
                }
            }
        }

        public bool ErrorInput { get; set; }

        public string FinalResult
        {
            get
            {
                string str = "";
                for (int i = 0; i < this.list_ckx.Count; i++)
                {
                    if ((this.list_ckx[i].CheckState != CheckState.Indeterminate) && this.list_ckx[i].Checked)
                    {
                        str = str + Convert.ToSingle((int) (i + 1)) + ",";
                    }
                }
                return str.TrimEnd(new char[] { ',' });
            }
        }

        public string FinalResultEX
        {
            get
            {
                return this.TbOther.Text.Trim();
            }
        }

        public List<CheckBox> list_ckx
        {
            get
            {
                return this._list_ckx;
            }
            set
            {
                this._list_ckx = value;
                if (this._list_ckx != null)
                {
                    foreach (CheckBox box in this.list_ckx)
                    {
                        if (box.Text == this.noText)
                        {
                            box.CheckedChanged += new EventHandler(this.temp_CheckedChanged);
                        }
                        else if (box.Text == this.otherText)
                        {
                            box.CheckedChanged += new EventHandler(this.temp_other_checkedChanged);
                        }
                    }
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
                    this.TbOther.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public string noText { get; set; }

        public string otherText { get; set; }

        public TextBox TbOther { get; set; }
    }
}

