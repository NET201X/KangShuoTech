using KangShuoTech.DataAccessProjects.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Femiani.Forms.UI.Input;
using System.Data;

namespace KangShuoTech.Utilities.CommonControl
{
    public class DoseUserControl : UserControl
    {
        private IContainer components;
        private List<InputRangeStr> inputrange_str;
        private Panel panel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private TextBox tbDose;
        private TextBox tbMothed;
        private CoolTextBox tbName;
        private ComboBox cbxYongyaosj;
        private DataTable dt_yw;
        BindingList<string> yysj;
        private TextBox tbjixing;
        private bool UState = false;

         public DoseUserControl()
        {
            this.InitializeComponent();
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("UseNum", 100));
            this.inputrange_str.Add(new InputRangeStr("PILLDEPENDENCE", 10));
            this.inputrange_str.Add(new InputRangeStr("MEDICINALNAME", 100));
            this.inputrange_str.Add(new InputRangeStr("drugtype",100));
            this.inputrange_str.Add(new InputRangeStr("factory", 100));
            yysj = new BindingList<string>();

            var cc = (new string[] {"一个月","三个月","六个月","一年","两年","三年","四年","五年","六年",
            "七年","八年","九年","十年","十五年","二十年","二十五年","三十年","四十年","五十年","六十年","七十年","八十年"});

            foreach ( var item in cc)
            {
                yysj.Add(item);
            }

