using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;

namespace FocusGroup.ChronicDisease
{
    using CommonControl;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using Femiani.Forms.UI.Input;

    public class DrugCondions
    {
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private bool UState;
        private DataTable dt_yw;
        public void InitEveryControl()
        {
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("DailyTime", 100M, false));
            this.inputRanges.Add(new InputRangeDec("EveryTimeMg", 100M));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Name", 100));
            this.DrugbindingManager = new SimpleBindingManager<ChronicDrugConditionModel>(this.inputRanges, this.inputrange_str, this.Source);
            this.SimpleBindings(this.TbDrugName, "Name");
            this.DrugbindingManager.SimpleBinding(this.TbUseCount, "DailyTime", true);
            this.DrugbindingManager.SimpleBinding(this.TbUseDose, "EveryTimeMg", false);
            this.TbDrugName.SelectListItem += new EventHandler(TbDrugName_SelectListItem);
            this.TbDrugName.AutoTextChanged += new EventHandler(TbDrugName_AutoTextChanged);
        }
  
    
        void TbDrugName_AutoTextChanged(object sender, EventArgs e)
        {
            if (TbDrugName.Text == "")
            {
                TbUseCount.Text = "";
                TbUseDose.Text = "";
                TbUseCount.ReadOnly = true;
                TbUseDose.ReadOnly = true;

            }
            else
            {
                TbUseCount.ReadOnly = false;
                TbUseDose.ReadOnly = false;
            }
        }

        void TbDrugName_SelectListItem(object sender, EventArgs e)
        {
            foreach (DataRow item in dt_yw.Rows)
            {
                if (item["name"].ToString() == TbDrugName.Text)
                {
                    TbUseCount.Text = item["cishu"].ToString();
                    TbUseDose.Text = item["jiliang"].ToString();
                    break;
                }
            }
        }
        public void setSource(DataTable p_dt_yw)
        {
            this.dt_yw = p_dt_yw;
            foreach (DataRow item in dt_yw.Rows)
            {
                List<string> match_strs = new List<string>();

                match_strs.Add(item["name"].ToString());
                match_strs.Add(item["szm"].ToString().ToLower());
                match_strs.Add(item["szm"].ToString().ToUpper());

                if (item["szm"].ToString().Contains(","))
                {
                    var cc = item["szm"].ToString().ToLower().Split(',');
                    match_strs.AddRange(cc);
                }

                TbDrugName.Items.Add(new AutoCompleteEntry(item["name"].ToString(), match_strs.ToArray()));
            }
        }

        public void UpdateSource()
        {
            decimal num;
            source.Name = TbDrugName.Text;
            if (decimal.TryParse(this.TbUseDose.Text, out num) && !(num < 0M))
            {
                source.EveryTimeMg = this.TbUseDose.Text.ToString();
            }
            source.DailyTime =Convert.ToDecimal (this.TbUseCount);
            if (this.TbDrugName.Text.Trim() == "")
            {
                if (this.Source.ModelState == RecordsStateModel.Unchanged)
                {
                    this.Source.ModelState = RecordsStateModel.DeleteInDB;
                }
            }
            else
            {
                if (this.Source.ModelState == RecordsStateModel.Unchanged)
                {
                    this.Source.ModelState = RecordsStateModel.UpdateInDB;
                }
                if (this.Source.ModelState == RecordsStateModel.NoValue)
                {
                    this.Source.ModelState = RecordsStateModel.AddToDB;
                }
            }
 
        }

        private SimpleBindingManager<ChronicDrugConditionModel> DrugbindingManager { get; set; }

        public bool ErrorInput
        {
            get
            {
                return this.DrugbindingManager.ErrorInput;
            }
        }
        private ChronicDrugConditionModel source;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChronicDrugConditionModel Source
        {
            set
            {
                if (value != null)
                {
                    source = value;
                    TbDrugName.Text = source.Name;
                    TbUseCount.Text = Convert.ToString( source.DailyTime);
                    TbUseDose.Text = source.EveryTimeMg;

                    if (string.IsNullOrEmpty(source.Name) == false)
                    {
                        TbUseCount.ReadOnly = false;
                        TbUseDose.ReadOnly = false;
                    }
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
        private void SimpleBindings(CoolTextBox tb, string member)
        {
            if (tb.DataBindings.Count == 0)
            {
                Binding bd;
                bd = new Binding("Text", Source, member, false, DataSourceUpdateMode.OnPropertyChanged);
                bd.Parse += new ConvertEventHandler(bd_ParseStr);
                tb.DataBindings.Add(bd);
            }

        }

        void bd_ParseStr(object sender, ConvertEventArgs e)
        {

            string str = e.Value as string;
            Binding bd = sender as Binding;

            InputRangeStr input = inputrange_str.Find(c => { return c.Name == bd.BindingMemberInfo.BindingField; });
            if (input != null)
            {
                int length = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(str);

                if (length > input.BytesCount)
                {
                    input.ErrorInput = true;
                    bd.Control.BackColor = Color.Salmon;
                }
                else
                {
                    input.ErrorInput = false;
                    bd.Control.BackColor = Color.WhiteSmoke;
                }
            }
        }
      //  public ChronicDrugConditionModel Source { get; set; }

        public CoolTextBox TbDrugName { get; set; }

        public TextBox TbUseCount { get; set; }

        public TextBox TbUseDose { get; set; }
    }
}
