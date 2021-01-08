﻿namespace OverView
{
    partial class FrmMustChoose
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
            this.dtpCreatedDateEd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ckxCreatedDate = new System.Windows.Forms.CheckBox();
            this.dtpCreatedDateSt = new System.Windows.Forms.DateTimePicker();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckBirthday = new System.Windows.Forms.CheckBox();
            this.dtpEd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSt = new System.Windows.Forms.DateTimePicker();
            this.tbAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdNum = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lbPages = new System.Windows.Forms.Label();
            this.btnFront = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MustChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.ckBirthday);
            this.groupBox1.Controls.Add(this.dtpEd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpSt);
            this.groupBox1.Controls.Add(this.tbAddr);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIdNum);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(119, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(668, 68);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(135, 23);
            this.dtpCreatedDateEd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(647, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(417, 70);
            this.ckxCreatedDate.Name = "ckxCreatedDate";
            this.ckxCreatedDate.Size = new System.Drawing.Size(89, 18);
            this.ckxCreatedDate.TabIndex = 6;
            this.ckxCreatedDate.Text = "建档日期:";
            this.ckxCreatedDate.UseVisualStyleBackColor = true;
            this.ckxCreatedDate.CheckedChanged += new System.EventHandler(this.ckxCreatedDate_CheckedChanged);
            // 
            // dtpCreatedDateSt
            // 
            this.dtpCreatedDateSt.Enabled = false;
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(512, 68);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(135, 23);
            this.dtpCreatedDateSt.TabIndex = 7;
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(715, 26);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(170, 22);
            this.cbxUser.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(653, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "建档人:";
            // 
            // ckBirthday
            // 
            this.ckBirthday.AutoSize = true;
            this.ckBirthday.Location = new System.Drawing.Point(15, 70);
            this.ckBirthday.Name = "ckBirthday";
            this.ckBirthday.Size = new System.Drawing.Size(89, 18);
            this.ckBirthday.TabIndex = 3;
            this.ckBirthday.Text = "出生日期:";
            this.ckBirthday.UseVisualStyleBackColor = true;
            this.ckBirthday.CheckedChanged += new System.EventHandler(this.ckBirthday_CheckedChanged);
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Location = new System.Drawing.Point(266, 68);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(135, 23);
            this.dtpEd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "—";
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Location = new System.Drawing.Point(110, 68);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(135, 23);
            this.dtpSt.TabIndex = 4;
            // 
            // tbAddr
            // 
            this.tbAddr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAddr.Location = new System.Drawing.Point(385, 25);
            this.tbAddr.MaxLength = 20;
            this.tbAddr.Name = "tbAddr";
            this.tbAddr.Size = new System.Drawing.Size(262, 23);
            this.tbAddr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(337, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "住址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名或身份证:";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIdNum.Location = new System.Drawing.Point(110, 26);
            this.txtIdNum.MaxLength = 18;
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(212, 23);
            this.txtIdNum.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1030, 26);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 82);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lbPages
            // 
            this.lbPages.AutoSize = true;
            this.lbPages.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPages.Location = new System.Drawing.Point(729, 599);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(58, 19);
            this.lbPages.TabIndex = 106;
            this.lbPages.Text = "1/1页";
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(810, 592);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(94, 36);
            this.btnFront.TabIndex = 2;
            this.btnFront.Text = "上一页";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(929, 592);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 36);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Location = new System.Drawing.Point(642, 604);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(35, 14);
            this.lbTotalCount.TabIndex = 110;
            this.lbTotalCount.Text = "条数";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.Sex,
            this.IDCard,
            this.Column1,
            this.Column2,
            this.MustChoose});
            this.dgvData.Location = new System.Drawing.Point(119, 124);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(904, 462);
            this.dgvData.TabIndex = 111;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.FillWeight = 227.4378F;
            this.CustomerName.HeaderText = "姓名";
            this.CustomerName.MinimumWidth = 50;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 70;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.FillWeight = 304.5685F;
            this.Sex.HeaderText = "性别";
            this.Sex.MinimumWidth = 50;
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Width = 60;
            // 
            // IDCard
            // 
            this.IDCard.DataPropertyName = "IDCardNo";
            this.IDCard.FillWeight = 0.9932247F;
            this.IDCard.HeaderText = "身份证号";
            this.IDCard.MinimumWidth = 50;
            this.IDCard.Name = "IDCard";
            this.IDCard.ReadOnly = true;
            this.IDCard.Width = 143;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CreateDate";
            this.Column1.HeaderText = "建档日期";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LastUpdateDate";
            this.Column2.HeaderText = "最后更新日期";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 126;
            // 
            // MustChoose
            // 
            this.MustChoose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MustChoose.DataPropertyName = "MustChoose";
            this.MustChoose.FillWeight = 271.7102F;
            this.MustChoose.HeaderText = "未填项";
            this.MustChoose.MinimumWidth = 50;
            this.MustChoose.Name = "MustChoose";
            this.MustChoose.ReadOnly = true;
            this.MustChoose.Width = 69;
            // 
            // FrmMustChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 640);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMustChoose";
            this.Text = "必选项统计";
            this.Load += new System.EventHandler(this.FrmMustChoose_Load);
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
        private System.Windows.Forms.CheckBox ckBirthday;
        private System.Windows.Forms.DateTimePicker dtpEd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSt;
        private System.Windows.Forms.TextBox tbAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdNum;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label lbPages;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MustChoose;
    }
}