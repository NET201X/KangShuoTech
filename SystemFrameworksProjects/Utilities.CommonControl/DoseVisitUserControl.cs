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
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.Utilities.CommonControl
{
    public partial class DoseVisitUserControl : UserControl
    {
        private DataTable dt_yw;
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        string IDCardType = ConfigHelper.GetNode("IdCardType");
        public DoseVisitUserControl()
        {
            InitializeComponent();
            if (IDCardType.Equals("3"))//二代机
            {
                SetFont(this);
            }
           
        }
        private void SetFont(Control controls)
        {
            controls.Font = new System.Drawing.Font("宋体", 15F);
            foreach (Control ct in controls.Controls)
            {
                ct.Font = new System.Drawing.Font("宋体", 15F);
                SetFont(ct);
            }
        }
        public void UpdateSource()
        {
            decimal num;
            source.Name = tbName.Text;
            source.EveryTimeMg = this.tbDose.Text.Trim();
            if (this.tbUseCount.Text != "")
            {
                 source.DailyTime = Convert.ToDecimal(this.tbUseCount.Text.Trim());
            }
            if (this.tbName.Text.Trim() == "")
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
        private void DoseVisitUserControl_Load(object sender, EventArgs e)
        {
            tbName.SelectListItem += new EventHandler(tbName_SelectListItem);
            tbName.AutoTextChanged += new EventHandler(tbName_AutoTextChanged);
        }
        void tbName_AutoTextChanged(object sender, EventArgs e)
        {
            if (tbName.Text =="")
            {
                tbUseCount.Text = "";
                tbDose.Text = "";
                txtjixing.Text = "";
                tbUseCount.ReadOnly = true;
                tbDose.ReadOnly = true;
                txtjixing.ReadOnly = true;
            }
            else
            {
                tbUseCount.ReadOnly = false;
                tbDose.ReadOnly = false;
                txtjixing.ReadOnly = false;
            }
        }

        void tbName_SelectListItem(object sender, EventArgs e)
        {
            foreach (DataRow item in dt_yw.Rows)
            {
                if (item["name"].ToString() == tbName.Text)
                {
                    tbUseCount.Text = item["cishu"].ToString();
                    tbDose.Text = item["jiliang"].ToString();
                    txtjixing.Text = item["jixing"].ToString ();
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

                tbName.Items.Add(new AutoCompleteEntry(item["name"].ToString(), match_strs.ToArray()));
            }
            this.Refresh();
        }
 
        public bool ErrorInput { get; set; }
        private ChronicDrugConditionModel source;
        private SimpleBindingManager<ChronicDrugConditionModel> bindingManager;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChronicDrugConditionModel Source
        {
            set
            {
                if (value != null)
                {
                    source = value;
                    tbName.Text = source.Name;
                    this.SimpleBinding(this.tbUseCount, "DailyTime", true, DataSourceUpdateMode.OnPropertyChanged);
                    this.SimpleBinding(this.tbDose, "EveryTimeMg", false, DataSourceUpdateMode.OnPropertyChanged);
                    this.SimpleBinding(this.txtjixing, "drugtype", false, DataSourceUpdateMode.OnPropertyChanged); 
                    if (string.IsNullOrEmpty(source.Name) == false)
                    {
                        tbUseCount.ReadOnly = false;
                        tbDose.ReadOnly = false;
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
    }
}
