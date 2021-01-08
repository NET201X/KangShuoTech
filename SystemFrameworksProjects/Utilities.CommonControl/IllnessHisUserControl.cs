using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class IllnessHisUserControl : UserControl
    {
        public RecordsBaseInfoModel baseinfo;
        public CheckBox c1;
        public CheckBox c10;
        public CheckBox c11;
        public CheckBox c12;
        public CheckBox c13;
        public CheckBox c2;
        public CheckBox c3;
        public CheckBox c4;
        public CheckBox c5;
        public CheckBox c6;
        public CheckBox c7;
        public CheckBox c8;
        public CheckBox c9;
        private List<CheckBox> cks = new List<CheckBox>();
        public static Dictionary<string, string> ckV_M = new Dictionary<string, string>();
        private IContainer components;
        private DateTimePicker dtp1;
        private DateTimePicker dtp2;
        private DateTimePicker dtp3;
        private DateTimePicker dtp4;
        private DateTimePicker dtp5;
        private DateTimePicker dtp6;
        private FlowLayoutPanel flowLayoutPanel1;
        private string idcard;
        private List<illItem> illItems = new List<illItem>();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private List<RecordsIllnessHistoryInfoModel> source;
        private SplitContainer splitContainer1;
        private TextBox tb1;
        private TextBox tb2;
        private TextBox tb3;
        private TextBox tb4;
        private TextBox tb5;
        private TextBox tb6;
        string IDCardType = ConfigHelper.GetNode("IdCardType");
        public IllnessHisUserControl()
        {
            this.InitializeComponent();
            if (IDCardType.Equals("3"))//二代机
            {
                SetFont(this);
                this.splitContainer1.SplitterDistance = 79;
            }
            this.InitControl();
          
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

        private void c1_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = !this.c1.Checked;
            foreach (CheckBox box in this.cks)
            {
                if (box.Name != this.c1.Name)
                {
                    box.Enabled = flag;
                    box.CheckState = CheckState.Unchecked;
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

        private void InitControl()
        {
            this.cks.AddRange((IEnumerable<CheckBox>) new CheckBox[] { this.c1, this.c2, this.c3, this.c4, this.c5, this.c6, this.c7, this.c8, this.c9, this.c10, this.c11, this.c12, this.c13 });
            if (ckV_M.Count == 0)
            {
                ckV_M.Add("1", this.c1.Text);
                ckV_M.Add("2", this.c2.Text);
                ckV_M.Add("3", this.c3.Text);
                ckV_M.Add("4", this.c4.Text);
                ckV_M.Add("5", this.c5.Text);
                ckV_M.Add("6", this.c6.Text);
                ckV_M.Add("7", this.c7.Text);
                ckV_M.Add("8", this.c8.Text);
                ckV_M.Add("9", this.c9.Text);
                ckV_M.Add("10", this.c10.Text);
                ckV_M.Add("11", this.c11.Text);
                ckV_M.Add("12", this.c12.Text);
                ckV_M.Add("13", this.c13.Text);
            }
            for (int i = 0; i < this.cks.Count; i++)
            {
                this.cks[i].Tag = string.Format("{0}", i + 1);
            }
            this.illItems.AddRange((IEnumerable<illItem>) new illItem[] { new illItem(this.tb1, this.dtp1), new illItem(this.tb2, this.dtp2), new illItem(this.tb3, this.dtp3), new illItem(this.tb4, this.dtp4), new illItem(this.tb5, this.dtp5), new illItem(this.tb6, this.dtp6) });
        }

        private void InitializeComponent()
        {
            this.c1 = new System.Windows.Forms.CheckBox();
            this.c2 = new System.Windows.Forms.CheckBox();
            this.c3 = new System.Windows.Forms.CheckBox();
            this.c4 = new System.Windows.Forms.CheckBox();
            this.c5 = new System.Windows.Forms.CheckBox();
            this.c6 = new System.Windows.Forms.CheckBox();
            this.c7 = new System.Windows.Forms.CheckBox();
            this.c8 = new System.Windows.Forms.CheckBox();
            this.c9 = new System.Windows.Forms.CheckBox();
            this.c10 = new System.Windows.Forms.CheckBox();
            this.c11 = new System.Windows.Forms.CheckBox();
            this.c12 = new System.Windows.Forms.CheckBox();
            this.c13 = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtp3 = new System.Windows.Forms.DateTimePicker();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.dtp4 = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtp5 = new System.Windows.Forms.DateTimePicker();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtp6 = new System.Windows.Forms.DateTimePicker();
            this.tb6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1
            // 
            this.c1.AutoSize = true;
            this.c1.Font = new System.Drawing.Font("宋体", 10F);
            this.c1.Location = new System.Drawing.Point(4, 4);
            this.c1.Margin = new System.Windows.Forms.Padding(4);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(40, 18);
            this.c1.TabIndex = 0;
            this.c1.Text = "无";
            this.c1.UseVisualStyleBackColor = true;
            this.c1.CheckedChanged += new System.EventHandler(this.c1_CheckedChanged);
            // 
            // c2
            // 
            this.c2.AutoSize = true;
            this.c2.Font = new System.Drawing.Font("宋体", 10F);
            this.c2.Location = new System.Drawing.Point(52, 4);
            this.c2.Margin = new System.Windows.Forms.Padding(4);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(68, 18);
            this.c2.TabIndex = 1;
            this.c2.Text = "高血压";
            this.c2.UseVisualStyleBackColor = true;
            // 
            // c3
            // 
            this.c3.AutoSize = true;
            this.c3.Font = new System.Drawing.Font("宋体", 10F);
            this.c3.Location = new System.Drawing.Point(128, 4);
            this.c3.Margin = new System.Windows.Forms.Padding(4);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(68, 18);
            this.c3.TabIndex = 2;
            this.c3.Text = "糖尿病";
            this.c3.UseVisualStyleBackColor = true;
            // 
            // c4
            // 
            this.c4.AutoSize = true;
            this.c4.Font = new System.Drawing.Font("宋体", 10F);
            this.c4.Location = new System.Drawing.Point(204, 4);
            this.c4.Margin = new System.Windows.Forms.Padding(4);
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(68, 18);
            this.c4.TabIndex = 3;
            this.c4.Text = "冠心病";
            this.c4.UseVisualStyleBackColor = true;
            // 
            // c5
            // 
            this.c5.AutoSize = true;
            this.c5.Font = new System.Drawing.Font("宋体", 10F);
            this.c5.Location = new System.Drawing.Point(280, 4);
            this.c5.Margin = new System.Windows.Forms.Padding(4);
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(124, 18);
            this.c5.TabIndex = 4;
            this.c5.Text = "慢性阻塞性肺病";
            this.c5.UseVisualStyleBackColor = true;
            // 
            // c6
            // 
            this.c6.AutoSize = true;
            this.c6.Font = new System.Drawing.Font("宋体", 10F);
            this.c6.Location = new System.Drawing.Point(412, 4);
            this.c6.Margin = new System.Windows.Forms.Padding(4);
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(82, 18);
            this.c6.TabIndex = 5;
            this.c6.Text = "恶性肿瘤";
            this.c6.UseVisualStyleBackColor = true;
            // 
            // c7
            // 
            this.c7.AutoSize = true;
            this.c7.Font = new System.Drawing.Font("宋体", 10F);
            this.c7.Location = new System.Drawing.Point(502, 4);
            this.c7.Margin = new System.Windows.Forms.Padding(4);
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(68, 18);
            this.c7.TabIndex = 6;
            this.c7.Text = "脑卒中";
            this.c7.UseVisualStyleBackColor = true;
            // 
            // c8
            // 
            this.c8.AutoSize = true;
            this.c8.Font = new System.Drawing.Font("宋体", 10F);
            this.c8.Location = new System.Drawing.Point(578, 4);
            this.c8.Margin = new System.Windows.Forms.Padding(4);
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(110, 18);
            this.c8.TabIndex = 7;
            this.c8.Text = "严重精神障碍";
            this.c8.UseVisualStyleBackColor = true;
            // 
            // c9
            // 
            this.c9.AutoSize = true;
            this.c9.Font = new System.Drawing.Font("宋体", 10F);
            this.c9.Location = new System.Drawing.Point(4, 30);
            this.c9.Margin = new System.Windows.Forms.Padding(4);
            this.c9.Name = "c9";
            this.c9.Size = new System.Drawing.Size(68, 18);
            this.c9.TabIndex = 8;
            this.c9.Text = "结核病";
            this.c9.UseVisualStyleBackColor = true;
            // 
            // c10
            // 
            this.c10.AutoSize = true;
            this.c10.Font = new System.Drawing.Font("宋体", 10F);
            this.c10.Location = new System.Drawing.Point(80, 30);
            this.c10.Margin = new System.Windows.Forms.Padding(4);
            this.c10.Name = "c10";
            this.c10.Size = new System.Drawing.Size(54, 18);
            this.c10.TabIndex = 9;
            this.c10.Text = "肝炎";
            this.c10.UseVisualStyleBackColor = true;
            // 
            // c11
            // 
            this.c11.AutoSize = true;
            this.c11.Font = new System.Drawing.Font("宋体", 10F);
            this.c11.Location = new System.Drawing.Point(142, 30);
            this.c11.Margin = new System.Windows.Forms.Padding(4);
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(124, 18);
            this.c11.TabIndex = 10;
            this.c11.Text = "其他法定传染病";
            this.c11.UseVisualStyleBackColor = true;
            // 
            // c12
            // 
            this.c12.AutoSize = true;
            this.c12.Font = new System.Drawing.Font("宋体", 10F);
            this.c12.Location = new System.Drawing.Point(274, 30);
            this.c12.Margin = new System.Windows.Forms.Padding(4);
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(68, 18);
            this.c12.TabIndex = 11;
            this.c12.Text = "职业病";
            this.c12.UseVisualStyleBackColor = true;
            // 
            // c13
            // 
            this.c13.AutoSize = true;
            this.c13.Font = new System.Drawing.Font("宋体", 10F);
            this.c13.Location = new System.Drawing.Point(350, 30);
            this.c13.Margin = new System.Windows.Forms.Padding(4);
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(54, 18);
            this.c13.TabIndex = 12;
            this.c13.Text = "其他";
            this.c13.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(766, 130);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 57;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.c1);
            this.flowLayoutPanel1.Controls.Add(this.c2);
            this.flowLayoutPanel1.Controls.Add(this.c3);
            this.flowLayoutPanel1.Controls.Add(this.c4);
            this.flowLayoutPanel1.Controls.Add(this.c5);
            this.flowLayoutPanel1.Controls.Add(this.c6);
            this.flowLayoutPanel1.Controls.Add(this.c7);
            this.flowLayoutPanel1.Controls.Add(this.c8);
            this.flowLayoutPanel1.Controls.Add(this.c9);
            this.flowLayoutPanel1.Controls.Add(this.c10);
            this.flowLayoutPanel1.Controls.Add(this.c11);
            this.flowLayoutPanel1.Controls.Add(this.c12);
            this.flowLayoutPanel1.Controls.Add(this.c13);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(766, 50);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Controls.Add(this.tb1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 31);
            this.panel1.TabIndex = 0;
            // 
            // dtp1
            // 
            this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(144, 4);
            this.dtp1.Margin = new System.Windows.Forms.Padding(4);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(102, 23);
            this.dtp1.TabIndex = 46;
            // 
            // tb1
            // 
            this.tb1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb1.Location = new System.Drawing.Point(3, 4);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(132, 23);
            this.tb1.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtp2);
            this.panel2.Controls.Add(this.tb2);
            this.panel2.Location = new System.Drawing.Point(258, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 31);
            this.panel2.TabIndex = 1;
            // 
            // dtp2
            // 
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(140, 4);
            this.dtp2.Margin = new System.Windows.Forms.Padding(4);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(102, 23);
            this.dtp2.TabIndex = 50;
            // 
            // tb2
            // 
            this.tb2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb2.Location = new System.Drawing.Point(4, 4);
            this.tb2.Margin = new System.Windows.Forms.Padding(4);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(132, 23);
            this.tb2.TabIndex = 49;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtp3);
            this.panel3.Controls.Add(this.tb3);
            this.panel3.Location = new System.Drawing.Point(512, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 31);
            this.panel3.TabIndex = 2;
            // 
            // dtp3
            // 
            this.dtp3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp3.Location = new System.Drawing.Point(140, 4);
            this.dtp3.Margin = new System.Windows.Forms.Padding(4);
            this.dtp3.Name = "dtp3";
            this.dtp3.Size = new System.Drawing.Size(102, 23);
            this.dtp3.TabIndex = 52;
            // 
            // tb3
            // 
            this.tb3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb3.Location = new System.Drawing.Point(4, 4);
            this.tb3.Margin = new System.Windows.Forms.Padding(4);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(132, 23);
            this.tb3.TabIndex = 51;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tb4);
            this.panel4.Controls.Add(this.dtp4);
            this.panel4.Location = new System.Drawing.Point(4, 43);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 31);
            this.panel4.TabIndex = 3;
            // 
            // tb4
            // 
            this.tb4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb4.Location = new System.Drawing.Point(3, 4);
            this.tb4.Margin = new System.Windows.Forms.Padding(4);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(132, 23);
            this.tb4.TabIndex = 53;
            // 
            // dtp4
            // 
            this.dtp4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp4.Location = new System.Drawing.Point(144, 3);
            this.dtp4.Margin = new System.Windows.Forms.Padding(4);
            this.dtp4.Name = "dtp4";
            this.dtp4.Size = new System.Drawing.Size(102, 23);
            this.dtp4.TabIndex = 54;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtp5);
            this.panel5.Controls.Add(this.tb5);
            this.panel5.Location = new System.Drawing.Point(258, 43);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(246, 31);
            this.panel5.TabIndex = 4;
            // 
            // dtp5
            // 
            this.dtp5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp5.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp5.Location = new System.Drawing.Point(140, 4);
            this.dtp5.Margin = new System.Windows.Forms.Padding(4);
            this.dtp5.Name = "dtp5";
            this.dtp5.Size = new System.Drawing.Size(102, 23);
            this.dtp5.TabIndex = 56;
            // 
            // tb5
            // 
            this.tb5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb5.Location = new System.Drawing.Point(4, 5);
            this.tb5.Margin = new System.Windows.Forms.Padding(4);
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(132, 23);
            this.tb5.TabIndex = 55;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtp6);
            this.panel6.Controls.Add(this.tb6);
            this.panel6.Location = new System.Drawing.Point(512, 43);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(246, 31);
            this.panel6.TabIndex = 5;
            // 
            // dtp6
            // 
            this.dtp6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp6.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp6.Location = new System.Drawing.Point(140, 4);
            this.dtp6.Margin = new System.Windows.Forms.Padding(4);
            this.dtp6.Name = "dtp6";
            this.dtp6.Size = new System.Drawing.Size(102, 23);
            this.dtp6.TabIndex = 58;
            // 
            // tb6
            // 
            this.tb6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb6.Location = new System.Drawing.Point(4, 4);
            this.tb6.Margin = new System.Windows.Forms.Padding(4);
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(132, 23);
            this.tb6.TabIndex = 57;
            // 
            // IllnessHisUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IllnessHisUserControl";
            this.Size = new System.Drawing.Size(766, 130);
            this.Load += new System.EventHandler(this.UCIllnessHis_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        private void UCIllnessHis_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (!box.Checked)
            {
                for (int i = 0; i < this.source.Count; i++)
                {
                    if (this.source[i].IllnessName == box.Tag.ToString())
                    {
                        this.source[i].RecordState = (this.source[i].RecordState != RecordsStateModel.AddToDB) ? RecordsStateModel.DeleteInDB : RecordsStateModel.NoValue;
                        foreach (illItem item2 in this.illItems)
                        {
                            if (item2.Info == this.source[i])
                            {
                                item2.Info = null;
                            }
                        }
                    }
                }
                if (this.illItems.Count<illItem>(h => (h.Info != null)) < 6)
                {
                    foreach (CheckBox box3 in this.cks)
                    {
                        if (!box3.Checked && !this.c1.Checked)
                        {
                            box3.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                string inputString = "";
                if (((box.Text == "职业病") || (box.Text == "恶性肿瘤")) || (box.Text == "其他"))
                {
                    InputFormEx ex = new InputFormEx {
                        StartPosition = FormStartPosition.CenterScreen,
                        CanBeNull = true,
                        MaxBytesCount = 200,
                        MCaption = "输入疾病名称:"
                    };
                    if (ex.ShowDialog() == DialogResult.OK)
                    {
                        inputString = ex.InputString;
                    }
                }
                string str2 = "";
                string text = box.Text;
                if (text != null)
                {
                    if (!(text == "高血压"))
                    {
                        if (text == "糖尿病")
                        {
                            str2 = "7";
                        }
                        else if (text == "冠心病")
                        {
                            str2 = "8";
                        }
                        else if (text == "脑卒中")
                        {
                            str2 = "9";
                        }
                        else if (text == "严重精神障碍")
                        {
                            str2 = "5";
                        }
                    }
                    else
                    {
                        str2 = "6";
                    }
                }
                string strtext = "";
                strtext = box.Text;
                if (box.Text == "严重精神障碍")
                {
                    strtext = "重性精神疾病";
                }

                if ((!string.IsNullOrEmpty(str2) && this.baseinfo != null && !this.baseinfo.PopulationType.Contains(str2)) && (MessageBox.Show("是否将人员列入" + strtext + "人群?", "人群划分", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    this.baseinfo.PopulationType = !(this.baseinfo.PopulationType == "1") ? (this.baseinfo.PopulationType + "," + str2) : str2;
                }
                bool flag = false;
                RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel = null;
                for (int j = 0; j < this.source.Count; j++)
                {
                    if (this.source[j].IllnessName == box.Tag.ToString())
                    {
                        this.source[j].RecordState = (this.source[j].RecordState != RecordsStateModel.DeleteInDB) ? RecordsStateModel.AddToDB : RecordsStateModel.UpdateInDB;
                        flag = true;
                        recordsIllnessHistoryInfoModel = this.source[j];
                        break;
                    }
                }
                if (!flag)
                {
                    recordsIllnessHistoryInfoModel = new RecordsIllnessHistoryInfoModel
                    {
                        IllnessType = "1",
                        IllnessName = box.Tag.ToString(),
                        RecordState = RecordsStateModel.AddToDB
                    };
                    recordsIllnessHistoryInfoModel.RecordID = this.ArchiveID;
                    recordsIllnessHistoryInfoModel.IDCardNo = this.IDCard;
                    this.source.Add(recordsIllnessHistoryInfoModel);
                }
                foreach (illItem item in this.illItems)
                {
                    if (item.Info == null)
                    {
                        if (!string.IsNullOrEmpty(inputString))
                        {
                            if (recordsIllnessHistoryInfoModel.IllnessName == "6")
                            {
                                recordsIllnessHistoryInfoModel.Therioma = inputString;
                            }
                            if (recordsIllnessHistoryInfoModel.IllnessName == "12")
                            {
                                recordsIllnessHistoryInfoModel.JobIllness = inputString;
                            }
                            if (recordsIllnessHistoryInfoModel.IllnessName == "13")
                            {
                                recordsIllnessHistoryInfoModel.IllnessOther = inputString;
                            }
                        }
                        item.Info = recordsIllnessHistoryInfoModel;
                        break;
                    }
                }
                if (this.illItems.Count<illItem>(h => (h.Info != null)) == 6)
                {
                    foreach (CheckBox box2 in this.cks)
                    {
                        if (!box2.Checked && (box2.Name != this.c1.Name))
                        {
                            box2.Enabled = false;
                        }
                    }
                }
            }
        }

        private void UCIllnessHis_Load(object sender, EventArgs e)
        {

        }

        public void UpdateSource()
        {
            for (int i = 0; i < this.illItems.Count; i++)
            {
                this.illItems[i].UpdateInfo();
            }
            int num2 = this.source.Count<RecordsIllnessHistoryInfoModel>(ct => ct.IllnessName == "1");
            if (this.c1.Checked)
            {
                if (num2 == 0)
                {
                    RecordsIllnessHistoryInfoModel item = new RecordsIllnessHistoryInfoModel {
                        RecordState = RecordsStateModel.AddToDB,
                        IllnessType = "1",
                        IllnessName = "1"
                    };
                    this.source.Add(item);
                }
            }
            else if (num2 > 0)
            {
                this.source.First<RecordsIllnessHistoryInfoModel>(ab => (ab.IllnessName == "1")).RecordState = RecordsStateModel.DeleteInDB;
            }
        }

        public string ArchiveID { get; set; }

        public string IDCard { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public List<RecordsIllnessHistoryInfoModel> Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
                if (this.source != null)
                {
                    if (this.source.Count<RecordsIllnessHistoryInfoModel>(b => (b.IllnessName == "1")) > 0)
                    {
                        this.c1.Checked = true;
                    }
                    int num = 0;
                    foreach (RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel in this.source)
                    {
                        int num2;
                        if (int.TryParse(recordsIllnessHistoryInfoModel.IllnessName, out num2) && (num2 >= 2))
                        {
                            this.cks[num2 - 1].Checked = true;
                        }
                        if (num2 >= 2)
                        {
                            this.illItems[num++].Info = recordsIllnessHistoryInfoModel;
                        }
                    }
                    if (num == 6)
                    {
                        foreach (CheckBox box in this.cks)
                        {
                            if (!box.Checked && (box.Name != this.c1.Name))
                            {
                                box.Enabled = false;
                            }
                        }
                    }
                    for (int i = 1; i < this.cks.Count; i++)
                    {
                        this.cks[i].CheckedChanged += new EventHandler(this.UCIllnessHis_CheckedChanged);
                    }
                }
                else
                {
                    for (int j = 0; j < this.illItems.Count; j++)
                    {
                        this.illItems[j].Info = null;
                    }
                }
            }
        }

        internal class illItem
        {
            private RecordsIllnessHistoryInfoModel info;

            public illItem(TextBox t, DateTimePicker d)
            {
                this.tb = t;
                this.dtp = d;
                this.dtp.MaxDate = DateTime.Today;
                this.tb.ReadOnly = true;
                this.dtp.Enabled = false;
            }

            private void dtp_ValueChanged(object sender, EventArgs e)
            {
                if (this.info != null)
                {
                    this.info.DiagnoseTime = new DateTime?(this.dtp.Value.Date);
                }
            }

            public void UpdateInfo()
            {
                if (this.info != null)
                {
                    if (this.info.ID == 0)
                    {
                        this.info.DiagnoseTime = new DateTime?(this.dtp.Value.Date);
                    }
                    else
                    {
                        DateTime? dIAGNOSETIME = this.info.DiagnoseTime;
                        DateTime date = this.dtp.Value.Date;
                        if ((!dIAGNOSETIME.HasValue ? 1 : ((dIAGNOSETIME.GetValueOrDefault() != date) ? 1 : 0)) != 0)
                        {
                            this.info.RecordState = RecordsStateModel.UpdateInDB;
                            this.info.DiagnoseTime = new DateTime?(this.dtp.Value.Date);
                        }
                    }
                }
            }

            public DateTimePicker dtp { get; set; }

            public RecordsIllnessHistoryInfoModel Info
            {
                get
                {
                    return this.info;
                }
                set
                {
                    this.info = value;
                    if (this.info == null)
                    {
                        this.tb.Text = "";
                        this.dtp.Value = DateTime.Today;
                        this.dtp.Enabled = false;
                    }
                    else
                    {
                        string str;
                        if (IllnessHisUserControl.ckV_M.TryGetValue(this.info.IllnessName, out str))
                        {
                            this.tb.Text = str;
                            if (!string.IsNullOrEmpty(this.info.Therioma))
                            {
                                TextBox tb = this.tb;
                                string str2 = tb.Text + string.Format("({0})", this.info.Therioma);
                                tb.Text = str2;
                            }
                            if (!string.IsNullOrEmpty(this.info.JobIllness))
                            {
                                TextBox box2 = this.tb;
                                string str3 = box2.Text + string.Format("({0})", this.info.JobIllness);
                                box2.Text = str3;
                            }
                            if (!string.IsNullOrEmpty(this.info.IllnessOther))
                            {
                                TextBox box3 = this.tb;
                                string str4 = box3.Text + string.Format("({0})", this.info.IllnessOther);
                                box3.Text = str4;
                            }
                            this.dtp.Enabled = true;
                            if (this.info.DiagnoseTime.HasValue)
                            {
                                this.dtp.Value = this.info.DiagnoseTime.Value;
                            }
                        }
                    }
                }
            }

            public TextBox tb { get; set; }
        }
        //获取设置的默认项
        //返回字符串的格式： 诊断日期;IllnessName字段内容;Therioma字段内容;IllnessOther字段内容;JobIllness字段内容&（下一条内容）
        public string GetDefault()
        {
            string strRe = "";
            UpdateSource();
            for (int i = 0; i < this.illItems.Count; i++)
            {
                this.illItems[i].UpdateInfo();
            }
            if (this.c1.Checked)
            {
                strRe = "无";
            }
            else
            {
                foreach (RecordsIllnessHistoryInfoModel rs in this.source)
                {
                    if (rs.RecordState == RecordsStateModel.DeleteInDB)
                    {
                        continue;
                    }
                    strRe += rs.DiagnoseTime.Value.ToShortDateString() + ";";
                    strRe += string.IsNullOrEmpty(rs.IllnessName) ? ";" : rs.IllnessName + ";";
                    strRe += string.IsNullOrEmpty(rs.Therioma) ? ";" : rs.Therioma + ";";
                    strRe += string.IsNullOrEmpty(rs.IllnessOther) ? ";" : rs.IllnessOther + ";";
                    strRe += string.IsNullOrEmpty(rs.JobIllness) ? ";" : rs.JobIllness;
                    strRe += "&";
                }
                strRe = string.IsNullOrEmpty(strRe) ? "" : strRe.Remove(strRe.Length - 1);
            }

            return strRe;
        }
    }
}

