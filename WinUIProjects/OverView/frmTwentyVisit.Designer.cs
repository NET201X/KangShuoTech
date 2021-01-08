namespace OverView
{
    partial class frmTwentyVisit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new System.Windows.Forms.DataGridView();
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblHeaCount = new System.Windows.Forms.Label();
            this.lblHea = new System.Windows.Forms.Label();
            this.lblNczCount = new System.Windows.Forms.Label();
            this.lblNcz = new System.Windows.Forms.Label();
            this.lblTbCount = new System.Windows.Forms.Label();
            this.lblTb = new System.Windows.Forms.Label();
            this.lblPsyCount = new System.Windows.Forms.Label();
            this.lblPsy = new System.Windows.Forms.Label();
            this.lblDiaCount = new System.Windows.Forms.Label();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblHypCount = new System.Windows.Forms.Label();
            this.lblHyp = new System.Windows.Forms.Label();
            this.lblOldManCount = new System.Windows.Forms.Label();
            this.lblOldMan = new System.Windows.Forms.Label();
            this.lbPages = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFront = new System.Windows.Forms.Button();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldMan = new System.Windows.Forms.DataGridViewButtonColumn();
            this.hyp = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dia = new System.Windows.Forms.DataGridViewButtonColumn();
            this.psy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tb = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ncz = new System.Windows.Forms.DataGridViewButtonColumn();
            this.hea = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
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
            this.name,
            this.idCardNo,
            this.oldMan,
            this.hyp,
            this.dia,
            this.psy,
            this.tb,
            this.ncz,
            this.hea,
            this.Column1});
            this.dgvData.Location = new System.Drawing.Point(70, 140);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvData.RowTemplate.Height = 40;
            this.dgvData.Size = new System.Drawing.Size(1400, 405);
            this.dgvData.TabIndex = 129;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
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
            this.groupBox1.Size = new System.Drawing.Size(1290, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(1050, 67);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(180, 30);
            this.dtpCreatedDateEd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1016, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(704, 69);
            this.ckxCreatedDate.Name = "ckxCreatedDate";
            this.ckxCreatedDate.Size = new System.Drawing.Size(118, 24);
            this.ckxCreatedDate.TabIndex = 6;
            this.ckxCreatedDate.Text = "建档日期:";
            this.ckxCreatedDate.UseVisualStyleBackColor = true;
            this.ckxCreatedDate.CheckedChanged += new System.EventHandler(this.ckxCreatedDate_CheckedChanged_1);
            // 
            // dtpCreatedDateSt
            // 
            this.dtpCreatedDateSt.Enabled = false;
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(831, 67);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(179, 30);
            this.dtpCreatedDateSt.TabIndex = 7;
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(1060, 22);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(170, 28);
            this.cbxUser.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(970, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "建档人:";
            // 
            // ckCheckDate
            // 
            this.ckCheckDate.AutoSize = true;
            this.ckCheckDate.Location = new System.Drawing.Point(52, 70);
            this.ckCheckDate.Name = "ckCheckDate";
            this.ckCheckDate.Size = new System.Drawing.Size(118, 24);
            this.ckCheckDate.TabIndex = 3;
            this.ckCheckDate.Text = "体检日期:";
            this.ckCheckDate.UseVisualStyleBackColor = true;
            this.ckCheckDate.CheckedChanged += new System.EventHandler(this.ckCheckDate_CheckedChanged_1);
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Location = new System.Drawing.Point(408, 68);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(180, 30);
            this.dtpEd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "—";
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Location = new System.Drawing.Point(176, 68);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(189, 30);
            this.dtpSt.TabIndex = 4;
            // 
            // tbAddr
            // 
            this.tbAddr.Font = new System.Drawing.Font("宋体", 15F);
            this.tbAddr.Location = new System.Drawing.Point(559, 21);
            this.tbAddr.MaxLength = 20;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(262, 30);
            this.tbAddr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(495, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "住址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名或身份证:";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Font = new System.Drawing.Font("宋体", 15F);
            this.txtIdNum.Location = new System.Drawing.Point(176, 22);
            this.txtIdNum.MaxLength = 18;
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(212, 30);
            this.txtIdNum.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1384, 39);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 82);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblHeaCount
            // 
            this.lblHeaCount.AutoSize = true;
            this.lblHeaCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lblHeaCount.Location = new System.Drawing.Point(393, 614);
            this.lblHeaCount.Name = "lblHeaCount";
            this.lblHeaCount.Size = new System.Drawing.Size(0, 20);
            this.lblHeaCount.TabIndex = 183;
            // 
            // lblHea
            // 
            this.lblHea.AutoSize = true;
            this.lblHea.Font = new System.Drawing.Font("宋体", 15F);
            this.lblHea.Location = new System.Drawing.Point(330, 614);
            this.lblHea.Name = "lblHea";
            this.lblHea.Size = new System.Drawing.Size(89, 20);
            this.lblHea.TabIndex = 182;
            this.lblHea.Text = "冠心病：";
            // 
            // lblNczCount
            // 
            this.lblNczCount.AutoSize = true;
            this.lblNczCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lblNczCount.Location = new System.Drawing.Point(262, 614);
            this.lblNczCount.Name = "lblNczCount";
            this.lblNczCount.Size = new System.Drawing.Size(0, 20);
            this.lblNczCount.TabIndex = 181;
            // 
            // lblNcz
            // 
            this.lblNcz.AutoSize = true;
            this.lblNcz.Font = new System.Drawing.Font("宋体", 15F);
            this.lblNcz.Location = new System.Drawing.Point(195, 614);
            this.lblNcz.Name = "lblNcz";
            this.lblNcz.Size = new System.Drawing.Size(89, 20);
            this.lblNcz.TabIndex = 180;
            this.lblNcz.Text = "脑卒中：";
            // 
            // lblTbCount
            // 
            this.lblTbCount.AutoSize = true;
            this.lblTbCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lblTbCount.Location = new System.Drawing.Point(137, 614);
            this.lblTbCount.Name = "lblTbCount";
            this.lblTbCount.Size = new System.Drawing.Size(0, 20);
            this.lblTbCount.TabIndex = 179;
            // 
            // lblTb
            // 
            this.lblTb.AutoSize = true;
            this.lblTb.Font = new System.Drawing.Font("宋体", 15F);
            this.lblTb.Location = new System.Drawing.Point(76, 614);
            this.lblTb.Name = "lblTb";
            this.lblTb.Size = new System.Drawing.Size(89, 20);
            this.lblTb.TabIndex = 178;
            this.lblTb.Text = "肺结核：";
            // 
            // lblPsyCount
            // 
            this.lblPsyCount.AutoSize = true;
            this.lblPsyCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lblPsyCount.Location = new System.Drawing.Point(538, 575);
            this.lblPsyCount.Name = "lblPsyCount";
            this.lblPsyCount.Size = new System.Drawing.Size(0, 20);
            this.lblPsyCount.TabIndex = 177;
            // 
            // lblPsy
            // 
            this.lblPsy.AutoSize = true;
            this.lblPsy.Font = new System.Drawing.Font("宋体", 15F);
            this.lblPsy.Location = new System.Drawing.Point(460, 575);
            this.lblPsy.Name = "lblPsy";
            this.lblPsy.Size = new System.Drawing.Size(109, 20);
            this.lblPsy.TabIndex = 176;
            this.lblPsy.Text = "精神疾病：";
            // 
            // lblDiaCount
            // 
            this.lblDiaCount.AutoSize = true;
            this.lblDiaCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lblDiaCount.Location = new System.Drawing.Point(394, 575);
            this.lblDiaCount.Name = "lblDiaCount";
            this.lblDiaCount.Size = new System.Drawing.Size(0, 20);
            this.lblDiaCount.TabIndex = 175;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("宋体", 15F);
            this.lblDia.Location = new System.Drawing.Point(330, 575);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(89, 20);
            this.lblDia.TabIndex = 174;
            this.lblDia.Text = "糖尿病：";
            // 
            // lblHypCount
            // 
            this.lblHypCount.AutoSize = true;
            this.lblHypCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lblHypCount.Location = new System.Drawing.Point(263, 575);
            this.lblHypCount.Name = "lblHypCount";
            this.lblHypCount.Size = new System.Drawing.Size(0, 20);
            this.lblHypCount.TabIndex = 173;
            // 
            // lblHyp
            // 
            this.lblHyp.AutoSize = true;
            this.lblHyp.Font = new System.Drawing.Font("宋体", 15F);
            this.lblHyp.Location = new System.Drawing.Point(196, 575);
            this.lblHyp.Name = "lblHyp";
            this.lblHyp.Size = new System.Drawing.Size(89, 20);
            this.lblHyp.TabIndex = 172;
            this.lblHyp.Text = "高血压：";
            // 
            // lblOldManCount
            // 
            this.lblOldManCount.AutoSize = true;
            this.lblOldManCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lblOldManCount.Location = new System.Drawing.Point(137, 575);
            this.lblOldManCount.Name = "lblOldManCount";
            this.lblOldManCount.Size = new System.Drawing.Size(0, 20);
            this.lblOldManCount.TabIndex = 171;
            // 
            // lblOldMan
            // 
            this.lblOldMan.AutoSize = true;
            this.lblOldMan.Font = new System.Drawing.Font("宋体", 15F);
            this.lblOldMan.Location = new System.Drawing.Point(76, 575);
            this.lblOldMan.Name = "lblOldMan";
            this.lblOldMan.Size = new System.Drawing.Size(89, 20);
            this.lblOldMan.TabIndex = 170;
            this.lblOldMan.Text = "老年人：";
            // 
            // lbPages
            // 
            this.lbPages.AutoSize = true;
            this.lbPages.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPages.Location = new System.Drawing.Point(1196, 576);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(58, 19);
            this.lbPages.TabIndex = 169;
            this.lbPages.Text = "1/1页";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1375, 567);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 36);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(1275, 567);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(94, 36);
            this.btnFront.TabIndex = 2;
            this.btnFront.Text = "上一页";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lbTotalCount.Location = new System.Drawing.Point(1085, 575);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(49, 20);
            this.lbTotalCount.TabIndex = 184;
            this.lbTotalCount.Text = "条数";
            // 
            // name
            // 
            this.name.DataPropertyName = "CustomerName";
            this.name.FillWeight = 484.264F;
            this.name.HeaderText = "姓名";
            this.name.MinimumWidth = 80;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // idCardNo
            // 
            this.idCardNo.DataPropertyName = "IDCardNo";
            this.idCardNo.FillWeight = 1.234282F;
            this.idCardNo.HeaderText = "身份证";
            this.idCardNo.MinimumWidth = 114;
            this.idCardNo.Name = "idCardNo";
            this.idCardNo.ReadOnly = true;
            this.idCardNo.Width = 200;
            // 
            // oldMan
            // 
            this.oldMan.DataPropertyName = "OLDVisit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.oldMan.DefaultCellStyle = dataGridViewCellStyle2;
            this.oldMan.FillWeight = 2.201192F;
            this.oldMan.HeaderText = "老年人";
            this.oldMan.MinimumWidth = 104;
            this.oldMan.Name = "oldMan";
            this.oldMan.ReadOnly = true;
            this.oldMan.Width = 150;
            // 
            // hyp
            // 
            this.hyp.DataPropertyName = "HyperVisit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hyp.DefaultCellStyle = dataGridViewCellStyle3;
            this.hyp.FillWeight = 4.735429F;
            this.hyp.HeaderText = "高血压";
            this.hyp.MinimumWidth = 104;
            this.hyp.Name = "hyp";
            this.hyp.ReadOnly = true;
            this.hyp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hyp.Width = 150;
            // 
            // dia
            // 
            this.dia.DataPropertyName = "DiaVisit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dia.DefaultCellStyle = dataGridViewCellStyle4;
            this.dia.FillWeight = 10.22164F;
            this.dia.HeaderText = "糖尿病";
            this.dia.MinimumWidth = 104;
            this.dia.Name = "dia";
            this.dia.ReadOnly = true;
            this.dia.Width = 150;
            // 
            // psy
            // 
            this.psy.DataPropertyName = "MentalVisit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.psy.DefaultCellStyle = dataGridViewCellStyle5;
            this.psy.FillWeight = 22.09837F;
            this.psy.HeaderText = "精神疾病";
            this.psy.MinimumWidth = 104;
            this.psy.Name = "psy";
            this.psy.ReadOnly = true;
            this.psy.Width = 150;
            // 
            // tb
            // 
            this.tb.DataPropertyName = "LungerVisit";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb.DefaultCellStyle = dataGridViewCellStyle6;
            this.tb.FillWeight = 47.80955F;
            this.tb.HeaderText = "肺结核";
            this.tb.MinimumWidth = 104;
            this.tb.Name = "tb";
            this.tb.ReadOnly = true;
            this.tb.Width = 150;
            // 
            // ncz
            // 
            this.ncz.DataPropertyName = "StrokeVisit";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ncz.DefaultCellStyle = dataGridViewCellStyle7;
            this.ncz.FillWeight = 103.47F;
            this.ncz.HeaderText = "脑卒中";
            this.ncz.MinimumWidth = 104;
            this.ncz.Name = "ncz";
            this.ncz.ReadOnly = true;
            this.ncz.Width = 150;
            // 
            // hea
            // 
            this.hea.DataPropertyName = "ChdVisit";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hea.DefaultCellStyle = dataGridViewCellStyle8;
            this.hea.FillWeight = 223.9657F;
            this.hea.HeaderText = "冠心病";
            this.hea.MinimumWidth = 104;
            this.hea.Name = "hea";
            this.hea.ReadOnly = true;
            this.hea.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hea.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // frmTwentyVisit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.lblHeaCount);
            this.Controls.Add(this.lblHea);
            this.Controls.Add(this.lblNczCount);
            this.Controls.Add(this.lblNcz);
            this.Controls.Add(this.lblTbCount);
            this.Controls.Add(this.lblTb);
            this.Controls.Add(this.lblPsyCount);
            this.Controls.Add(this.lblPsy);
            this.Controls.Add(this.lblDiaCount);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.lblHypCount);
            this.Controls.Add(this.lblHyp);
            this.Controls.Add(this.lblOldManCount);
            this.Controls.Add(this.lblOldMan);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dgvData);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "frmTwentyVisit";
            this.Text = "frmTwentyVisit";
            this.Load += new System.EventHandler(this.frmTwentyVisit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
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
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label lblHeaCount;
        private System.Windows.Forms.Label lblHea;
        private System.Windows.Forms.Label lblNczCount;
        private System.Windows.Forms.Label lblNcz;
        private System.Windows.Forms.Label lblTbCount;
        private System.Windows.Forms.Label lblTb;
        private System.Windows.Forms.Label lblPsyCount;
        private System.Windows.Forms.Label lblPsy;
        private System.Windows.Forms.Label lblDiaCount;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblHypCount;
        private System.Windows.Forms.Label lblHyp;
        private System.Windows.Forms.Label lblOldManCount;
        private System.Windows.Forms.Label lblOldMan;
        private System.Windows.Forms.Label lbPages;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCardNo;
        private System.Windows.Forms.DataGridViewButtonColumn oldMan;
        private System.Windows.Forms.DataGridViewButtonColumn hyp;
        private System.Windows.Forms.DataGridViewButtonColumn dia;
        private System.Windows.Forms.DataGridViewButtonColumn psy;
        private System.Windows.Forms.DataGridViewButtonColumn tb;
        private System.Windows.Forms.DataGridViewButtonColumn ncz;
        private System.Windows.Forms.DataGridViewButtonColumn hea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}