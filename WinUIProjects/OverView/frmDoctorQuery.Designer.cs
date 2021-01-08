namespace OverView
{
    partial class frmDoctorQuery
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckBVisitPerson = new System.Windows.Forms.CheckBox();
            this.panelAddr = new System.Windows.Forms.Panel();
            this.cbxVillage = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxTown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDistrict = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbAddr = new System.Windows.Forms.CheckBox();
            this.panelVisit = new System.Windows.Forms.Panel();
            this.cklunger = new System.Windows.Forms.CheckBox();
            this.ckBGravid = new System.Windows.Forms.CheckBox();
            this.ckBKids = new System.Windows.Forms.CheckBox();
            this.ckBOlder = new System.Windows.Forms.CheckBox();
            this.ckBMentaldisease = new System.Windows.Forms.CheckBox();
            this.ckBStroke = new System.Windows.Forms.CheckBox();
            this.ckBHypertension = new System.Windows.Forms.CheckBox();
            this.ckBDiabetes = new System.Windows.Forms.CheckBox();
            this.ckBChd = new System.Windows.Forms.CheckBox();
            this.dtpCreatedDateEd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ckxCreatedDate = new System.Windows.Forms.CheckBox();
            this.dtpCreatedDateSt = new System.Windows.Forms.DateTimePicker();
            this.ckCheckDate = new System.Windows.Forms.CheckBox();
            this.dtpEd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdNum = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lbPages = new System.Windows.Forms.Label();
            this.btnFront = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelAddr.SuspendLayout();
            this.panelVisit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxUser);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ckBVisitPerson);
            this.groupBox1.Controls.Add(this.panelAddr);
            this.groupBox1.Controls.Add(this.ckbAddr);
            this.groupBox1.Controls.Add(this.panelVisit);
            this.groupBox1.Controls.Add(this.dtpCreatedDateEd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckxCreatedDate);
            this.groupBox1.Controls.Add(this.dtpCreatedDateSt);
            this.groupBox1.Controls.Add(this.ckCheckDate);
            this.groupBox1.Controls.Add(this.dtpEd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpSt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIdNum);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(69, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1292, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(1174, 100);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(111, 28);
            this.cbxUser.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(1094, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "建档人:";
            // 
            // ckBVisitPerson
            // 
            this.ckBVisitPerson.AutoSize = true;
            this.ckBVisitPerson.Location = new System.Drawing.Point(24, 103);
            this.ckBVisitPerson.Name = "ckBVisitPerson";
            this.ckBVisitPerson.Size = new System.Drawing.Size(128, 24);
            this.ckBVisitPerson.TabIndex = 8;
            this.ckBVisitPerson.Text = "随访人群：";
            this.ckBVisitPerson.UseVisualStyleBackColor = true;
            this.ckBVisitPerson.CheckedChanged += new System.EventHandler(this.ckBVisitPerson_CheckedChanged);
            // 
            // panelAddr
            // 
            this.panelAddr.Controls.Add(this.cbxVillage);
            this.panelAddr.Controls.Add(this.label7);
            this.panelAddr.Controls.Add(this.cbxTown);
            this.panelAddr.Controls.Add(this.label4);
            this.panelAddr.Controls.Add(this.cbxDistrict);
            this.panelAddr.Controls.Add(this.label3);
            this.panelAddr.Enabled = false;
            this.panelAddr.Location = new System.Drawing.Point(398, 23);
            this.panelAddr.Name = "panelAddr";
            this.panelAddr.Size = new System.Drawing.Size(842, 33);
            this.panelAddr.TabIndex = 1;
            // 
            // cbxVillage
            // 
            this.cbxVillage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVillage.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxVillage.FormattingEnabled = true;
            this.cbxVillage.ItemHeight = 20;
            this.cbxVillage.Location = new System.Drawing.Point(505, 2);
            this.cbxVillage.Name = "cbxVillage";
            this.cbxVillage.Size = new System.Drawing.Size(165, 28);
            this.cbxVillage.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F);
            this.label7.Location = new System.Drawing.Point(440, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 106;
            this.label7.Text = "村居：";
            // 
            // cbxTown
            // 
            this.cbxTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTown.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxTown.FormattingEnabled = true;
            this.cbxTown.ItemHeight = 20;
            this.cbxTown.Location = new System.Drawing.Point(252, 2);
            this.cbxTown.Name = "cbxTown";
            this.cbxTown.Size = new System.Drawing.Size(164, 28);
            this.cbxTown.TabIndex = 1;
            this.cbxTown.SelectedIndexChanged += new System.EventHandler(this.cbxTown_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(188, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 104;
            this.label4.Text = "村镇：";
            // 
            // cbxDistrict
            // 
            this.cbxDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDistrict.Font = new System.Drawing.Font("宋体", 15F);
            this.cbxDistrict.FormattingEnabled = true;
            this.cbxDistrict.ItemHeight = 20;
            this.cbxDistrict.Location = new System.Drawing.Point(9, 3);
            this.cbxDistrict.Name = "cbxDistrict";
            this.cbxDistrict.Size = new System.Drawing.Size(162, 28);
            this.cbxDistrict.TabIndex = 0;
            this.cbxDistrict.SelectedIndexChanged += new System.EventHandler(this.cbxDistrict_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(-43, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 102;
            this.label3.Text = "县区：";
            // 
            // ckbAddr
            // 
            this.ckbAddr.AutoSize = true;
            this.ckbAddr.Location = new System.Drawing.Point(321, 28);
            this.ckbAddr.Name = "ckbAddr";
            this.ckbAddr.Size = new System.Drawing.Size(68, 24);
            this.ckbAddr.TabIndex = 21;
            this.ckbAddr.Text = "住址";
            this.ckbAddr.UseVisualStyleBackColor = true;
            this.ckbAddr.CheckedChanged += new System.EventHandler(this.ckbAddr_CheckedChanged);
            // 
            // panelVisit
            // 
            this.panelVisit.Controls.Add(this.cklunger);
            this.panelVisit.Controls.Add(this.ckBGravid);
            this.panelVisit.Controls.Add(this.ckBKids);
            this.panelVisit.Controls.Add(this.ckBOlder);
            this.panelVisit.Controls.Add(this.ckBMentaldisease);
            this.panelVisit.Controls.Add(this.ckBStroke);
            this.panelVisit.Controls.Add(this.ckBHypertension);
            this.panelVisit.Controls.Add(this.ckBDiabetes);
            this.panelVisit.Controls.Add(this.ckBChd);
            this.panelVisit.Enabled = false;
            this.panelVisit.Location = new System.Drawing.Point(162, 96);
            this.panelVisit.Name = "panelVisit";
            this.panelVisit.Size = new System.Drawing.Size(925, 35);
            this.panelVisit.TabIndex = 9;
            // 
            // cklunger
            // 
            this.cklunger.AutoSize = true;
            this.cklunger.Location = new System.Drawing.Point(555, 5);
            this.cklunger.Name = "cklunger";
            this.cklunger.Size = new System.Drawing.Size(88, 24);
            this.cklunger.TabIndex = 5;
            this.cklunger.Text = "肺结核";
            this.cklunger.UseVisualStyleBackColor = true;
            // 
            // ckBGravid
            // 
            this.ckBGravid.AutoSize = true;
            this.ckBGravid.Location = new System.Drawing.Point(835, 5);
            this.ckBGravid.Name = "ckBGravid";
            this.ckBGravid.Size = new System.Drawing.Size(88, 24);
            this.ckBGravid.TabIndex = 8;
            this.ckBGravid.Text = "孕产妇";
            this.ckBGravid.UseVisualStyleBackColor = true;
            this.ckBGravid.CheckedChanged += new System.EventHandler(this.ckBGravid_CheckedChanged);
            // 
            // ckBKids
            // 
            this.ckBKids.AutoSize = true;
            this.ckBKids.Location = new System.Drawing.Point(751, 5);
            this.ckBKids.Name = "ckBKids";
            this.ckBKids.Size = new System.Drawing.Size(68, 24);
            this.ckBKids.TabIndex = 7;
            this.ckBKids.Text = "儿童";
            this.ckBKids.UseVisualStyleBackColor = true;
            this.ckBKids.CheckedChanged += new System.EventHandler(this.ckBKids_CheckedChanged);
            // 
            // ckBOlder
            // 
            this.ckBOlder.AutoSize = true;
            this.ckBOlder.Location = new System.Drawing.Point(656, 5);
            this.ckBOlder.Name = "ckBOlder";
            this.ckBOlder.Size = new System.Drawing.Size(88, 24);
            this.ckBOlder.TabIndex = 6;
            this.ckBOlder.Text = "老年人";
            this.ckBOlder.UseVisualStyleBackColor = true;
            this.ckBOlder.CheckedChanged += new System.EventHandler(this.ckBOlder_CheckedChanged);
            // 
            // ckBMentaldisease
            // 
            this.ckBMentaldisease.AutoSize = true;
            this.ckBMentaldisease.Location = new System.Drawing.Point(399, 6);
            this.ckBMentaldisease.Name = "ckBMentaldisease";
            this.ckBMentaldisease.Size = new System.Drawing.Size(148, 24);
            this.ckBMentaldisease.TabIndex = 4;
            this.ckBMentaldisease.Text = "重性精神疾病";
            this.ckBMentaldisease.UseVisualStyleBackColor = true;
            // 
            // ckBStroke
            // 
            this.ckBStroke.AutoSize = true;
            this.ckBStroke.Location = new System.Drawing.Point(303, 6);
            this.ckBStroke.Name = "ckBStroke";
            this.ckBStroke.Size = new System.Drawing.Size(88, 24);
            this.ckBStroke.TabIndex = 3;
            this.ckBStroke.Text = "脑卒中";
            this.ckBStroke.UseVisualStyleBackColor = true;
            // 
            // ckBHypertension
            // 
            this.ckBHypertension.AutoSize = true;
            this.ckBHypertension.Location = new System.Drawing.Point(199, 6);
            this.ckBHypertension.Name = "ckBHypertension";
            this.ckBHypertension.Size = new System.Drawing.Size(88, 24);
            this.ckBHypertension.TabIndex = 2;
            this.ckBHypertension.Text = "高血压";
            this.ckBHypertension.UseVisualStyleBackColor = true;
            // 
            // ckBDiabetes
            // 
            this.ckBDiabetes.AutoSize = true;
            this.ckBDiabetes.Location = new System.Drawing.Point(102, 6);
            this.ckBDiabetes.Name = "ckBDiabetes";
            this.ckBDiabetes.Size = new System.Drawing.Size(88, 24);
            this.ckBDiabetes.TabIndex = 1;
            this.ckBDiabetes.Text = "糖尿病";
            this.ckBDiabetes.UseVisualStyleBackColor = true;
            // 
            // ckBChd
            // 
            this.ckBChd.AutoSize = true;
            this.ckBChd.Location = new System.Drawing.Point(4, 6);
            this.ckBChd.Name = "ckBChd";
            this.ckBChd.Size = new System.Drawing.Size(88, 24);
            this.ckBChd.TabIndex = 0;
            this.ckBChd.Text = "冠心病";
            this.ckBChd.UseVisualStyleBackColor = true;
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(972, 62);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(178, 30);
            this.dtpCreatedDateEd.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(938, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(617, 65);
            this.ckxCreatedDate.Name = "ckxCreatedDate";
            this.ckxCreatedDate.Size = new System.Drawing.Size(118, 24);
            this.ckxCreatedDate.TabIndex = 5;
            this.ckxCreatedDate.Text = "建档日期:";
            this.ckxCreatedDate.UseVisualStyleBackColor = true;
            this.ckxCreatedDate.CheckedChanged += new System.EventHandler(this.ckxCreatedDate_CheckedChanged);
            // 
            // dtpCreatedDateSt
            // 
            this.dtpCreatedDateSt.Enabled = false;
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(739, 62);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(190, 30);
            this.dtpCreatedDateSt.TabIndex = 6;
            // 
            // ckCheckDate
            // 
            this.ckCheckDate.AutoSize = true;
            this.ckCheckDate.Location = new System.Drawing.Point(23, 65);
            this.ckCheckDate.Name = "ckCheckDate";
            this.ckCheckDate.Size = new System.Drawing.Size(118, 24);
            this.ckCheckDate.TabIndex = 2;
            this.ckCheckDate.Text = "体检日期:";
            this.ckCheckDate.UseVisualStyleBackColor = true;
            this.ckCheckDate.CheckedChanged += new System.EventHandler(this.ckCheckDate_CheckedChanged);
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Location = new System.Drawing.Point(385, 62);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(193, 30);
            this.dtpEd.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "—";
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Location = new System.Drawing.Point(161, 62);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(189, 30);
            this.dtpSt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(2, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名或身份证:";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Font = new System.Drawing.Font("宋体", 15F);
            this.txtIdNum.Location = new System.Drawing.Point(161, 26);
            this.txtIdNum.MaxLength = 18;
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(140, 30);
            this.txtIdNum.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1380, 61);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 82);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
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
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5,
            this.身份证,
            this.Column8,
            this.Column7,
            this.Column9});
            this.dgvData.Location = new System.Drawing.Point(66, 159);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvData.RowTemplate.Height = 41;
            this.dgvData.Size = new System.Drawing.Size(1400, 455);
            this.dgvData.TabIndex = 104;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CustomerName";
            this.Column1.FillWeight = 42.90895F;
            this.Column1.HeaderText = "姓名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Sex";
            this.Column2.FillWeight = 40F;
            this.Column2.HeaderText = "性别";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Nation";
            this.Column3.FillWeight = 40F;
            this.Column3.HeaderText = "民族";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Birthday";
            this.Column4.FillWeight = 60F;
            this.Column4.HeaderText = "生日";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Phone";
            this.Column6.FillWeight = 80F;
            this.Column6.HeaderText = "电话";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "HouseHoldAddress";
            this.Column5.FillWeight = 95.36802F;
            this.Column5.HeaderText = "住址";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 160;
            // 
            // 身份证
            // 
            this.身份证.DataPropertyName = "IDCardNo";
            this.身份证.FillWeight = 80F;
            this.身份证.HeaderText = "身份证";
            this.身份证.Name = "身份证";
            this.身份证.ReadOnly = true;
            this.身份证.Width = 250;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CreateDate";
            this.Column8.FillWeight = 70F;
            this.Column8.HeaderText = "建档日期";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "CheckDate";
            this.Column7.FillWeight = 70F;
            this.Column7.HeaderText = "体检日期";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "BlueToothRecord";
            this.Column9.FillWeight = 50F;
            this.Column9.HeaderText = "体检数据";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 150;
            // 
            // lbPages
            // 
            this.lbPages.AutoSize = true;
            this.lbPages.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPages.Location = new System.Drawing.Point(1178, 635);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(58, 19);
            this.lbPages.TabIndex = 106;
            this.lbPages.Text = "1/1页";
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(1273, 625);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(94, 36);
            this.btnFront.TabIndex = 4;
            this.btnFront.Text = "上一页";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1373, 625);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 36);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Location = new System.Drawing.Point(1086, 638);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(49, 20);
            this.lbTotalCount.TabIndex = 111;
            this.lbTotalCount.Text = "条数";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(66, 625);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(94, 36);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(169, 625);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 36);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(276, 626);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(127, 33);
            this.btnExportReport.TabIndex = 113;
            this.btnExportReport.Text = "导出周报表";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // frmDoctorQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "frmDoctorQuery";
            this.Text = "frmDoctorQuery";
            this.Load += new System.EventHandler(this.frmDoctorQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelAddr.ResumeLayout(false);
            this.panelAddr.PerformLayout();
            this.panelVisit.ResumeLayout(false);
            this.panelVisit.PerformLayout();
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
        private System.Windows.Forms.CheckBox ckCheckDate;
        private System.Windows.Forms.DateTimePicker dtpEd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdNum;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lbPages;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.Panel panelVisit;
        private System.Windows.Forms.CheckBox ckBChd;
        private System.Windows.Forms.CheckBox ckBGravid;
        private System.Windows.Forms.CheckBox ckBKids;
        private System.Windows.Forms.CheckBox ckBOlder;
        private System.Windows.Forms.CheckBox ckBMentaldisease;
        private System.Windows.Forms.CheckBox ckBStroke;
        private System.Windows.Forms.CheckBox ckBHypertension;
        private System.Windows.Forms.CheckBox ckBDiabetes;
        private System.Windows.Forms.Panel panelAddr;
        private System.Windows.Forms.CheckBox ckbAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDistrict;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxVillage;
        private System.Windows.Forms.CheckBox ckBVisitPerson;
        private System.Windows.Forms.ComboBox cbxUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox cklunger;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn 身份证;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
        private System.Windows.Forms.Button btnExportReport;
    }
}