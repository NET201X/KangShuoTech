using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
 
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Data;
    using System.Collections.Generic;
    using Femiani.Forms.UI.Input;
    using System.Text;

    public class YongYaoQKUserControlYC : UserControl
    {
        private IContainer components;
        private Label label3;
        private ChronicDrugConditionModel source = new ChronicDrugConditionModel();
        private CoolTextBox tbName;
        private bool UState;
        private TextBox tbjixing;
        private DataTable dt_yw1;
        private Label lbName;
        private Label label2;
        private TextBox tbyfyl;
        public ComboBox cbxFyycx;
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();

        public YongYaoQKUserControlYC()
        {
            this.InitializeComponent();
            this.ErrorInput = false;
        }

        public void UpdateSource()
        {
            source.Name = tbName.Text;
            source.DosAge = this.tbyfyl.Text.Trim();

            if (this.tbName.Text.Trim() == "")
            {
                if (this.source.ModelState == RecordsStateModel.Unchanged)
                {
                    this.source.ModelState = RecordsStateModel.DeleteInDB;
                }
            }
            else
            {
                this.source.Name = this.tbName.Text.Trim();

                if (this.source.ModelState == RecordsStateModel.Unchanged)
                {
                    this.source.ModelState = RecordsStateModel.UpdateInDB;
                }
                if (this.source.ModelState == RecordsStateModel.NoValue)
                {
                    this.source.ModelState = RecordsStateModel.AddToDB;
                }
            }
        }

        private void YongYaoQKUserControlYC_Load(object sender, EventArgs e)
        {
            tbName.SelectListItem += new EventHandler(tbName_SelectListItem);
            tbName.AutoTextChanged += new EventHandler(tbName_AutoTextChanged);
        }

        void tbName_AutoTextChanged(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                tbyfyl.Text = "";
                tbyfyl.ReadOnly = true;
            }
            else
            {
                tbyfyl.ReadOnly = false;
                cbxFyycx.SelectedIndex = 0;
            }
        }

        void tbName_SelectListItem(object sender, EventArgs e)
        {
            foreach (DataRow item in dt_yw1.Rows)
            {
                if (item["name"].ToString() == tbName.Text)
                {
                    tbyfyl.Text ="每日"+ item["cishu"].ToString()+"次" + "每次"+ item["jiliang"].ToString()+"mg"; //用法用量
                    break;
                }
            }
        }

        public void setSource(DataTable p_dt_yw1)
        {
            this.dt_yw1 = p_dt_yw1;
            foreach (DataRow item in dt_yw1.Rows)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new Femiani.Forms.UI.Input.CoolTextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbyfyl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 14);
            this.label3.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tbName.Location = new System.Drawing.Point(90, 2);
            this.tbName.Name = "tbName";
            this.tbName.Padding = new System.Windows.Forms.Padding(4);
            this.tbName.PopupWidth = 120;
            this.tbName.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.tbName.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.tbName.Size = new System.Drawing.Size(148, 24);
            this.tbName.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(3, 7);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(42, 14);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "药物1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "用法用量";
            // 
            // tbyfyl
            // 
            this.tbyfyl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbyfyl.Location = new System.Drawing.Point(356, 3);
            this.tbyfyl.MaxLength = 100;
            this.tbyfyl.Name = "tbyfyl";
            this.tbyfyl.ReadOnly = true;
            this.tbyfyl.Size = new System.Drawing.Size(131, 23);
            this.tbyfyl.TabIndex = 3;
            // 
            // YongYaoQKUserControlYC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbyfyl);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "YongYaoQKUserControlYC";
            this.Size = new System.Drawing.Size(502, 29);
            this.Load += new System.EventHandler(this.YongYaoQKUserControlYC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public bool ErrorInput { get; set; }
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
                    tbyfyl.Text = source.DosAge;
                  //  this.SimpleBinding(this.tbyfyl, "DosAge", true, DataSourceUpdateMode.OnPropertyChanged);

                    if (string.IsNullOrEmpty(source.Name) == false)
                    {
                        tbyfyl.ReadOnly = false;
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

        public string MText
        {
            get
            {
                return this.lbName.Text;
            }
            set
            {
                this.lbName.Text = value;
            }
        }
    }
}