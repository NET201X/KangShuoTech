namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;


    public class ManyCheckboxs<T>
    {
        private int? maxCount;
        public Action<bool> oneVetoChecked;
        private string ProValue;
        private string ProVassal;

        public ManyCheckboxs(T p_model)
        {
            this.AllCheckboxes = new List<LoneCheckbox>();
            this.Source = p_model;
        }

        public ManyCheckboxs(T p_model, int maxcount)
        {
            this.AllCheckboxes = new List<LoneCheckbox>();
            this.maxCount = new int?(maxcount);
            this.Source = p_model;
        }

        public void AddCk(LoneCheckbox it)
        {
            if (string.IsNullOrEmpty(it.Mean))
            {
                it.Mean = Convert.ToString((int) (this.AllCheckboxes.Count + 1));
            }
            if (it.OneVeto)
            {
                it.useOneVeto = (Action<LoneCheckbox, bool>) Delegate.Combine(it.useOneVeto, new Action<LoneCheckbox, bool>(this.RunOneVeto));
            }
            it.UpdateSource = (Action) Delegate.Combine(it.UpdateSource, new Action(this.UpdateSrcModel));
            this.AllCheckboxes.Add(it);
        }

        public void AddCk(LoneCheckbox[] its)
        {
            if (its != null)
            {
                foreach (LoneCheckbox checkbox in its)
                {
                    this.AddCk(checkbox);
                }
            }
        }

        public void AddCk(CheckBox ck)
        {
            this.AddCk(new LoneCheckbox(ck));
        }

        public void AddCk(CheckBox[] cks)
        {
            for (int i = 0; i < cks.Length; i++)
            {
                this.AddCk(new LoneCheckbox(cks[i]));
            }
        }

        public void AddCk(CheckBox ck, bool veto)
        {
            this.AddCk(new LoneCheckbox(ck, veto));
        }

        public void AddCk(CheckBox ck, TextBox vassal)
        {
            this.AddCk(new LoneCheckbox(ck, vassal));
        }

        public void BindingProperty(string pro, string vassal)
        {
            this.ProValue = pro;
            this.ProVassal = vassal;
            System.Type type = this.Source.GetType();
            PropertyInfo property = type.GetProperty(pro);
            if (property == null)
            {
                throw new Exception("未找到:" + pro);
            }
            object obj2 = property.GetValue(this.Source, null);
            if (obj2 != null)
            {
                this.SetTheMeans(obj2.ToString());
            }
            if (!string.IsNullOrEmpty(vassal) && (type.GetProperty(vassal) != null))
            {
                LoneCheckbox checkbox = this.AllCheckboxes.Single<LoneCheckbox>(a => a.Vassal != null);
                if (checkbox != null)
                {
                    if (this.maxCount.HasValue)
                    {
                        checkbox.Vassal.MaxLength = this.maxCount.Value;
                        checkbox.Vassal.TextChanged += new EventHandler(this.Vassal_TextChanged);
                    }
                    checkbox.Vassal.DataBindings.Add("Text", this.Source, vassal, false, DataSourceUpdateMode.OnPropertyChanged);
                }
            }
        }

        public void ReadValue()
        {
            PropertyInfo property = this.Source.GetType().GetProperty(this.ProValue);
            if (property == null)
            {
                throw new Exception("未找到:" + this.ProValue);
            }
            object obj2 = property.GetValue(this.Source, null);
            if (obj2 != null)
            {
                string str = obj2.ToString();
                foreach (LoneCheckbox checkbox in this.AllCheckboxes)
                {
                    checkbox.m_checkbox.Checked = false;
                    checkbox.m_checkbox.Enabled = true;
                }
                this.SetTheMeans(str);
            }
        }

        private void RunOneVeto(LoneCheckbox sender, bool p_value)
        {
            for (int i = 0; i < this.AllCheckboxes.Count; i++)
            {
                if (sender != this.AllCheckboxes[i])
                {
                    this.AllCheckboxes[i].SetInvalid(p_value);
                }
            }
            if (this.oneVetoChecked != null)
            {
                this.oneVetoChecked(p_value);
            }
        }

        private void SetTheMeans(string p_value)
        {
            if (p_value != "")
            {
                string str = p_value;
                char[] separator = new char[] { ',' };
                foreach (string str2 in str.Split(separator))
                {
                    int num;
                    if (int.TryParse(str2, out num) && (this.AllCheckboxes.Count > (num - 1)))
                    {
                        this.AllCheckboxes[num - 1].m_checkbox.Checked = true;
                    }
                }
            }
        }

        private void UpdateSrcModel()
        {
            string str = "";
            for (int i = 0; i < this.AllCheckboxes.Count; i++)
            {
                if ((this.AllCheckboxes[i].m_checkbox.CheckState != CheckState.Indeterminate) && this.AllCheckboxes[i].m_checkbox.Checked)
                {
                    str = str + string.Format("{0},", i + 1);
                }
            }
            string str2 = str.TrimEnd(new char[] { ',' });
            PropertyInfo property = this.Source.GetType().GetProperty(this.ProValue);
            if (property != null)
            {
                property.SetValue(this.Source, str2, null);
            }
        }

        private void Vassal_TextChanged(object sender, EventArgs e)
        {
            LoneCheckbox checkbox = this.AllCheckboxes.Single<LoneCheckbox>(a => a.Vassal != null);
            if (checkbox != null)
            {
                int byteCount = Encoding.GetEncoding("GB2312").GetByteCount(checkbox.Vassal.Text);
                int? maxCount = this.maxCount;
                if (((byteCount <= maxCount.GetValueOrDefault()) ? 0 : (maxCount.HasValue ? 1 : 0)) != 0)
                {
                    this.ErrorInput = true;
                    checkbox.Vassal.BackColor = Color.Salmon;
                }
                else
                {
                    this.ErrorInput = false;
                    checkbox.Vassal.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private List<LoneCheckbox> AllCheckboxes { get; set; }

        public bool ErrorInput { get; set; }

        public bool MVisiable
        {
            set
            {
                if (!value)
                {
                    foreach (LoneCheckbox checkbox in this.AllCheckboxes)
                    {
                        checkbox.m_checkbox.Checked = false;
                        checkbox.m_checkbox.Visible = false;
                    }
                }
            }
        }

        public T Source { get; set; }
    }

    internal class ManyCheckboxs
    {
        private IContainer components;

        private void InitializeComponent()
        {
            this.components = new Container();
        }
    }
}

