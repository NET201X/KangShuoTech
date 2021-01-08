namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;

    public class ManyRadionButtons<T>
    {
        private string Choice;
        private string ChoiceEx;
        private int maxBytesCount;
        private Dictionary<string, RadioButton> rdbtns;

        public ManyRadionButtons(T src)
        {
            this.Source = src;
            this.rdbtns = new Dictionary<string, RadioButton>();
        }

        public void AddRdBtn(RadioButton rd)
        {
            this.rdbtns.Add((this.rdbtns.Count + 1).ToString(), rd);
            rd.CheckedChanged += new EventHandler(this.rd_CheckedChanged);
        }

        public void AddRdBtn(RadioButton[] rd)
        {
            for (int i = 0; i < rd.Length; i++)
            {
                this.rdbtns.Add((this.rdbtns.Count + 1).ToString(), rd[i]);
                rd[i].CheckedChanged += new EventHandler(this.rd_CheckedChanged);
            }
        }

        public void BindPropertyInfo(string it, string itex)
        {
            Func<KeyValuePair<string, RadioButton>, bool> predicate = null;
            Func<KeyValuePair<string, RadioButton>, bool> func2 = null;
            this.Choice = it;
            this.ChoiceEx = itex;
            System.Type type = this.Source.GetType();
            PropertyInfo property = type.GetProperty(it);
            string ted = "";
            if (property != null)
            {
                object obj2 = property.GetValue(this.Source, null);
                if (obj2 != null)
                {
                    ted = obj2.ToString();
                    if (predicate == null)
                    {
                        predicate = a => a.Key == ted;
                    }
                    if (this.rdbtns.Count<KeyValuePair<string, RadioButton>>(predicate) == 1)
                    {
                        if (func2 == null)
                        {
                            func2 = a => a.Key == ted;
                        }
                        this.rdbtns.Single<KeyValuePair<string, RadioButton>>(func2).Value.Checked = true;
                    }
                }
            }
            if (type.GetProperty(itex) != null)
            {
                this.tbOther.DataBindings.Add("Text", this.Source, itex, false, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public void Hide()
        {
            foreach (KeyValuePair<string, RadioButton> pair in this.rdbtns)
            {
                pair.Value.Visible = false;
            }
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.tbOther.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.tbOther.BackColor = Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.tbOther.BackColor = Color.WhiteSmoke;
            }
        }

        private void rd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            Func<KeyValuePair<string, RadioButton>, bool> predicate = null;
            RadioButton r_d = sender as RadioButton;
            if (r_d.Checked)
            {
                if (predicate == null)
                {
                    predicate = t => t.Value == r_d;
                }
                this.Source.GetType().GetProperty(this.Choice).SetValue(this.Source, this.rdbtns.Single<KeyValuePair<string, RadioButton>>(predicate).Key, null);
                if (r_d.Text == this.OthersText)
                {
                    this.tbOther.ReadOnly = false;
                }
            }
            else if (r_d.Text == this.OthersText)
            {
                this.tbOther.Clear();
                this.tbOther.ReadOnly = true;
            }
            }
            catch (Exception )
            {

            }
        }

        public bool ErrorInput { get; set; }

        public RadioButton this[string index]
        {
            get
            {
                return this.rdbtns[index];
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
                    this.tbOther.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public string OthersText { get; set; }

        private T Source { get; set; }

        public TextBox tbOther { get; set; }
    }
}

