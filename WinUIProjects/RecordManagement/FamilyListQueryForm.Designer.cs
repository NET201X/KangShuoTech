namespace ArchiveInfo
{
    partial class FamilyListQueryForm
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFront = new System.Windows.Forms.Button();
            this.lbPages = new System.Windows.Forms.Label();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1364, 45);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 82);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
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
            this.groupBox1.Location = new System.Drawing.Point(70, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1275, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(1045, 68);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(182, 30);
            this.dtpCreatedDateEd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1007, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(692, 70);
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
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(817, 68);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(182, 30);
            this.dtpCreatedDateSt.TabIndex = 7;
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(1073, 23);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(153, 28);
            this.cbxUser.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(977, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "建档人:";
            // 
            // ckCheckDate
            // 
            this.ckCheckDate.AutoSize = true;
            this.ckCheckDate.Location = new System.Drawing.Point(34, 70);
            this.ckCheckDate.Name = "ckCheckDate";
            this.ckCheckDate.Size = new System.Drawing.Size(118, 24);
            this.ckCheckDate.TabIndex = 3;
            this.ckCheckDate.Text = "创建日期:";
            this.ckCheckDate.UseVisualStyleBackColor = true;
            this.ckCheckDate.CheckedChanged += new System.EventHandler(this.ckCheckDate_CheckedChanged);
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Location = new System.Drawing.Point(383, 68);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(184, 30);
            this.dtpEd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "—";
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Location = new System.Drawing.Point(164, 68);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(182, 30);
            this.dtpSt.TabIndex = 4;
            // 
            // tbAddr
            // 
            this.tbAddr.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAddr.Location = new System.Drawing.Point(569, 23);
            this.tbAddr.MaxLength = 20;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(204, 30);
            this.tbAddr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(508, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "住址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名或身份证:";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Font = new System.Drawing.Font("宋体", 15F);
            this.txtIdNum.Location = new System.Drawing.Point(167, 24);
            this.txtIdNum.MaxLength = 18;
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(199, 30);
            this.txtIdNum.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("宋体", 15F);
            this.btnNext.Location = new System.Drawing.Point(1251, 618);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 36);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFront
            // 
            this.btnFront.Font = new System.Drawing.Font("宋体", 15F);
            this.btnFront.Location = new System.Drawing.Point(1151, 618);
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
            this.lbPages.Font = new System.Drawing.Font("宋体", 15F);
            this.lbPages.Location = new System.Drawing.Point(1037, 624);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(59, 20);
            this.lbPages.TabIndex = 134;
            this.lbPages.Text = "1/1页";
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lbTotalCount.Location = new System.Drawing.Point(933, 627);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(49, 20);
            this.lbTotalCount.TabIndex = 133;
            this.lbTotalCount.Text = "条数";
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
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column2,
            this.Column8,
            this.Column3,
            this.Column9});
            this.dgvData.Location = new System.Drawing.Point(70, 146);
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvData.RowTemplate.Height = 41;
            this.dgvData.Size = new System.Drawing.Size(1380, 455);
            this.dgvData.TabIndex = 132;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CustomerName";
            this.Column1.HeaderText = "姓名";
            this.Column1.MinimumWidth = 105;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 110;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Sex";
            this.Column4.HeaderText = "性别";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Birthday";
            this.Column5.HeaderText = "出生日期";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 130;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Phone";
            this.Column6.HeaderText = "电话";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IDCardNo";
            this.Column2.HeaderText = "身份证号码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 260;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "FamilyRecordID";
            this.Column8.HeaderText = "户主编号";
            this.Column8.Name = "Column8";
            this.Column8.Width = 170;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "HouseRelation";
            this.Column3.HeaderText = "与户主关系";
            this.Column3.MinimumWidth = 110;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 160;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "修改";
            this.Column9.Name = "Column9";
            this.Column9.Text = "修改";
            this.Column9.UseColumnTextForLinkValue = true;
            this.Column9.Width = 220;
            // 
            // FamilyListQueryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuery);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "FamilyListQueryForm";
            this.Text = "FamilyListQueryForm";
            this.Load += new System.EventHandler(this.FamilyListQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
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
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Label lbPages;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
    }
}