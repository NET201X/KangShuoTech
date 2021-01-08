namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Femiani.Forms.UI.Input;
    using DataAccessProjects.Model;
    using DataAccessProjects.BLL;

    public class SimpleBindingManager<T>
    {
        public List<Binding> CtrBindings;
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private T Model;

        public SimpleBindingManager()
        {
        }

        public SimpleBindingManager(List<InputRangeDec> dec, List<InputRangeStr> strs, T mo)
        {
            this.inputrange_str = strs;
            this.inputRanges = dec;
            this.Model = mo;
            this.CtrBindings = new List<Binding>();
        }

        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            Binding bd = sender as Binding;
            InputRangeDec dec = this.inputRanges.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = null;
                return;
            }
            if (decimal.TryParse(e.Value.ToString(), out num))
            {
                if (dec != null)
                {
                    if (dec.CheckIt(ref num))
                    {
                        bd.Control.BackColor = Color.WhiteSmoke;
                        dec.ErrorInput = false;
                        //e.Value = num;
                    }
                    else
                    {
                        bd.Control.BackColor = Color.Salmon;
                        dec.ErrorInput = true;
                    }
                }
            }
            else
            {
                e.Value = null;
                bd.Control.BackColor = Color.WhiteSmoke;
                dec.ErrorInput = false;
            }
        }

        private void bd_ParseIdentifyCard(object sender, ConvertEventArgs e)
        {
            string card = e.Value as string;
            Binding bd = sender as Binding;
            InputRangeStr str2 = this.inputrange_str.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (str2 != null)
            {
                if (!this.IsIdentifyCard(card))
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

        private void bd_ParsePhone(object sender, ConvertEventArgs e)
        {
            string str = e.Value as string;
            Binding bd = sender as Binding;
            InputRangeStr str2 = this.inputrange_str.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (str2 != null)
            {
                if (!this.CheckPhoneNum(str))
                {
                    str2.ErrorInput = true;
                    bd.Control.BackColor = Color.Salmon;
                }
                else if (Encoding.GetEncoding("GB2312").GetByteCount(str) > str2.BytesCount)
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

        private void bd_ParseStr(object sender, ConvertEventArgs e)
        {
            string str = e.Value as string;
            Binding bd = sender as Binding;
            InputRangeStr str2 = this.inputrange_str.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (str2 != null)
            {
                if (!string.IsNullOrEmpty(str2.StrRegex) && (string.IsNullOrEmpty(str) || !Regex.IsMatch(str, str2.StrRegex)))
                {
                    str2.ErrorInput = true;
                    bd.Control.BackColor = Color.Salmon;
                }
                else if (Encoding.GetEncoding("GB2312").GetByteCount(str) > str2.BytesCount)
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

        private bool CheckPhoneNum(string str)
        {
            bool flag = false;
            if (!string.IsNullOrEmpty(str) && ((!Regex.IsMatch(str, @"^(\d{3,4})?\d{6,8}$") && !Regex.IsMatch(str, @"^(\d{3,4}-)?\d{6,8}$")) && !Regex.IsMatch(str, @"^[1]+[0-9]+\d{9}")))
            {
                return flag;
            }
            return true;
        }

        private void GetWhatsUp()
        {
            foreach (InputRangeStr str in from f in this.inputrange_str
                where f.ErrorInput
                select f)
            {
                //string str2 = manager.WhatsUp + str.Whatsup;
                //manager.WhatsUp = str2;
            }
            foreach (InputRangeDec dec in from f in this.inputRanges
                where f.ErrorInput
                select f)
            {
                //string str3 = manager2.WhatsUp + dec.Whatsup;
                //manager2.WhatsUp = str3;
            }
        }

        public bool IsHandset(string str_handset)
        {
            return Regex.IsMatch(str_handset, @"^[1]+[0-9]+\d{9}");
        }

        public bool IsIdentifyCard(string card)
        {
            bool flag = false;
            if (Regex.IsMatch(card, @"^\d{15}$|^\d{17}(?:\d|x|X)$"))
            {
                flag = true;
            }
            return flag;
        }

        public bool IsTelephone(string str_telephone)
        {
            return Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }

        private void mtb_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.Salmon;
        }

        public void SimpleBinding(ComboBox cb, string member)
        {
            Binding binding = new Binding("SelectedValue", this.Model, member, false, DataSourceUpdateMode.OnValidation) {
                DataSourceNullValue = string.Empty
            };
            cb.DataBindings.Add(binding);
        }

        public void SimpleBinding(ComboBox cb, string bindingPro, string member)
        {
            Binding binding = new Binding(bindingPro, this.Model, member, false, DataSourceUpdateMode.OnValidation) {
                DataSourceNullValue = string.Empty
            };
            cb.DataBindings.Add(binding);
        }
        public void SimpleBinding(ComboBox cb, string member, bool formate)
        {
            Binding item = new Binding("Text", this.Model, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            if (formate)
            {
                item.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                item.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            this.CtrBindings.Add(item);
            cb.DataBindings.Add(item);
        }

        public void SimpleBinding(MaskedTextBox mtb, string member, bool formate)
        {
            Binding binding = new Binding("Text", this.Model, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            mtb.DataBindings.Add(binding);
        }
        public void SimpleBindings(CoolTextBox tb, string member, bool formate)
        {
            Binding item = new Binding("Text", this.Model, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            if (formate)
            {
                item.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                item.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            this.CtrBindings.Add(item);
            tb.DataBindings.Add(item);
        }

        public void SimpleBinding(TextBox tb, string member, bool formate)
        {
            Binding item = new Binding("Text", this.Model, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            if (formate)
            {
                item.Parse += new ConvertEventHandler(this.bd_Parse);
            }
            else
            {
                item.Parse += new ConvertEventHandler(this.bd_ParseStr);
            }
            this.CtrBindings.Add(item);
            tb.DataBindings.Add(item);
        }

        public void SimpleBindingIdentify(TextBox tb, string member)
        {
            Binding binding = new Binding("Text", this.Model, member, false, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(this.bd_ParseIdentifyCard);
            tb.DataBindings.Add(binding);
        }

        public void SimpleBindingInt(TextBox tb, string member, bool formate)
        {
            Binding binding = new Binding("Text", this.Model, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(this.bd_ParseInt);
            tb.DataBindings.Add(binding);
        }

        public void SimpleBindingPhoneNum(TextBox tb, string member, bool formate)
        {
            Binding binding = new Binding("Text", this.Model, member, formate, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(this.bd_ParsePhone);
            tb.DataBindings.Add(binding);
        }

        public void UpdateControl()
        {
            foreach (Binding binding in this.CtrBindings)
            {
                binding.ReadValue();
            }
        }

        public bool ErrorInput
        {
            get
            {
                this.GetWhatsUp();
                return ((this.inputrange_str.Count<InputRangeStr>(c => c.ErrorInput) + this.inputRanges.Count<InputRangeDec>(d => d.ErrorInput)) > 0);
            }
        }

        public string WhatsUp { get; set; }
    }
}

