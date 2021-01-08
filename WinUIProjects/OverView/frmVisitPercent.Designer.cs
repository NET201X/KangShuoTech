namespace OverView
{
    partial class frmVisitPercent
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPersent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HyperPersent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaPersent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MentalPersent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LungerPersent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrokePersent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChdPersent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1392, 32);
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
            this.groupBox1.Controls.Add(this.cbxUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(79, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1289, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(89, 40);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(153, 28);
            this.cbxUser.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(7, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "建档人:";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 43;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.OldPersent,
            this.HyperPersent,
            this.DiaPersent,
            this.MentalPersent,
            this.LungerPersent,
            this.StrokePersent,
            this.ChdPersent});
            this.dgvData.Location = new System.Drawing.Point(78, 128);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvData.RowTemplate.Height = 41;
            this.dgvData.Size = new System.Drawing.Size(1400, 360);
            this.dgvData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CreateMenName";
            this.Column1.HeaderText = "建档人";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // OldPersent
            // 
            this.OldPersent.DataPropertyName = "OldPersent";
            this.OldPersent.HeaderText = "老年人";
            this.OldPersent.Name = "OldPersent";
            this.OldPersent.ReadOnly = true;
            // 
            // HyperPersent
            // 
            this.HyperPersent.DataPropertyName = "HyperPersent";
            this.HyperPersent.HeaderText = "高血压";
            this.HyperPersent.Name = "HyperPersent";
            this.HyperPersent.ReadOnly = true;
            // 
            // DiaPersent
            // 
            this.DiaPersent.DataPropertyName = "DiaPersent";
            this.DiaPersent.HeaderText = "糖尿病";
            this.DiaPersent.Name = "DiaPersent";
            this.DiaPersent.ReadOnly = true;
            // 
            // MentalPersent
            // 
            this.MentalPersent.DataPropertyName = "MentalPersent";
            this.MentalPersent.HeaderText = "精神病";
            this.MentalPersent.Name = "MentalPersent";
            this.MentalPersent.ReadOnly = true;
            // 
            // LungerPersent
            // 
            this.LungerPersent.DataPropertyName = "LungerPersent";
            this.LungerPersent.HeaderText = "肺结核";
            this.LungerPersent.Name = "LungerPersent";
            this.LungerPersent.ReadOnly = true;
            // 
            // StrokePersent
            // 
            this.StrokePersent.DataPropertyName = "StrokePersent";
            this.StrokePersent.HeaderText = "脑卒中";
            this.StrokePersent.Name = "StrokePersent";
            this.StrokePersent.ReadOnly = true;
            // 
            // ChdPersent
            // 
            this.ChdPersent.DataPropertyName = "ChdPersent";
            this.ChdPersent.HeaderText = "冠心病";
            this.ChdPersent.Name = "ChdPersent";
            this.ChdPersent.ReadOnly = true;
            // 
            // frmVisitPercent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvData);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "frmVisitPercent";
            this.Text = "frmVisitPercent";
            this.Load += new System.EventHandler(this.frmVisitPercent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldPersent;
        private System.Windows.Forms.DataGridViewTextBoxColumn HyperPersent;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaPersent;
        private System.Windows.Forms.DataGridViewTextBoxColumn MentalPersent;
        private System.Windows.Forms.DataGridViewTextBoxColumn LungerPersent;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrokePersent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChdPersent;

    }
}