            cbxYongyaosj.DataSource = yysj;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpSt_ValueChanged(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tbDose = new System.Windows.Forms.TextBox();
            this.tbMothed = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbName = new Femiani.Forms.UI.Input.CoolTextBox();
            this.cbxYongyaosj = new System.Windows.Forms.ComboBox();
            this.tbjixing = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton3.Location = new System.Drawing.Point(131, 5);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(74, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "不服药";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton2.Location = new System.Drawing.Point(67, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "间断";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton1.Location = new System.Drawing.Point(3, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "规律";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tbDose
            // 
            this.tbDose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDose.Font = new System.Drawing.Font("宋体", 12F);
            this.tbDose.Location = new System.Drawing.Point(235, 5);
            this.tbDose.MaxLength = 50;
            this.tbDose.Name = "tbDose";
            this.tbDose.ReadOnly = true;
            this.tbDose.Size = new System.Drawing.Size(254, 26);
            this.tbDose.TabIndex = 2;
            // 
            // tbMothed
            // 
            this.tbMothed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMothed.Font = new System.Drawing.Font("宋体", 12F);
            this.tbMothed.Location = new System.Drawing.Point(151, 4);
            this.tbMothed.MaxLength = 50;
            this.tbMothed.Name = "tbMothed";
            this.tbMothed.ReadOnly = true;
            this.tbMothed.Size = new System.Drawing.Size(77, 26);
            this.tbMothed.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Location = new System.Drawing.Point(707, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 30);
            this.panel1.TabIndex = 5;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tbName.Location = new System.Drawing.Point(5, 5);
            this.tbName.Name = "tbName";
            this.tbName.Padding = new System.Windows.Forms.Padding(4);
            this.tbName.PopupWidth = 120;
            this.tbName.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.tbName.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.tbName.Size = new System.Drawing.Size(140, 24);
            this.tbName.TabIndex = 0;
            // 
            // cbxYongyaosj
            // 
            this.cbxYongyaosj.Enabled = false;
            this.cbxYongyaosj.FormattingEnabled = true;
            this.cbxYongyaosj.Location = new System.Drawing.Point(591, 6);
            this.cbxYongyaosj.Name = "cbxYongyaosj";
            this.cbxYongyaosj.Size = new System.Drawing.Size(106, 22);
            this.cbxYongyaosj.TabIndex = 4;
            // 
            // tbjixing
            // 
            this.tbjixing.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbjixing.Font = new System.Drawing.Font("宋体", 12F);
            this.tbjixing.Location = new System.Drawing.Point(496, 5);
            this.tbjixing.MaxLength = 50;
            this.tbjixing.Name = "tbjixing";
            this.tbjixing.ReadOnly = true;
            this.tbjixing.Size = new System.Drawing.Size(89, 26);
            this.tbjixing.TabIndex = 3;
            // 
            // DoseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxYongyaosj);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbDose);
            this.Controls.Add(this.tbjixing);
            this.Controls.Add(this.tbMothed);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DoseUserControl";
            this.Size = new System.Drawing.Size(923, 34);
            this.Load += new System.EventHandler(this.DoseUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void UpdateSource()
        {
            source.MedicinalName = tbName.Text;
            source.UseAge = this.tbMothed.Text;
            source.UseNum = this.tbDose.Text;
            source.StartTime = cbxYongyaosj.Text.Trim();
            source.DrugType = this.tbjixing.Text.Trim();
            if (string.IsNullOrEmpty(tbName.Text.Trim())&& !radioButton1.Checked&&!radioButton2.Checked&&!radioButton3.Checked)
            {
                if (source.ModelState == RecordsStateModel.Unchanged)
                    source.ModelState = RecordsStateModel.DeleteInDB;
            }
            else
            {

                if (radioButton1.Checked)
                {
                    source.PillDependence = "1";
                }
                if (radioButton2.Checked)
                {
                    source.PillDependence = "2";
                }
                if (radioButton3.Checked)
                {
                    source.PillDependence = "3";
                }

                if (source.ModelState == RecordsStateModel.NoValue)
                {
                    source.ModelState = RecordsStateModel.AddToDB;
                }
                else
                {
                    source.ModelState = RecordsStateModel.UpdateInDB;
                }
            }
        }

        private void DoseUserControl_Load(object sender, EventArgs e)
        {
            tbName.SelectListItem += new EventHandler(tbName_SelectListItem);
            tbName.AutoTextChanged += new EventHandler(tbName_AutoTextChanged);

        }

        void tbName_AutoTextChanged(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                tbMothed.Text = "";
                tbDose.Text = "";
                tbjixing.Text = "";
                tbMothed.ReadOnly = true;
                tbDose.ReadOnly = true;
                tbjixing.ReadOnly = true;
                cbxYongyaosj.ResetText();
                cbxYongyaosj.Enabled = false;

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;

                //radioButton1.Enabled = false;
                //radioButton2.Enabled = false;
                //radioButton3.Enabled = false;
            }
            else
            {
                tbMothed.ReadOnly = false;
                tbDose.ReadOnly = false;
                tbjixing.ReadOnly = false;
                cbxYongyaosj.Enabled = true;

                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
        }

        void tbName_SelectListItem(object sender, EventArgs e)
        {
            foreach (DataRow item in dt_yw.Rows)
            {
                if (item["name"].ToString() == tbName.Text)
                {
                    string str1 ="";
                    tbMothed.Text = item["yongfa"].ToString();
                    tbjixing.Text = item["jixing"].ToString();
                    if (item["jiliang"].ToString() != "")
                    {
                        str1 = "每次" + item["jiliang"].ToString();
                        if (item["cishu"].ToString() != "")
                        {
                            str1 = str1 + "," + "每天" + item["cishu"].ToString() + "次";
                        }
                    }
                    else
                    {
                        if (item["cishu"].ToString() != "")
                        {
                            str1 = str1 + "每天" + item["cishu"].ToString() + "次";
                        }
                    }
                    tbDose.Text= str1;
                    break;
                }
            }
        }

        public void setSource(DataTable p_dt_yw )
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

        public bool ErrorInput
        {
            get
            {
                bool er = false;
                for (int i = 0; i < inputrange_str.Count; i++)
                {
                    if (inputrange_str[i].ErrorInput == true)
                    {
                        er = true;
                        break;
                    }
                }

                return er;
            }
        }

        public RecordsMedicationModel source {get;set;}
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RecordsMedicationModel Source
        {
            set
            {
                if (value != null)
                {
                    source = value;

                    tbName.Text = source.MedicinalName;
                    tbMothed.Text = source.UseAge;
                    tbDose.Text = source.UseNum;
                    tbjixing.Text = source.DrugType;
                    if (string.IsNullOrEmpty(source.StartTime))
                    {
                        cbxYongyaosj.SelectedIndex = -1;
                    }
                    else
                    {
                        if (cbxYongyaosj.Items.Contains(source.StartTime))
                        {
                            cbxYongyaosj.Text = source.StartTime;
                        }
                        else
                        {
                            yysj.Add(source.StartTime);
                            cbxYongyaosj.Text = source.StartTime;
                        }

                    }

                    switch (source.PillDependence)
                    {
                        case "1":
                            radioButton1.Checked = true;
                            break;
                        case "2":
                            radioButton2.Checked = true;
                            break;
                        case "3":
                            radioButton3.Checked = true;
                            break;
                        default:
                            break;
                    }

                    if (string.IsNullOrEmpty(source.MedicinalName) == false)
                    {
                        radioButton1.Enabled = true;
                        radioButton2.Enabled = true;
                        radioButton3.Enabled = true;

                        tbMothed.ReadOnly = false;
                        tbDose.ReadOnly = false;

                        cbxYongyaosj.Enabled = true;
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

        private void SimpleBinding(TextBox tb, string member)
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
    }
}

