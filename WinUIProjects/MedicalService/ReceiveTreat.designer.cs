namespace MedicalService
{
   partial class ReceiveTreat
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCreateMenName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtCreatTime = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.tbCreateUnitName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbManagePlane = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAssessment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbObjectiveData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSubjectData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIDCARD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSex = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(43, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1452, 625);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCreateMenName);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.dtCreatTime);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.dtReceiveDate);
            this.groupBox2.Controls.Add(this.tbCreateUnitName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbDoctor);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbManagePlane);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbAssessment);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbObjectiveData);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbSubjectData);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox2.Location = new System.Drawing.Point(52, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1349, 497);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接诊信息";
            // 
            // tbCreateMenName
            // 
            this.tbCreateMenName.Location = new System.Drawing.Point(697, 415);
            this.tbCreateMenName.Name = "tbCreateMenName";
            this.tbCreateMenName.ReadOnly = true;
            this.tbCreateMenName.Size = new System.Drawing.Size(344, 30);
            this.tbCreateMenName.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 15F);
            this.label22.Location = new System.Drawing.Point(86, 422);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 20);
            this.label22.TabIndex = 179;
            this.label22.Text = "登 记 人:";
            // 
            // dtCreatTime
            // 
            this.dtCreatTime.Enabled = false;
            this.dtCreatTime.Location = new System.Drawing.Point(193, 459);
            this.dtCreatTime.Name = "dtCreatTime";
            this.dtCreatTime.Size = new System.Drawing.Size(181, 30);
            this.dtCreatTime.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(86, 462);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "登记时间:";
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.Location = new System.Drawing.Point(697, 371);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(200, 30);
            this.dtReceiveDate.TabIndex = 5;
            // 
            // tbCreateUnitName
            // 
            this.tbCreateUnitName.Location = new System.Drawing.Point(193, 416);
            this.tbCreateUnitName.Name = "tbCreateUnitName";
            this.tbCreateUnitName.ReadOnly = true;
            this.tbCreateUnitName.Size = new System.Drawing.Size(332, 30);
            this.tbCreateUnitName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 176;
            this.label5.Text = "登记机构:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(591, 376);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "接诊日期:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(193, 373);
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(332, 30);
            this.tbDoctor.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(86, 378);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "医生签字:";
            // 
            // tbManagePlane
            // 
            this.tbManagePlane.Location = new System.Drawing.Point(191, 277);
            this.tbManagePlane.Multiline = true;
            this.tbManagePlane.Name = "tbManagePlane";
            this.tbManagePlane.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbManagePlane.Size = new System.Drawing.Size(1041, 70);
            this.tbManagePlane.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(86, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "处置计划:";
            // 
            // tbAssessment
            // 
            this.tbAssessment.Location = new System.Drawing.Point(191, 190);
            this.tbAssessment.Multiline = true;
            this.tbAssessment.Name = "tbAssessment";
            this.tbAssessment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAssessment.Size = new System.Drawing.Size(1041, 70);
            this.tbAssessment.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "评    估:";
            // 
            // tbObjectiveData
            // 
            this.tbObjectiveData.Location = new System.Drawing.Point(191, 104);
            this.tbObjectiveData.Multiline = true;
            this.tbObjectiveData.Name = "tbObjectiveData";
            this.tbObjectiveData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObjectiveData.Size = new System.Drawing.Size(1041, 70);
            this.tbObjectiveData.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "就诊者的客观资料:";
            // 
            // tbSubjectData
            // 
            this.tbSubjectData.Location = new System.Drawing.Point(191, 19);
            this.tbSubjectData.Multiline = true;
            this.tbSubjectData.Name = "tbSubjectData";
            this.tbSubjectData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSubjectData.Size = new System.Drawing.Size(1041, 70);
            this.tbSubjectData.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "就诊者的主观资料:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.tbAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbIDCARD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSex);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(52, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1349, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人信息";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(128, 21);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(207, 30);
            this.tbName.TabIndex = 0;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(128, 58);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(362, 30);
            this.tbAddress.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 174;
            this.label4.Text = "家庭住址:";
            // 
            // tbIDCARD
            // 
            this.tbIDCARD.Location = new System.Drawing.Point(720, 21);
            this.tbIDCARD.Name = "tbIDCARD";
            this.tbIDCARD.ReadOnly = true;
            this.tbIDCARD.Size = new System.Drawing.Size(204, 30);
            this.tbIDCARD.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(612, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 172;
            this.label3.Text = "身份证号:";
            // 
            // tbSex
            // 
            this.tbSex.Location = new System.Drawing.Point(492, 21);
            this.tbSex.Name = "tbSex";
            this.tbSex.ReadOnly = true;
            this.tbSex.Size = new System.Drawing.Size(71, 30);
            this.tbSex.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F);
            this.label10.Location = new System.Drawing.Point(386, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 151;
            this.label10.Text = "性    别:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 159;
            this.label1.Text = "姓    名:";
            // 
            // ReceiveTreat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.panel1);
            this.Name = "ReceiveTreat";
            this.Text = "ClinicalAddForm";
            this.Load += new System.EventHandler(this.ClinicalAddForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDoctor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbManagePlane;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbAssessment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbObjectiveData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSubjectData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCreateUnitName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIDCARD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbCreateMenName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtCreatTime;
        private System.Windows.Forms.Label label14;
    }
}