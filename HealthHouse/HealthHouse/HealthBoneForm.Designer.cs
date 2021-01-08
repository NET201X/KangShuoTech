namespace HealthHouse
{
    partial class HealthBoneForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pboxBShow = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnResetBone = new System.Windows.Forms.Button();
            this.rdBoneEx = new System.Windows.Forms.RadioButton();
            this.rdBone = new System.Windows.Forms.RadioButton();
            this.txtResultEx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(99, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1169, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检测报告";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.pboxBShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 510);
            this.panel1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 15F);
            this.btnPrint.ForeColor = System.Drawing.Color.Transparent;
            this.btnPrint.Location = new System.Drawing.Point(1048, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 36);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pboxBShow
            // 
            this.pboxBShow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pboxBShow.Location = new System.Drawing.Point(28, 3);
            this.pboxBShow.Name = "pboxBShow";
            this.pboxBShow.Size = new System.Drawing.Size(1004, 1200);
            this.pboxBShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBShow.TabIndex = 3;
            this.pboxBShow.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel16);
            this.groupBox2.Controls.Add(this.txtResultEx);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(99, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1169, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.UseWaitCursor = true;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btnResetBone);
            this.panel16.Controls.Add(this.rdBoneEx);
            this.panel16.Controls.Add(this.rdBone);
            this.panel16.Location = new System.Drawing.Point(83, 16);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(245, 37);
            this.panel16.TabIndex = 28;
            this.panel16.UseWaitCursor = true;
            // 
            // btnResetBone
            // 
            this.btnResetBone.Font = new System.Drawing.Font("宋体", 15F);
            this.btnResetBone.Location = new System.Drawing.Point(155, 4);
            this.btnResetBone.Name = "btnResetBone";
            this.btnResetBone.Size = new System.Drawing.Size(76, 30);
            this.btnResetBone.TabIndex = 37;
            this.btnResetBone.Text = "重置";
            this.btnResetBone.UseVisualStyleBackColor = true;
            this.btnResetBone.UseWaitCursor = true;
            this.btnResetBone.Click += new System.EventHandler(this.btnResetBone_Click);
            // 
            // rdBoneEx
            // 
            this.rdBoneEx.AutoSize = true;
            this.rdBoneEx.Font = new System.Drawing.Font("宋体", 15F);
            this.rdBoneEx.Location = new System.Drawing.Point(78, 8);
            this.rdBoneEx.Name = "rdBoneEx";
            this.rdBoneEx.Size = new System.Drawing.Size(67, 24);
            this.rdBoneEx.TabIndex = 36;
            this.rdBoneEx.Text = "异常";
            this.rdBoneEx.UseVisualStyleBackColor = true;
            this.rdBoneEx.UseWaitCursor = true;
            // 
            // rdBone
            // 
            this.rdBone.AutoSize = true;
            this.rdBone.Font = new System.Drawing.Font("宋体", 15F);
            this.rdBone.Location = new System.Drawing.Point(7, 8);
            this.rdBone.Name = "rdBone";
            this.rdBone.Size = new System.Drawing.Size(67, 24);
            this.rdBone.TabIndex = 35;
            this.rdBone.Text = "正常";
            this.rdBone.UseVisualStyleBackColor = true;
            this.rdBone.UseWaitCursor = true;
            // 
            // txtResultEx
            // 
            this.txtResultEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResultEx.Font = new System.Drawing.Font("宋体", 15F);
            this.txtResultEx.Location = new System.Drawing.Point(340, 20);
            this.txtResultEx.MaxLength = 200;
            this.txtResultEx.Name = "txtResultEx";
            this.txtResultEx.ReadOnly = true;
            this.txtResultEx.Size = new System.Drawing.Size(687, 30);
            this.txtResultEx.TabIndex = 29;
            this.txtResultEx.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "骨密度";
            this.label1.UseWaitCursor = true;
            // 
            // HealthBoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "HealthBoneForm";
            this.Text = "HealthBoneForm";
            this.Load += new System.EventHandler(this.HealthBoneForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pboxBShow;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnResetBone;
        private System.Windows.Forms.RadioButton rdBoneEx;
        private System.Windows.Forms.RadioButton rdBone;
        private System.Windows.Forms.TextBox txtResultEx;
        private System.Windows.Forms.Label label1;
    }
}