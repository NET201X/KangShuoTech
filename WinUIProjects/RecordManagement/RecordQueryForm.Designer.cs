﻿namespace ArchiveInfo
{
    partial class RecordQueryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbxx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpCreatedDateEd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ckxCreatedDate = new System.Windows.Forms.CheckBox();
            this.dtpCreatedDateSt = new System.Windows.Forms.DateTimePicker();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckCheckDate = new System.Windows.Forms.CheckBox();
            this.dtpEd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSt = new System.Windows.Forms.DateTimePicker();
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
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbxx);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpCreatedDateEd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckxCreatedDate);
            this.groupBox1.Controls.Add(this.dtpCreatedDateSt);
            this.groupBox1.Controls.Add(this.cbxUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ckCheckDate);
            this.groupBox1.Controls.Add(this.dtpEd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpSt);
            this.groupBox1.Controls.Add(this.tbAddr);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIdNum);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(75, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1286, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbxx
            // 
            this.cmbxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxx.FormattingEnabled = true;
            this.cmbxx.Items.AddRange(new object[] {
            "不限",
            "A型",
            "B型",
            "O型",
            "AB型",
            "不详"});
            this.cmbxx.Location = new System.Drawing.Point(1162, 25);
            this.cmbxx.Name = "cmbxx";
            this.cmbxx.Size = new System.Drawing.Size(77, 28);
            this.cmbxx.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(1097, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "血型:";
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(1056, 63);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(183, 30);
            this.dtpCreatedDateEd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1024, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(715, 69);
            this.ckxCreatedDate.Name = "ckxCreatedDate";
            this.ckxCreatedDate.Size = new System.Drawing.Size(118, 24);
            this.ckxCreatedDate.TabIndex = 6;
            this.ckxCreatedDate.Text = "建档日期:";
            this.ckxCreatedDate.UseVisualStyleBackColor = true;
            this.ckxCreatedDate.CheckedChanged += new System.EventHandler(this.ckxCreatedDate_CheckedChanged);
            // 
            // dtpCreatedDateSt
            // 
            this.dtpCreatedDateSt.Enabled = false;
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(839, 64);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(180, 30);
            this.dtpCreatedDateSt.TabIndex = 7;
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(839, 25);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(180, 28);
            this.cbxUser.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(749, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "建档人:";
            // 
            // ckCheckDate
            // 
            this.ckCheckDate.AutoSize = true;
            this.ckCheckDate.Location = new System.Drawing.Point(27, 70);
            this.ckCheckDate.Name = "ckCheckDate";
            this.ckCheckDate.Size = new System.Drawing.Size(118, 24);
            this.ckCheckDate.TabIndex = 3;
            this.ckCheckDate.Text = "体检日期:";
            this.ckCheckDate.UseVisualStyleBackColor = true;
            this.ckCheckDate.CheckedChanged += new System.EventHandler(this.ckCheckDate_CheckedChanged);
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Location = new System.Drawing.Point(379, 67);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(184, 30);
            this.dtpEd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "—";
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Location = new System.Drawing.Point(149, 67);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(189, 30);
            this.dtpSt.TabIndex = 4;
            // 
            // tbAddr
            // 
            this.tbAddr.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAddr.Location = new System.Drawing.Point(467, 23);
            this.tbAddr.MaxLength = 20;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(247, 30);
            this.tbAddr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(404, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "住址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名或身份证:";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Font = new System.Drawing.Font("宋体", 15F);
            this.txtIdNum.Location = new System.Drawing.Point(152, 25);
            this.txtIdNum.MaxLength = 18;
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
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 47;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.Sex,
            this.Column1,
            this.IDCard,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column6,
            this.Column4});
            this.dgvData.Location = new System.Drawing.Point(75, 130);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvData.RowTemplate.Height = 41;
            this.dgvData.Size = new System.Drawing.Size(1384, 455);
            this.dgvData.TabIndex = 122;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1373, 38);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 82);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1365, 603);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 36);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(1265, 603);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(94, 36);
            this.btnFront.TabIndex = 2;
            this.btnFront.Text = "上一页";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // lbPages
            // 
            this.lbPages.AutoSize = true;
            this.lbPages.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPages.Location = new System.Drawing.Point(1149, 609);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(58, 19);
            this.lbPages.TabIndex = 125;
            this.lbPages.Text = "1/1页";
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Location = new System.Drawing.Point(1045, 612);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(49, 20);
            this.lbTotalCount.TabIndex = 124;
            this.lbTotalCount.Text = "条数";
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CustomerName.DefaultCellStyle = dataGridViewCellStyle2;
            this.CustomerName.FillWeight = 124.9289F;
            this.CustomerName.HeaderText = "姓名";
            this.CustomerName.MinimumWidth = 105;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 110;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Sex.DefaultCellStyle = dataGridViewCellStyle3;
            this.Sex.FillWeight = 82.12315F;
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Nation";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.FillWeight = 133.804F;
            this.Column1.HeaderText = "民族";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // IDCard
            // 
            this.IDCard.DataPropertyName = "IDCardNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IDCard.DefaultCellStyle = dataGridViewCellStyle5;
            this.IDCard.FillWeight = 219.6369F;
            this.IDCard.HeaderText = "身份证号";
            this.IDCard.Name = "IDCard";
            this.IDCard.ReadOnly = true;
            this.IDCard.Width = 220;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Birthday";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.FillWeight = 160.0825F;
            this.Column2.HeaderText = "生日";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Phone";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column3.FillWeight = 182.9548F;
            this.Column3.HeaderText = "电话";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "CreateDate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column7.FillWeight = 199.5149F;
            this.Column7.HeaderText = "建档日期";
            this.Column7.MinimumWidth = 110;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 180;
            // 
            // Column6
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column6.FillWeight = 157.1077F;
            this.Column6.HeaderText = "修改";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "修改";
            this.Column6.UseColumnTextForLinkValue = true;
            this.Column6.Width = 140;
            // 
            // Column4
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column4.HeaderText = "删除";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Text = "删除";
            this.Column4.UseColumnTextForLinkValue = true;
            this.Column4.Width = 130;
            // 
            // RecordQueryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "RecordQueryForm";
            this.Text = "RecordQueryForm";
            this.Load += new System.EventHandler(this.RecordQueryForm_Load);
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
        private System.Windows.Forms.CheckBox ckCheckDate;
        private System.Windows.Forms.DateTimePicker dtpEd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSt;
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
        private System.Windows.Forms.ComboBox cmbxx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
    }
}