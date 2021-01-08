namespace HealthHouse
{
    partial class HealthVascularForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResetCardiovascular = new System.Windows.Forms.Button();
            this.rdCardiovascularEx = new System.Windows.Forms.RadioButton();
            this.rdCardiovascular = new System.Windows.Forms.RadioButton();
            this.txtCResultEx = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pboxBShow = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtResetCardiovascular);
            this.panel1.Controls.Add(this.rdCardiovascularEx);
            this.panel1.Controls.Add(this.rdCardiovascular);
            this.panel1.Location = new System.Drawing.Point(91, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 45);
            this.panel1.TabIndex = 28;
            // 
            // txtResetCardiovascular
            // 
            this.txtResetCardiovascular.Font = new System.Drawing.Font("宋体", 15F);
            this.txtResetCardiovascular.Location = new System.Drawing.Point(177, 6);
            this.txtResetCardiovascular.Margin = new System.Windows.Forms.Padding(4);
            this.txtResetCardiovascular.Name = "txtResetCardiovascular";
            this.txtResetCardiovascular.Size = new System.Drawing.Size(109, 34);
            this.txtResetCardiovascular.TabIndex = 37;
            this.txtResetCardiovascular.Text = "重置";
            this.txtResetCardiovascular.UseVisualStyleBackColor = true;
            this.txtResetCardiovascular.Click += new System.EventHandler(this.txtResetCardiovascular_Click);
            // 
            // rdCardiovascularEx
            // 
            this.rdCardiovascularEx.AutoSize = true;
            this.rdCardiovascularEx.Font = new System.Drawing.Font("宋体", 15F);
            this.rdCardiovascularEx.Location = new System.Drawing.Point(94, 11);
            this.rdCardiovascularEx.Margin = new System.Windows.Forms.Padding(4);
            this.rdCardiovascularEx.Name = "rdCardiovascularEx";
            this.rdCardiovascularEx.Size = new System.Drawing.Size(67, 24);
            this.rdCardiovascularEx.TabIndex = 36;
            this.rdCardiovascularEx.Text = "异常";
            this.rdCardiovascularEx.UseVisualStyleBackColor = true;
            // 
            // rdCardiovascular
            // 
            this.rdCardiovascular.AutoSize = true;
            this.rdCardiovascular.Font = new System.Drawing.Font("宋体", 15F);
            this.rdCardiovascular.Location = new System.Drawing.Point(8, 11);
            this.rdCardiovascular.Margin = new System.Windows.Forms.Padding(4);
            this.rdCardiovascular.Name = "rdCardiovascular";
            this.rdCardiovascular.Size = new System.Drawing.Size(67, 24);
            this.rdCardiovascular.TabIndex = 35;
            this.rdCardiovascular.Text = "正常";
            this.rdCardiovascular.UseVisualStyleBackColor = true;
            // 
            // txtCResultEx
            // 
            this.txtCResultEx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCResultEx.Font = new System.Drawing.Font("宋体", 15F);
            this.txtCResultEx.Location = new System.Drawing.Point(398, 25);
            this.txtCResultEx.Margin = new System.Windows.Forms.Padding(4);
            this.txtCResultEx.MaxLength = 200;
            this.txtCResultEx.Name = "txtCResultEx";
            this.txtCResultEx.ReadOnly = true;
            this.txtCResultEx.Size = new System.Drawing.Size(668, 30);
            this.txtCResultEx.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(88, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1262, 539);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检测报告";
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
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "心血管";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.txtCResultEx);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox2.Location = new System.Drawing.Point(88, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1262, 71);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // HealthVascularForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HealthVascularForm";
            this.Text = "HealthVascularForm";
            this.Load += new System.EventHandler(this.HealthVascularForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBShow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button txtResetCardiovascular;
        private System.Windows.Forms.RadioButton rdCardiovascularEx;
        private System.Windows.Forms.RadioButton rdCardiovascular;
        private System.Windows.Forms.TextBox txtCResultEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pboxBShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}