namespace HealthHouse
{
    partial class HealthLungForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnResetLung = new System.Windows.Forms.Button();
            this.rdLungEx = new System.Windows.Forms.RadioButton();
            this.rdLung = new System.Windows.Forms.RadioButton();
            this.txtLResultEx = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pboxBShow = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnResetLung);
            this.panel2.Controls.Add(this.rdLungEx);
            this.panel2.Controls.Add(this.rdLung);
            this.panel2.Location = new System.Drawing.Point(95, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 45);
            this.panel2.TabIndex = 32;
            // 
            // btnResetLung
            // 
            this.btnResetLung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetLung.Font = new System.Drawing.Font("宋体", 15F);
            this.btnResetLung.Location = new System.Drawing.Point(170, 6);
            this.btnResetLung.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetLung.Name = "btnResetLung";
            this.btnResetLung.Size = new System.Drawing.Size(109, 34);
            this.btnResetLung.TabIndex = 37;
            this.btnResetLung.Text = "重置";
            this.btnResetLung.UseVisualStyleBackColor = true;
            this.btnResetLung.Click += new System.EventHandler(this.btnResetLung_Click);
            // 
            // rdLungEx
            // 
            this.rdLungEx.Font = new System.Drawing.Font("宋体", 15F);
            this.rdLungEx.Location = new System.Drawing.Point(91, 11);
            this.rdLungEx.Margin = new System.Windows.Forms.Padding(4);
            this.rdLungEx.Name = "rdLungEx";
            this.rdLungEx.Size = new System.Drawing.Size(67, 24);
            this.rdLungEx.TabIndex = 36;
            this.rdLungEx.Text = "异常";
            this.rdLungEx.UseVisualStyleBackColor = true;
            // 
            // rdLung
            // 
            this.rdLung.Font = new System.Drawing.Font("宋体", 15F);
            this.rdLung.Location = new System.Drawing.Point(11, 11);
            this.rdLung.Margin = new System.Windows.Forms.Padding(4);
            this.rdLung.Name = "rdLung";
            this.rdLung.Size = new System.Drawing.Size(67, 24);
            this.rdLung.TabIndex = 35;
            this.rdLung.Text = "正常";
            this.rdLung.UseVisualStyleBackColor = true;
            // 
            // txtLResultEx
            // 
            this.txtLResultEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLResultEx.Font = new System.Drawing.Font("宋体", 15F);
            this.txtLResultEx.Location = new System.Drawing.Point(395, 21);
            this.txtLResultEx.Margin = new System.Windows.Forms.Padding(4);
            this.txtLResultEx.MaxLength = 200;
            this.txtLResultEx.Name = "txtLResultEx";
            this.txtLResultEx.ReadOnly = true;
            this.txtLResultEx.Size = new System.Drawing.Size(759, 30);
            this.txtLResultEx.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(102, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1258, 539);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检测报告";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.pboxBShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 508);
            this.panel1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 15F);
            this.btnPrint.ForeColor = System.Drawing.Color.Transparent;
            this.btnPrint.Location = new System.Drawing.Point(1075, 18);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(125, 52);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pboxBShow
            // 
            this.pboxBShow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pboxBShow.Location = new System.Drawing.Point(51, 4);
            this.pboxBShow.Margin = new System.Windows.Forms.Padding(4);
            this.pboxBShow.Name = "pboxBShow";
            this.pboxBShow.Size = new System.Drawing.Size(1004, 1200);
            this.pboxBShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBShow.TabIndex = 3;
            this.pboxBShow.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "肺功能";
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtLResultEx);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox2.Location = new System.Drawing.Point(102, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1258, 65);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // HealthLungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HealthLungForm";
            this.Text = "HealthLungForm";
            this.Load += new System.EventHandler(this.HealthLungForm_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnResetLung;
        private System.Windows.Forms.RadioButton rdLungEx;
        private System.Windows.Forms.RadioButton rdLung;
        private System.Windows.Forms.TextBox txtLResultEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pboxBShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}