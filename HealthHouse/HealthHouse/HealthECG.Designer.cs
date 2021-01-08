namespace HealthHouse
{
    partial class HealthECG
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXDYC = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnReset_xd = new System.Windows.Forms.Button();
            this.radXDYC = new System.Windows.Forms.RadioButton();
            this.radXDZC = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pboxBShow = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel16.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtXDYC);
            this.groupBox1.Controls.Add(this.panel16);
            this.groupBox1.Location = new System.Drawing.Point(88, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1258, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 119;
            this.label1.Text = "心电";
            // 
            // txtXDYC
            // 
            this.txtXDYC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtXDYC.Font = new System.Drawing.Font("宋体", 15F);
            this.txtXDYC.Location = new System.Drawing.Point(362, 30);
            this.txtXDYC.MaxLength = 200;
            this.txtXDYC.Name = "txtXDYC";
            this.txtXDYC.ReadOnly = true;
            this.txtXDYC.Size = new System.Drawing.Size(688, 30);
            this.txtXDYC.TabIndex = 118;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btnReset_xd);
            this.panel16.Controls.Add(this.radXDYC);
            this.panel16.Controls.Add(this.radXDZC);
            this.panel16.Location = new System.Drawing.Point(106, 25);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(250, 36);
            this.panel16.TabIndex = 117;
            // 
            // btnReset_xd
            // 
            this.btnReset_xd.Font = new System.Drawing.Font("宋体", 15F);
            this.btnReset_xd.Location = new System.Drawing.Point(146, 5);
            this.btnReset_xd.Name = "btnReset_xd";
            this.btnReset_xd.Size = new System.Drawing.Size(87, 27);
            this.btnReset_xd.TabIndex = 37;
            this.btnReset_xd.Text = "重置";
            this.btnReset_xd.UseVisualStyleBackColor = true;
            this.btnReset_xd.Click += new System.EventHandler(this.btnReset_xd_Click);
            // 
            // radXDYC
            // 
            this.radXDYC.AutoSize = true;
            this.radXDYC.Font = new System.Drawing.Font("宋体", 15F);
            this.radXDYC.Location = new System.Drawing.Point(78, 7);
            this.radXDYC.Name = "radXDYC";
            this.radXDYC.Size = new System.Drawing.Size(67, 24);
            this.radXDYC.TabIndex = 36;
            this.radXDYC.Text = "异常";
            this.radXDYC.UseVisualStyleBackColor = true;
            // 
            // radXDZC
            // 
            this.radXDZC.AutoSize = true;
            this.radXDZC.Font = new System.Drawing.Font("宋体", 15F);
            this.radXDZC.Location = new System.Drawing.Point(3, 7);
            this.radXDZC.Name = "radXDZC";
            this.radXDZC.Size = new System.Drawing.Size(67, 24);
            this.radXDZC.TabIndex = 35;
            this.radXDZC.Text = "正常";
            this.radXDZC.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox2.Location = new System.Drawing.Point(88, 108);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1262, 539);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检测报告";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.pboxBShow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 27);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1254, 508);
            this.panel2.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 15F);
            this.btnPrint.ForeColor = System.Drawing.Color.Transparent;
            this.btnPrint.Location = new System.Drawing.Point(1092, 16);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(125, 52);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // pboxBShow
            // 
            this.pboxBShow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pboxBShow.Location = new System.Drawing.Point(58, 4);
            this.pboxBShow.Margin = new System.Windows.Forms.Padding(4);
            this.pboxBShow.Name = "pboxBShow";
            this.pboxBShow.Size = new System.Drawing.Size(1004, 1000);
            this.pboxBShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBShow.TabIndex = 3;
            this.pboxBShow.TabStop = false;
            // 
            // HealthECG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HealthECG";
            this.Text = "HealthECG";
            this.Load += new System.EventHandler(this.HealthECG_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnReset_xd;
        private System.Windows.Forms.RadioButton radXDYC;
        private System.Windows.Forms.RadioButton radXDZC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXDYC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pboxBShow;
    }
}