using KangShuoTech.DataAccessProjects.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Femiani.Forms.UI.Input;
using System.Data;
using System.Text.RegularExpressions;

namespace KangShuoTech.Utilities.CommonControl
{
    public partial class YesNoControl : UserControl
    {
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private List<InputRangeDec> inputRanges = new List<InputRangeDec>();
        public YesNoControl()
        {
            InitializeComponent();
        }
        public void UpdateSource()
        {
            if (!string.IsNullOrEmpty(this.txbDay.Text))
            {
                source.DayBeats = Convert.ToDecimal(this.txbDay.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.txbWeek.Text))
            {
                source.WeekBeats = Convert.ToDecimal(this.txbWeek.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.txbMouth.Text))
            {
                source.MouthBeats = Convert.ToDecimal(this.txbMouth.Text.Trim());
            }
            if (this.CkbNo.Checked)
            {
                source.EatYesNo = "2";
            }
            else if (this.CkbYes.Checked)
            {
                source.EatYesNo = "1";
            }
            else
            {
                source.EatYesNo = "";
            }

            if (!string.IsNullOrEmpty(this.txbSalt.Text))
            {
                source.SaltSumBeats = Convert.ToDecimal(this.txbSalt.Text.Trim());
            }
          
        }

        private void CkbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (CkbYes.Checked == true)
            {
                CkbNo.Checked = false;
                this.txbDay.ReadOnly = false;
                this.txbMouth.ReadOnly = false;
                this.txbSalt.ReadOnly = false;
                this.txbWeek.ReadOnly = false;
            }
        }

        private void CkbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (CkbNo.Checked == true)
            {
                CkbYes.Checked = false;
                this.txbDay.Clear();
                this.txbMouth.Clear();
                this.txbSalt.Clear();
                this.txbWeek.Clear();

                this.txbDay.ReadOnly = true;
                this.txbMouth.ReadOnly = true;
                this.txbSalt.ReadOnly = true;
                this.txbWeek.ReadOnly = true;
            }
        }
        public bool ErrorInput { get; set; }
        private RecordsHyperFoodsModel source;
        private SimpleBindingManager<RecordsHyperFoodsModel> bindingManager;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RecordsHyperFoodsModel Source
        {
            set
            {
                if (value != null)
                {
                    source = value;
                    labName.Text = source.FoodName;
                    if (!string.IsNullOrEmpty(source.EatYesNo))
                    {
                        if (source.EatYesNo == "1")
                        {
                            this.CkbYes.Checked = true;
                        }
                        else if (source.EatYesNo == "2")
                        {
                            this.CkbNo.Checked = true;
                        }
                    }
                    else
                        this.CkbNo.Checked = true;

                    this.SimpleBindingInt(this.txbDay, "DayBeats", true);
                    this.SimpleBindingInt(this.txbWeek, "WeekBeats", true);
                    this.SimpleBindingInt(this.txbMouth, "MouthBeats", true);
                    this.SimpleBinding(this.txbSalt, "SaltSumBeats", true, DataSourceUpdateMode.OnPropertyChanged);
                }
                else
                {
                    Console.WriteLine("数据为空");
                }

            }
            get
            {
                return source;
            }
        }
        private void SimpleBinding(TextBox tb, string member, bool formate, DataSourceUpdateMode mode)
        {
            Binding binding = new Binding("Text", this.source, member, formate, mode);
            if (formate)
            {
                binding.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                binding.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            tb.DataBindings.Add(binding);
        }

        public void SimpleBindingInt(TextBox tb, string member, bool formate)
        {
            Binding binding = new Binding("Text", this.source, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(this.bd_ParseInt);
            tb.DataBindings.Add(binding);
        }

        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            Binding binding = sender as Binding;
            if (decimal.TryParse(e.Value.ToString(), out num))
            {
                if (num < 0M)
                {
                    this.ErrorInput = true;
                    binding.Control.BackColor = Color.Salmon;
                }
                else
                {
                    binding.Control.BackColor = Color.WhiteSmoke;
                    this.ErrorInput = false;
                }
            }
            else
            {
                binding.Control.BackColor = Color.WhiteSmoke;
                this.ErrorInput = false;
                e.Value = null;
            }
        }

        private void bd_ParseStr(object sender, ConvertEventArgs e)
        {
            string s = e.Value as string;
            Binding bd = sender as Binding;
            InputRangeStr str2 = this.inputrange_str.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (str2 != null)
            {
                if (Encoding.GetEncoding("GB2312").GetByteCount(s) > str2.BytesCount)
                {
                    str2.ErrorInput = true;
                    bd.Control.BackColor = Color.Salmon;
                }
                else
                {
                    str2.ErrorInput = false;
                    bd.Control.BackColor = Color.WhiteSmoke;
                }
            }
        }
        private void bd_ParseInt(object sender, ConvertEventArgs e)
        {
            int num;
            Predicate<InputRangeDec> match = null;
            Binding bd = sender as Binding;
            if (int.TryParse(e.Value.ToString(), out num))
            {
                if (match == null)
                {
                    match = c => c.Name == bd.BindingMemberInfo.BindingField;
                }
                InputRangeDec dec = this.inputRanges.Find(match);
                if (dec != null)
                {
                    if (dec.CheckIt(ref num))
                    {
                        bd.Control.BackColor = Color.WhiteSmoke;
                        e.Value = num;
                    }
                    else
                    {
                        bd.Control.BackColor = Color.Salmon;
                    }
                }
            }
            else
            {
                e.Value = null;
            }
        }
      
    }
}
