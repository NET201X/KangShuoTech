namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class CMoreChange
    {
        private int maxBytesCount;
        private CheckedListBox moreChange;
        public SetOtherEnabled setOtherEnabled;

        public string GetYaoWu()
        {
            string str = "";
            string str2 = "";
            for (int i = 0; i < this.moreChange.Items.Count; i++)
            {
                if (this.moreChange.GetItemChecked(i) && (this.moreChange.GetItemCheckState(i) != CheckState.Indeterminate))
                {
                    str = str + this.moreChange.Items[i].ToString();
                }
            }
            if (string.IsNullOrEmpty(str.Trim()) || (str.Trim() == "无"))
            {
                return "1";
            }
            for (int j = 0; j < this.moreChange.Items.Count; j++)
            {
                if ((this.moreChange.GetItemCheckState(j) != CheckState.Indeterminate) && this.moreChange.GetItemChecked(j))
                {
                    str2 = str2 + string.Format("{0},", j + 1);
                }
            }
            return str2.TrimEnd(new char[] { ',' });
        }

        private void moreChange_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!this.CheckOnAutoStatus)
            {
                if (e.CurrentValue == CheckState.Indeterminate)
                {
                    e.NewValue = CheckState.Indeterminate;
                }
                else if (this.moreChange.Items[e.Index].ToString() == this.Unusual)
                {
                    this.CheckOnAutoStatus = true;
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        for (int i = 1; i < this.moreChange.Items.Count; i++)
                        {
                            this.moreChange.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                    else
                    {
                        for (int j = 1; j < this.moreChange.Items.Count; j++)
                        {
                            this.moreChange.SetItemCheckState(j, CheckState.Indeterminate);
                        }
                        if (this.Other != null)
                        {
                            this.Other.ReadOnly = true;
                            this.Other.Text = "";
                        }
                    }
                    if (this.setOtherEnabled != null)
                    {
                        this.setOtherEnabled(e.NewValue == CheckState.Checked);
                    }
                    this.CheckOnAutoStatus = false;
                }
                else if (this.moreChange.Items[e.Index].ToString() == "其他")
                {
                    this.CheckOnAutoStatus = true;
                    if (e.NewValue == CheckState.Checked)
                    {
                        this.Other.ReadOnly = false;
                    }
                    else if (this.Other != null)
                    {
                        this.Other.ReadOnly = true;
                        this.Other.Text = "";
                    }
                    this.CheckOnAutoStatus = false;
                }
            }
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.Other.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.Other.BackColor = Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.Other.BackColor = Color.WhiteSmoke;
            }
        }

        public void TransInfo(string info, string other)
        {
            if (!string.IsNullOrEmpty(info))
            {
                string str = info;
                char[] separator = new char[] { ',' };
                string[] strArray = str.Split(separator);
                for (int i = 0; i < strArray.Length; i++)
                {
                    int num;
                    object obj2 = strArray[i];
                    if (int.TryParse(obj2.ToString(), out num) && num > 0 && (num <= this.MoreChange.Items.Count))
                    {
                        this.MoreChange.SetItemChecked(num - 1, true);
                    }
                }
                if (!string.IsNullOrEmpty(other) && (this.Other != null))
                {
                    this.Other.Text = other;
                }
            }
        }

        public bool CheckOnAutoStatus { get; set; }

        public bool ErrorInput { get; set; }

        public string FinalResult
        {
            get
            {
                string str = "";
                string str2 = "";
                for (int i = 0; i < this.moreChange.Items.Count; i++)
                {
                    if (this.moreChange.GetItemChecked(i) && (this.moreChange.GetItemCheckState(i) != CheckState.Indeterminate))
                    {
                        str = str + this.moreChange.Items[i].ToString();
                    }
                }
                if (string.IsNullOrEmpty(str.Trim()) || (str.Trim() == "无"))
                {
                    if (this.Unusual != null)
                    {
                        if (string.IsNullOrEmpty(str.Trim()))
                        {
                            return string.Empty;
                        }
                        if (str.Trim() == "无")
                        {
                            str2 = "1";
                        }
                    }
                    return str2;
                }
                for (int j = 0; j < this.moreChange.Items.Count; j++)
                {
                    if ((this.moreChange.GetItemCheckState(j) != CheckState.Indeterminate) && this.moreChange.GetItemChecked(j))
                    {
                        str2 = str2 + string.Format("{0},", j + 1);
                    }
                }
                return str2.TrimEnd(new char[] { ',' });
            }
        }

        public string FinalResultEX
        {
            get
            {
                return this.Other.Text.Trim();
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
                    //this.Other.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public CheckedListBox MoreChange
        {
            get
            {
                return this.moreChange;
            }
            set
            {
                this.moreChange = value;
                this.CheckOnAutoStatus = false;
                if (this.moreChange != null)
                {
                    this.moreChange.ItemCheck += new ItemCheckEventHandler(this.moreChange_ItemCheck);
                }
            }
        }

        public string Name { get; set; }

        public TextBox Other { get; set; }

        public string Unusual { get; set; }

        public delegate void SetOtherEnabled(bool v);
    }
}

