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

    public class YongYaoQKUserControl : UserControl
    {
        private IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbName;
        private ChronicDrugConditionModel source = new ChronicDrugConditionModel ();
        private TextBox tbCount;
        private TextBox tbMg;
        private Femiani.Forms.UI.Input.CoolTextBox tbName;
        private bool UState;
        private Label label5;
        private TextBox tbjixing;
        private DataTable dt_yw;
        public ComboBox cbxFyycx;
        private List<InputRangeStr> inputrange_str = new List<InputRangeStr>();

        public YongYaoQKUserControl()
        {
            this.InitializeComponent();
            this.ErrorInput = false;
        }

        private void YongYaoQKUserControl_Load(object sender, EventArgs e)
        {
            tbName.SelectListItem += new EventHandler(tbName_SelectListItem);
            tbName.AutoTextChanged += new EventHandler(tbName_AutoTextChanged);
        }

        void tbName_AutoTextChanged(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                tbCount.Text = "";
                tbMg.Text = "";
                tbjixing.Text = "";
                tbCount.ReadOnly = true;
                tbMg.ReadOnly = true;
                tbjixing.ReadOnly = true;
            }
            else
            {
                tbCount.ReadOnly = false;
                tbMg.ReadOnly = false;
                tbjixing.ReadOnly = false;
                cbxFyycx.SelectedIndex = 0;
            }
        }

        void tbName_SelectListItem(object sender, EventArgs e)
        {
            foreach (DataRow item in dt_yw.Rows)
            {
                if (item["name"].ToString() == tbName.Text)
                {
                    tbCount.Text = item["cishu"].ToString();
                    tbMg.Text = item["jiliang"].ToString();
                    tbjixing.Text = item["jixing"].ToString();
                    break;
                }
            }
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
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMg = new System.Windows.Forms.TextBox();
            this.tbName = new Femiani.Forms.UI.Input.CoolTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbjixing = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(3, 6);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(42, 14);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "药物1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "每日";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(210, 3);
            this.tbCount.MaxLength = 2;
            this.tbCount.Name = "tbCount";
            this.tbCount.ReadOnly = true;
            this.tbCount.Size = new System.Drawing.Size(32, 23);
            this.tbCount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "次";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 14);
            this.label3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "剂量";
            // 
            // tbMg
            // 
            this.tbMg.Location = new System.Drawing.Point(298, 3);
            this.tbMg.MaxLength = 100;
            this.tbMg.Name = "tbMg";
            this.tbMg.ReadOnly = true;
            this.tbMg.Size = new System.Drawing.Size(56, 23);
            this.tbMg.TabIndex = 6;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tbName.Location = new System.Drawing.Point(76, 2);
            this.tbName.Name = "tbName";
            this.tbName.Padding = new System.Windows.Forms.Padding(4);
            this.tbName.PopupWidth = 120;
            this.tbName.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.tbName.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.tbName.Size = new System.Drawing.Size(98, 24);
            this.tbName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "剂型";
            // 
            // tbjixing
            // 
            this.tbjixing.Location = new System.Drawing.Point(396, 3);
            this.tbjixing.MaxLength = 100;
            this.tbjixing.Name = "tbjixing";
            this.tbjixing.ReadOnly = true;
            this.tbjixing.Size = new System.Drawing.Size(63, 23);
            this.tbjixing.TabIndex = 9;
            // 
            // YongYaoQKUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbjixing);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.lbName);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "YongYaoQKUserControl";
            this.Size = new System.Drawing.Size(465, 29);
            this.Load += new System.EventHandler(this.YongYaoQKUserControl_Load);
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

                    this.SimpleBinding(this.tbCount, "DailyTime", true, DataSourceUpdateMode.OnPropertyChanged);
                    this.SimpleBinding(this.tbMg, "EveryTimeMg", false, DataSourceUpdateMode.OnPropertyChanged);
                    this.SimpleBinding(this.tbjixing,"drugtype",false ,DataSourceUpdateMode.OnPropertyChanged);

                    if (string.IsNullOrEmpty(source.Name) == false)
                    {
                        tbCount.ReadOnly = false;
                        tbMg.ReadOnly = false;
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