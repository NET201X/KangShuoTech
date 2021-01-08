namespace HealthHouse
{
    partial class GuideQueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckCheckDate = new System.Windows.Forms.CheckBox();
            this.dtpCreatedDateEd = new System.Windows.Forms.DateTimePicker();
            this.dtpEd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ckxCreatedDate = new System.Windows.Forms.CheckBox();
            this.dtpSt = new System.Windows.Forms.DateTimePicker();
            this.dtpCreatedDateSt = new System.Windows.Forms.DateTimePicker();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdNum = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFront = new System.Windows.Forms.Button();
            this.lbPages = new System.Windows.Forms.Label();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HealthGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateMenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.ckCheckDate);
            this.groupBox1.Controls.Add(this.dtpCreatedDateEd);
            this.groupBox1.Controls.Add(this.dtpEd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ckxCreatedDate);
            this.groupBox1.Controls.Add(this.dtpSt);
            this.groupBox1.Controls.Add(this.dtpCreatedDateSt);
            this.groupBox1.Controls.Add(this.cbxUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbAddr);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIdNum);
            this.groupBox1.Location = new System.Drawing.Point(106, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1125, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // ckCheckDate
            // 
            this.ckCheckDate.AutoSize = true;
            this.ckCheckDate.Location = new System.Drawing.Point(15, 69);
            this.ckCheckDate.Name = "ckCheckDate";
            this.ckCheckDate.Size = new System.Drawing.Size(118, 24);
            this.ckCheckDate.TabIndex = 137;
            this.ckCheckDate.Text = "体检日期:";
            this.ckCheckDate.UseVisualStyleBackColor = true;
            this.ckCheckDate.CheckedChanged += new System.EventHandler(this.ckCheckDate_CheckedChanged);
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(915, 67);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(160, 30);
            this.dtpCreatedDateEd.TabIndex = 8;
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Location = new System.Drawing.Point(371, 67);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(160, 30);
            this.dtpEd.TabIndex = 139;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(875, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 140;
            this.label5.Text = "—";
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(573, 69);
            this.ckxCreatedDate.Name = "ckxCreatedDate";
            this.ckxCreatedDate.Size = new System.Drawing.Size(118, 24);
            this.ckxCreatedDate.TabIndex = 6;
            this.ckxCreatedDate.Text = "建档日期:";
            this.ckxCreatedDate.UseVisualStyleBackColor = true;
            this.ckxCreatedDate.CheckedChanged += new System.EventHandler(this.ckxCreatedDate_CheckedChanged);
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Location = new System.Drawing.Point(169, 67);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(160, 30);
            this.dtpSt.TabIndex = 138;
            // 
            // dtpCreatedDateSt
            // 
            this.dtpCreatedDateSt.Enabled = false;
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(711, 67);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(160, 30);
            this.dtpCreatedDateSt.TabIndex = 7;
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(928, 25);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(153, 28);
            this.cbxUser.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(831, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "建档人:";
            // 
            // tbAddr
            // 
            this.tbAddr.Location = new System.Drawing.Point(512, 24);
            this.tbAddr.MaxLength = 20;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(247, 30);
            this.tbAddr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "住址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名或身份证:";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Location = new System.Drawing.Point(169, 25);
            this.txtIdNum.MaxLength = 21;
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(199, 30);
            this.txtIdNum.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 32;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.CustomerName,
            this.Sex,
            this.IDCardNo,
            this.Summary,
            this.HealthGuid,
            this.MedGuid,
            this.CreateMenName,
            this.CreateDate,
            this.Column6,
            this.Column5,
            this.Column4});
            this.dgvData.Location = new System.Drawing.Point(106, 136);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.RowTemplate.Height = 41;
            this.dgvData.Size = new System.Drawing.Size(1314, 455);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1242, 37);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 82);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1320, 600);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 36);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(1214, 600);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(100, 36);
            this.btnFront.TabIndex = 3;
            this.btnFront.Text = "上一页";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // lbPages
            // 
            this.lbPages.AutoSize = true;
            this.lbPages.Location = new System.Drawing.Point(1000, 608);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(59, 20);
            this.lbPages.TabIndex = 133;
            this.lbPages.Text = "1/1页";
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Location = new System.Drawing.Point(903, 608);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(49, 20);
            this.lbTotalCount.TabIndex = 132;
            this.lbTotalCount.Text = "条数";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(1334, 37);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 82);
            this.btnPrint.TabIndex = 134;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(106, 600);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(129, 36);
            this.btnSelectAll.TabIndex = 135;
            this.btnSelectAll.Text = "全部选中";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(241, 600);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(129, 36);
            this.btnCancelAll.TabIndex = 136;
            this.btnCancelAll.Text = "全部取消";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "选择";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.ReadOnly = true;
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckBox.Width = 70;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.FillWeight = 113.3279F;
            this.CustomerName.HeaderText = "姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 105;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.FillWeight = 73.9558F;
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Width = 70;
            // 
            // IDCardNo
            // 
            this.IDCardNo.DataPropertyName = "IDCardNo";
            this.IDCardNo.FillWeight = 322.9872F;
            this.IDCardNo.HeaderText = "身份证号";
            this.IDCardNo.Name = "IDCardNo";
            this.IDCardNo.ReadOnly = true;
            this.IDCardNo.Width = 145;
            // 
            // Summary
            // 
            this.Summary.DataPropertyName = "Summary";
            this.Summary.HeaderText = "体检小结";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            this.Summary.Width = 160;
            // 
            // HealthGuid
            // 
            this.HealthGuid.DataPropertyName = "HealthGuid";
            this.HealthGuid.HeaderText = "健康指导";
            this.HealthGuid.Name = "HealthGuid";
            this.HealthGuid.ReadOnly = true;
            this.HealthGuid.Width = 160;
            // 
            // MedGuid
            // 
            this.MedGuid.DataPropertyName = "MedGuid";
            this.MedGuid.HeaderText = "中医健康指导";
            this.MedGuid.Name = "MedGuid";
            this.MedGuid.ReadOnly = true;
            this.MedGuid.Width = 170;
            // 
            // CreateMenName
            // 
            this.CreateMenName.DataPropertyName = "CreateMenName";
            this.CreateMenName.HeaderText = "建档人";
            this.CreateMenName.Name = "CreateMenName";
            this.CreateMenName.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "建档日期";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 135;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "修改";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "修改";
            this.Column6.UseColumnTextForLinkValue = true;
            this.Column6.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "删除";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Text = "删除";
            this.Column5.UseColumnTextForLinkValue = true;
            this.Column5.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ID";
            this.Column4.HeaderText = "ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // GuideQueryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "GuideQueryForm";
            this.Text = "PhysicalQueryForm";
            this.Load += new System.EventHandler(this.GuideQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpCreatedDateEd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckxCreatedDate;
        private System.Windows.Forms.DateTimePicker dtpCreatedDateSt;
        private System.Windows.Forms.ComboBox cbxUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdNum;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Label lbPages;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.CheckBox ckCheckDate;
        private System.Windows.Forms.DateTimePicker dtpEd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn HealthGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateMenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}