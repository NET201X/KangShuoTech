namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Reflection;

    public class SelectItemT<T> : CSelectItem
    {
        private string ProOth;
        private string ProSelect;

        public SelectItemT(T src)
        {
            this.Source = src;
        }

        public void BindProperty(string sel, string ex)
        {
            this.ProSelect = sel;
            this.ProOth = ex;
            Binding binding = new Binding("SelectedValue", this.Source, sel, false, DataSourceUpdateMode.OnValidation) {
                DataSourceNullValue = string.Empty
            };
            base.CmbSelect.DataBindings.Add(binding);
            base.Info.DataBindings.Add("Text", this.Source, ex, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void BindProperty(string sel, object selNull, string ex)
        {
            this.ProSelect = sel;
            this.ProOth = ex;
            base.CmbSelect.DataBindings.Add("SelectedValue", this.Source, sel, false, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            base.CmbSelect.DataBindings[0].DataSourceNullValue = selNull;
            base.Info.DataBindings.Add("Text", this.Source, ex, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public T Source { get; set; }
    }

    //public class SingleItemT<T> : CSingleItem
    //{
    //    private decimal m_maxValue;
    //    private string ProContent;
    //    private string ProEx;
    //    private T source;

    //    public SingleItemT(T src)
    //    {
    //        this.source = src;
    //    }

    //    public SingleItemT(T src, decimal maxValue)
    //    {
    //        this.source = src;
    //        this.m_maxValue = maxValue;
    //    }

    //    protected override void _Usual_CheckedChanged(object sender, EventArgs e)
    //    {
    //        if (base.Usual.Checked)
    //        {
    //            this.SetContent("1");
    //            base.Info.Text = "";
    //        }
    //    }

    //    public void BindProperty(string pro, string proex)
    //    {
    //        this.ProContent = pro;
    //        this.ProEx = proex;
    //        System.Type type = this.source.GetType();
    //        PropertyInfo property = type.GetProperty(pro);
    //        if (property != null)
    //        {
    //            object obj2 = property.GetValue(this.source, null);
    //            if (obj2 != null)
    //            {
    //                this.SetMean(obj2.ToString());
    //            }
    //        }
    //        if (type.GetProperty(proex) != null)
    //        {
    //            if (this.m_maxValue > 0M)
    //            {
    //                base.Info.DataBindings.Add("Text", this.source, proex, true, DataSourceUpdateMode.OnPropertyChanged);
    //                base.Info.DataBindings["Text"].Parse += new ConvertEventHandler(this.SingleItemT_Parse);
    //            }
    //            else
    //            {
    //                base.Info.DataBindings.Add("Text", this.source, proex, false, DataSourceUpdateMode.OnPropertyChanged);
    //            }
    //        }
    //        base.Unusual.CheckedChanged += new EventHandler(this.Unusual_CheckedChanged);
    //    }

    //    private void SetContent(string ctt)
    //    {
    //        this.source.GetType().GetProperty(this.ProContent).SetValue(this.source, ctt, null);
    //    }

    //    private void SetMean(string str)
    //    {
    //        if (!string.IsNullOrEmpty(str))
    //        {
    //            if (str == "1")
    //            {
    //                base.Usual.Checked = true;
    //            }
    //            else if (str == "2")
    //            {
    //                base.Unusual.Checked = true;
    //            }
    //        }
    //    }

    //    private void SingleItemT_Parse(object sender, ConvertEventArgs e)
    //    {
    //        decimal num;
    //        Binding binding = sender as Binding;
    //        if (decimal.TryParse(e.Value.ToString(), out num))
    //        {
    //            if ((num >= 0M) && (num < this.m_maxValue))
    //            {
    //                base.ErrorInput = false;
    //                binding.Control.BackColor = Color.WhiteSmoke;
    //                e.Value = num;
    //            }
    //            else
    //            {
    //                base.ErrorInput = true;
    //                binding.Control.BackColor = Color.Salmon;
    //            }
    //        }
    //        else
    //        {
    //            base.ErrorInput = false;
    //            e.Value = null;
    //            binding.Control.BackColor = Color.WhiteSmoke;
    //        }
    //    }

    //    private void Unusual_CheckedChanged(object sender, EventArgs e)
    //    {
    //        if (base.Unusual.Checked)
    //        {
    //            this.SetContent("2");
    //        }
    //    }
    //}
}

