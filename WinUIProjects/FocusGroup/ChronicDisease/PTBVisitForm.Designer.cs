using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.DataAccessProjects.Model;
namespace FocusGroup
{
    partial class PTBVisitForm : IChildForm, IChildModel<RecordsBaseInfoModel>
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdoSupervisor4 = new System.Windows.Forms.RadioButton();
            this.rdoSupervisor1 = new System.Windows.Forms.RadioButton();
            this.rdoSupervisor3 = new System.Windows.Forms.RadioButton();
            this.rdoSupervisor2 = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCureMonth = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFollowupDate = new System.Windows.Forms.DateTimePicker();
            this.label43 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radPhone = new System.Windows.Forms.RadioButton();
            this.radMZ = new System.Windows.Forms.RadioButton();
            this.radFamily = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ckGroup9 = new System.Windows.Forms.CheckBox();
            this.ckGroup8 = new System.Windows.Forms.CheckBox();
            this.ckGroup7 = new System.Windows.Forms.CheckBox();
            this.ckGroup6 = new System.Windows.Forms.CheckBox();
            this.ckGroup5 = new System.Windows.Forms.CheckBox();
            this.ckGroup4 = new System.Windows.Forms.CheckBox();
            this.ckGroup3 = new System.Windows.Forms.CheckBox();
            this.ckGroup2 = new System.Windows.Forms.CheckBox();
            this.ckGroup1 = new System.Windows.Forms.CheckBox();
            this.ckGroup0 = new System.Windows.Forms.CheckBox();
            this.tbZzOther = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOmissiveTimes = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chkDrugType4 = new System.Windows.Forms.CheckBox();
            this.chkDrugType3 = new System.Windows.Forms.CheckBox();
            this.chkDrugType2 = new System.Windows.Forms.CheckBox();
            this.chkDrugType1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdoMedicationCompliance1 = new System.Windows.Forms.RadioButton();
            this.rdoMedicationCompliance2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChemotherapyScheme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtComplicationEx = new System.Windows.Forms.TextBox();
            this.txtAdrEx = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rdoComplication2 = new System.Windows.Forms.RadioButton();
            this.rdoComplication1 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rdoAdr1 = new System.Windows.Forms.RadioButton();
            this.rdoAdr2 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.GBoxManager = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtPharmacyRate = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtPharmacyTimes = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtShouldPharmacyTimes = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtVisitTimes = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtShouldVisitTimes = new System.Windows.Forms.TextBox();
            this.txtEstimateDoctor = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtHandleView = new System.Windows.Forms.TextBox();
            this.txtReferralResult = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpNextVisitDate = new System.Windows.Forms.DateTimePicker();
            this.txtReferralOrg = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtReferralReason = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.GBoxStopCure = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbStopCureReason4 = new System.Windows.Forms.CheckBox();
            this.chbStopCureReason3 = new System.Windows.Forms.CheckBox();
            this.chbStopCureReason2 = new System.Windows.Forms.CheckBox();
            this.chbStopCureReason1 = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpStopCureDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnNoDrink = new System.Windows.Forms.Button();
            this.btnNoSmoke = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.txtNextDayDrinkVolume = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtNextSmokeDayNum = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDayDrinkVolume = new System.Windows.Forms.TextBox();
            this.txtSmokeDayNum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.GBoxManager.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.GBoxStopCure.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panel8);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCureMonth);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFollowupDate);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(70, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1400, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rdoSupervisor4);
            this.panel8.Controls.Add(this.rdoSupervisor1);
            this.panel8.Controls.Add(this.rdoSupervisor3);
            this.panel8.Controls.Add(this.rdoSupervisor2);
            this.panel8.Font = new System.Drawing.Font("宋体", 15F);
            this.panel8.Location = new System.Drawing.Point(155, 57);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(351, 28);
            this.panel8.TabIndex = 2;
            // 
            // rdoSupervisor4
            // 
            this.rdoSupervisor4.AutoSize = true;
            this.rdoSupervisor4.Location = new System.Drawing.Point(262, 2);
            this.rdoSupervisor4.Name = "rdoSupervisor4";
            this.rdoSupervisor4.Size = new System.Drawing.Size(67, 24);
            this.rdoSupervisor4.TabIndex = 3;
            this.rdoSupervisor4.TabStop = true;
            this.rdoSupervisor4.Text = "其他";
            this.rdoSupervisor4.UseVisualStyleBackColor = true;
            // 
            // rdoSupervisor1
            // 
            this.rdoSupervisor1.AutoSize = true;
            this.rdoSupervisor1.Location = new System.Drawing.Point(3, 2);
            this.rdoSupervisor1.Name = "rdoSupervisor1";
            this.rdoSupervisor1.Size = new System.Drawing.Size(67, 24);
            this.rdoSupervisor1.TabIndex = 0;
            this.rdoSupervisor1.TabStop = true;
            this.rdoSupervisor1.Text = "医生";
            this.rdoSupervisor1.UseVisualStyleBackColor = true;
            // 
            // rdoSupervisor3
            // 
            this.rdoSupervisor3.AutoSize = true;
            this.rdoSupervisor3.Location = new System.Drawing.Point(159, 2);
            this.rdoSupervisor3.Name = "rdoSupervisor3";
            this.rdoSupervisor3.Size = new System.Drawing.Size(87, 24);
            this.rdoSupervisor3.TabIndex = 2;
            this.rdoSupervisor3.TabStop = true;
            this.rdoSupervisor3.Text = "自服药";
            this.rdoSupervisor3.UseVisualStyleBackColor = true;
            // 
            // rdoSupervisor2
            // 
            this.rdoSupervisor2.AutoSize = true;
            this.rdoSupervisor2.Location = new System.Drawing.Point(79, 1);
            this.rdoSupervisor2.Name = "rdoSupervisor2";
            this.rdoSupervisor2.Size = new System.Drawing.Size(67, 24);
            this.rdoSupervisor2.TabIndex = 1;
            this.rdoSupervisor2.TabStop = true;
            this.rdoSupervisor2.Text = "家属";
            this.rdoSupervisor2.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 15F);
            this.label28.Location = new System.Drawing.Point(764, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 20);
            this.label28.TabIndex = 53;
            this.label28.Text = "月";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F);
            this.label8.Location = new System.Drawing.Point(13, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "督导人员选择:";
            // 
            // txtCureMonth
            // 
            this.txtCureMonth.Font = new System.Drawing.Font("宋体", 15F);
            this.txtCureMonth.Location = new System.Drawing.Point(691, 15);
            this.txtCureMonth.Name = "txtCureMonth";
            this.txtCureMonth.Size = new System.Drawing.Size(67, 30);
            this.txtCureMonth.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 15F);
            this.label27.Location = new System.Drawing.Point(653, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 20);
            this.label27.TabIndex = 51;
            this.label27.Text = "第";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(532, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "治疗月序:";
            // 
            // dtpFollowupDate
            // 
            this.dtpFollowupDate.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpFollowupDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFollowupDate.Location = new System.Drawing.Point(156, 14);
            this.dtpFollowupDate.Name = "dtpFollowupDate";
            this.dtpFollowupDate.Size = new System.Drawing.Size(183, 30);
            this.dtpFollowupDate.TabIndex = 0;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 15F);
            this.label43.Location = new System.Drawing.Point(53, 18);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(99, 20);
            this.label43.TabIndex = 41;
            this.label43.Text = "随访日期:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radPhone);
            this.panel1.Controls.Add(this.radMZ);
            this.panel1.Controls.Add(this.radFamily);
            this.panel1.Font = new System.Drawing.Font("宋体", 15F);
            this.panel1.Location = new System.Drawing.Point(652, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 28);
            this.panel1.TabIndex = 3;
            // 
            // radPhone
            // 
            this.radPhone.AutoSize = true;
            this.radPhone.Location = new System.Drawing.Point(161, 3);
            this.radPhone.Name = "radPhone";
            this.radPhone.Size = new System.Drawing.Size(67, 24);
            this.radPhone.TabIndex = 2;
            this.radPhone.TabStop = true;
            this.radPhone.Text = "电话";
            this.radPhone.UseVisualStyleBackColor = true;
            // 
            // radMZ
            // 
            this.radMZ.AutoSize = true;
            this.radMZ.Location = new System.Drawing.Point(3, 2);
            this.radMZ.Name = "radMZ";
            this.radMZ.Size = new System.Drawing.Size(67, 24);
            this.radMZ.TabIndex = 0;
            this.radMZ.TabStop = true;
            this.radMZ.Text = "门诊";
            this.radMZ.UseVisualStyleBackColor = true;
            // 
            // radFamily
            // 
            this.radFamily.AutoSize = true;
            this.radFamily.Location = new System.Drawing.Point(80, 2);
            this.radFamily.Name = "radFamily";
            this.radFamily.Size = new System.Drawing.Size(67, 24);
            this.radFamily.TabIndex = 1;
            this.radFamily.TabStop = true;
            this.radFamily.Text = "家庭";
            this.radFamily.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(532, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "随访方式:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Font = new System.Drawing.Font("宋体", 15F);
            this.tbDoctor.Location = new System.Drawing.Point(1052, 49);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(184, 30);
            this.tbDoctor.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F);
            this.label15.Location = new System.Drawing.Point(943, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 43;
            this.label15.Text = "随访医生:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.panel5);
            this.groupBox4.Controls.Add(this.tbZzOther);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox4.Location = new System.Drawing.Point(70, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1400, 87);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "症状及特征";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ckGroup9);
            this.panel5.Controls.Add(this.ckGroup8);
            this.panel5.Controls.Add(this.ckGroup7);
            this.panel5.Controls.Add(this.ckGroup6);
            this.panel5.Controls.Add(this.ckGroup5);
            this.panel5.Controls.Add(this.ckGroup4);
            this.panel5.Controls.Add(this.ckGroup3);
            this.panel5.Controls.Add(this.ckGroup2);
            this.panel5.Controls.Add(this.ckGroup1);
            this.panel5.Controls.Add(this.ckGroup0);
            this.panel5.Location = new System.Drawing.Point(9, 13);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(756, 68);
            this.panel5.TabIndex = 0;
            // 
            // ckGroup9
            // 
            this.ckGroup9.AutoSize = true;
            this.ckGroup9.Location = new System.Drawing.Point(575, 39);
            this.ckGroup9.Name = "ckGroup9";
            this.ckGroup9.Size = new System.Drawing.Size(168, 24);
            this.ckGroup9.TabIndex = 27;
            this.ckGroup9.Text = "耳鸣、听力下降";
            this.ckGroup9.UseVisualStyleBackColor = true;
            // 
            // ckGroup8
            // 
            this.ckGroup8.AutoSize = true;
            this.ckGroup8.Location = new System.Drawing.Point(393, 39);
            this.ckGroup8.Name = "ckGroup8";
            this.ckGroup8.Size = new System.Drawing.Size(168, 24);
            this.ckGroup8.TabIndex = 26;
            this.ckGroup8.Text = "皮肤瘙痒、皮疹";
            this.ckGroup8.UseVisualStyleBackColor = true;
            // 
            // ckGroup7
            // 
            this.ckGroup7.AutoSize = true;
            this.ckGroup7.Location = new System.Drawing.Point(271, 39);
            this.ckGroup7.Name = "ckGroup7";
            this.ckGroup7.Size = new System.Drawing.Size(108, 24);
            this.ckGroup7.TabIndex = 25;
            this.ckGroup7.Text = "视物模糊";
            this.ckGroup7.UseVisualStyleBackColor = true;
            // 
            // ckGroup6
            // 
            this.ckGroup6.AutoSize = true;
            this.ckGroup6.Location = new System.Drawing.Point(147, 39);
            this.ckGroup6.Name = "ckGroup6";
            this.ckGroup6.Size = new System.Drawing.Size(108, 24);
            this.ckGroup6.TabIndex = 24;
            this.ckGroup6.Text = "头痛失眠";
            this.ckGroup6.UseVisualStyleBackColor = true;
            // 
            // ckGroup5
            // 
            this.ckGroup5.AutoSize = true;
            this.ckGroup5.Location = new System.Drawing.Point(26, 39);
            this.ckGroup5.Name = "ckGroup5";
            this.ckGroup5.Size = new System.Drawing.Size(108, 24);
            this.ckGroup5.TabIndex = 23;
            this.ckGroup5.Text = "恶心纳差";
            this.ckGroup5.UseVisualStyleBackColor = true;
            // 
            // ckGroup4
            // 
            this.ckGroup4.AutoSize = true;
            this.ckGroup4.Location = new System.Drawing.Point(575, 9);
            this.ckGroup4.Name = "ckGroup4";
            this.ckGroup4.Size = new System.Drawing.Size(108, 24);
            this.ckGroup4.TabIndex = 22;
            this.ckGroup4.Text = "胸痛消瘦";
            this.ckGroup4.UseVisualStyleBackColor = true;
            // 
            // ckGroup3
            // 
            this.ckGroup3.AutoSize = true;
            this.ckGroup3.Location = new System.Drawing.Point(393, 9);
            this.ckGroup3.Name = "ckGroup3";
            this.ckGroup3.Size = new System.Drawing.Size(128, 24);
            this.ckGroup3.TabIndex = 21;
            this.ckGroup3.Text = "咯血或血痰";
            this.ckGroup3.UseVisualStyleBackColor = true;
            // 
            // ckGroup2
            // 
            this.ckGroup2.AutoSize = true;
            this.ckGroup2.Location = new System.Drawing.Point(271, 9);
            this.ckGroup2.Name = "ckGroup2";
            this.ckGroup2.Size = new System.Drawing.Size(108, 24);
            this.ckGroup2.TabIndex = 20;
            this.ckGroup2.Text = "低热盗汗";
            this.ckGroup2.UseVisualStyleBackColor = true;
            // 
            // ckGroup1
            // 
            this.ckGroup1.AutoSize = true;
            this.ckGroup1.Location = new System.Drawing.Point(147, 9);
            this.ckGroup1.Name = "ckGroup1";
            this.ckGroup1.Size = new System.Drawing.Size(108, 24);
            this.ckGroup1.TabIndex = 19;
            this.ckGroup1.Text = "咳嗽咳痰";
            this.ckGroup1.UseVisualStyleBackColor = true;
            // 
            // ckGroup0
            // 
            this.ckGroup0.AutoSize = true;
            this.ckGroup0.Location = new System.Drawing.Point(26, 9);
            this.ckGroup0.Name = "ckGroup0";
            this.ckGroup0.Size = new System.Drawing.Size(88, 24);
            this.ckGroup0.TabIndex = 18;
            this.ckGroup0.Text = "无症状";
            this.ckGroup0.UseVisualStyleBackColor = true;
            // 
            // tbZzOther
            // 
            this.tbZzOther.Location = new System.Drawing.Point(838, 18);
            this.tbZzOther.MaxLength = 100;
            this.tbZzOther.Multiline = true;
            this.tbZzOther.Name = "tbZzOther";
            this.tbZzOther.Size = new System.Drawing.Size(361, 58);
            this.tbZzOther.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtOmissiveTimes);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtChemotherapyScheme);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox2.Location = new System.Drawing.Point(70, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1400, 110);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用药";
            // 
            // txtOmissiveTimes
            // 
            this.txtOmissiveTimes.Location = new System.Drawing.Point(880, 29);
            this.txtOmissiveTimes.Name = "txtOmissiveTimes";
            this.txtOmissiveTimes.Size = new System.Drawing.Size(87, 30);
            this.txtOmissiveTimes.TabIndex = 2;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 15F);
            this.label34.Location = new System.Drawing.Point(978, 31);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 20);
            this.label34.TabIndex = 51;
            this.label34.Text = "次";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 15F);
            this.label33.Location = new System.Drawing.Point(756, 31);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(119, 20);
            this.label33.TabIndex = 50;
            this.label33.Text = "漏服药次数:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.chkDrugType4);
            this.panel7.Controls.Add(this.chkDrugType3);
            this.panel7.Controls.Add(this.chkDrugType2);
            this.panel7.Controls.Add(this.chkDrugType1);
            this.panel7.Font = new System.Drawing.Font("宋体", 10F);
            this.panel7.Location = new System.Drawing.Point(157, 71);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(864, 32);
            this.panel7.TabIndex = 3;
            // 
            // chkDrugType4
            // 
            this.chkDrugType4.AutoSize = true;
            this.chkDrugType4.Font = new System.Drawing.Font("宋体", 15F);
            this.chkDrugType4.Location = new System.Drawing.Point(499, 5);
            this.chkDrugType4.Name = "chkDrugType4";
            this.chkDrugType4.Size = new System.Drawing.Size(88, 24);
            this.chkDrugType4.TabIndex = 22;
            this.chkDrugType4.Text = "注射剂";
            this.chkDrugType4.UseVisualStyleBackColor = true;
            // 
            // chkDrugType3
            // 
            this.chkDrugType3.AutoSize = true;
            this.chkDrugType3.Font = new System.Drawing.Font("宋体", 15F);
            this.chkDrugType3.Location = new System.Drawing.Point(337, 5);
            this.chkDrugType3.Name = "chkDrugType3";
            this.chkDrugType3.Size = new System.Drawing.Size(128, 24);
            this.chkDrugType3.TabIndex = 21;
            this.chkDrugType3.Text = "板式组合药";
            this.chkDrugType3.UseVisualStyleBackColor = true;
            // 
            // chkDrugType2
            // 
            this.chkDrugType2.AutoSize = true;
            this.chkDrugType2.Font = new System.Drawing.Font("宋体", 15F);
            this.chkDrugType2.Location = new System.Drawing.Point(225, 5);
            this.chkDrugType2.Name = "chkDrugType2";
            this.chkDrugType2.Size = new System.Drawing.Size(88, 24);
            this.chkDrugType2.TabIndex = 20;
            this.chkDrugType2.Text = "散装药";
            this.chkDrugType2.UseVisualStyleBackColor = true;
            // 
            // chkDrugType1
            // 
            this.chkDrugType1.AutoSize = true;
            this.chkDrugType1.Font = new System.Drawing.Font("宋体", 15F);
            this.chkDrugType1.Location = new System.Drawing.Point(11, 5);
            this.chkDrugType1.Name = "chkDrugType1";
            this.chkDrugType1.Size = new System.Drawing.Size(188, 24);
            this.chkDrugType1.TabIndex = 19;
            this.chkDrugType1.Text = "固定剂量复合制剂";
            this.chkDrugType1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F);
            this.label7.Location = new System.Drawing.Point(53, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 48;
            this.label7.Text = "药品剂型:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rdoMedicationCompliance1);
            this.panel6.Controls.Add(this.rdoMedicationCompliance2);
            this.panel6.Font = new System.Drawing.Font("宋体", 15F);
            this.panel6.Location = new System.Drawing.Point(496, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(184, 32);
            this.panel6.TabIndex = 1;
            // 
            // rdoMedicationCompliance1
            // 
            this.rdoMedicationCompliance1.AutoSize = true;
            this.rdoMedicationCompliance1.Location = new System.Drawing.Point(3, 2);
            this.rdoMedicationCompliance1.Name = "rdoMedicationCompliance1";
            this.rdoMedicationCompliance1.Size = new System.Drawing.Size(67, 24);
            this.rdoMedicationCompliance1.TabIndex = 0;
            this.rdoMedicationCompliance1.TabStop = true;
            this.rdoMedicationCompliance1.Text = "每日";
            this.rdoMedicationCompliance1.UseVisualStyleBackColor = true;
            // 
            // rdoMedicationCompliance2
            // 
            this.rdoMedicationCompliance2.AutoSize = true;
            this.rdoMedicationCompliance2.Location = new System.Drawing.Point(94, 2);
            this.rdoMedicationCompliance2.Name = "rdoMedicationCompliance2";
            this.rdoMedicationCompliance2.Size = new System.Drawing.Size(67, 24);
            this.rdoMedicationCompliance2.TabIndex = 1;
            this.rdoMedicationCompliance2.TabStop = true;
            this.rdoMedicationCompliance2.Text = "间歇";
            this.rdoMedicationCompliance2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(388, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "用    法:";
            // 
            // txtChemotherapyScheme
            // 
            this.txtChemotherapyScheme.Font = new System.Drawing.Font("宋体", 15F);
            this.txtChemotherapyScheme.Location = new System.Drawing.Point(156, 27);
            this.txtChemotherapyScheme.MaxLength = 20;
            this.txtChemotherapyScheme.Name = "txtChemotherapyScheme";
            this.txtChemotherapyScheme.Size = new System.Drawing.Size(184, 30);
            this.txtChemotherapyScheme.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(53, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "化疗方案:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtComplicationEx);
            this.groupBox5.Controls.Add(this.txtAdrEx);
            this.groupBox5.Controls.Add(this.panel10);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.panel9);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox5.Location = new System.Drawing.Point(70, 351);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1400, 51);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // txtComplicationEx
            // 
            this.txtComplicationEx.Location = new System.Drawing.Point(877, 17);
            this.txtComplicationEx.Name = "txtComplicationEx";
            this.txtComplicationEx.ReadOnly = true;
            this.txtComplicationEx.Size = new System.Drawing.Size(205, 30);
            this.txtComplicationEx.TabIndex = 3;
            // 
            // txtAdrEx
            // 
            this.txtAdrEx.Location = new System.Drawing.Point(310, 18);
            this.txtAdrEx.Name = "txtAdrEx";
            this.txtAdrEx.ReadOnly = true;
            this.txtAdrEx.Size = new System.Drawing.Size(173, 30);
            this.txtAdrEx.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.rdoComplication2);
            this.panel10.Controls.Add(this.rdoComplication1);
            this.panel10.Font = new System.Drawing.Font("宋体", 15F);
            this.panel10.Location = new System.Drawing.Point(721, 15);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(137, 31);
            this.panel10.TabIndex = 2;
            // 
            // rdoComplication2
            // 
            this.rdoComplication2.AutoSize = true;
            this.rdoComplication2.Location = new System.Drawing.Point(70, 3);
            this.rdoComplication2.Name = "rdoComplication2";
            this.rdoComplication2.Size = new System.Drawing.Size(47, 24);
            this.rdoComplication2.TabIndex = 4;
            this.rdoComplication2.TabStop = true;
            this.rdoComplication2.Text = "无";
            this.rdoComplication2.UseVisualStyleBackColor = true;
            this.rdoComplication2.CheckedChanged += new System.EventHandler(this.rdoComplication2_CheckedChanged);
            // 
            // rdoComplication1
            // 
            this.rdoComplication1.AutoSize = true;
            this.rdoComplication1.Location = new System.Drawing.Point(5, 3);
            this.rdoComplication1.Name = "rdoComplication1";
            this.rdoComplication1.Size = new System.Drawing.Size(47, 24);
            this.rdoComplication1.TabIndex = 0;
            this.rdoComplication1.TabStop = true;
            this.rdoComplication1.Text = "有";
            this.rdoComplication1.UseVisualStyleBackColor = true;
            this.rdoComplication1.CheckedChanged += new System.EventHandler(this.rdoComplication1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F);
            this.label10.Location = new System.Drawing.Point(553, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 20);
            this.label10.TabIndex = 52;
            this.label10.Text = "并发症或合并症:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.rdoAdr1);
            this.panel9.Controls.Add(this.rdoAdr2);
            this.panel9.Font = new System.Drawing.Font("宋体", 15F);
            this.panel9.Location = new System.Drawing.Point(155, 19);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(125, 28);
            this.panel9.TabIndex = 0;
            // 
            // rdoAdr1
            // 
            this.rdoAdr1.AutoSize = true;
            this.rdoAdr1.Location = new System.Drawing.Point(3, 3);
            this.rdoAdr1.Name = "rdoAdr1";
            this.rdoAdr1.Size = new System.Drawing.Size(47, 24);
            this.rdoAdr1.TabIndex = 0;
            this.rdoAdr1.TabStop = true;
            this.rdoAdr1.Text = "有";
            this.rdoAdr1.UseVisualStyleBackColor = true;
            this.rdoAdr1.CheckedChanged += new System.EventHandler(this.rdoAdr1_CheckedChanged);
            // 
            // rdoAdr2
            // 
            this.rdoAdr2.AutoSize = true;
            this.rdoAdr2.Location = new System.Drawing.Point(64, 2);
            this.rdoAdr2.Name = "rdoAdr2";
            this.rdoAdr2.Size = new System.Drawing.Size(47, 24);
            this.rdoAdr2.TabIndex = 1;
            this.rdoAdr2.TabStop = true;
            this.rdoAdr2.Text = "无";
            this.rdoAdr2.UseVisualStyleBackColor = true;
            this.rdoAdr2.CheckedChanged += new System.EventHandler(this.rdoAdr2_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F);
            this.label9.Location = new System.Drawing.Point(13, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 43;
            this.label9.Text = "药物不良反应:";
            // 
            // GBoxManager
            // 
            this.GBoxManager.BackColor = System.Drawing.Color.Transparent;
            this.GBoxManager.Controls.Add(this.label41);
            this.GBoxManager.Controls.Add(this.txtPharmacyRate);
            this.GBoxManager.Controls.Add(this.label40);
            this.GBoxManager.Controls.Add(this.label39);
            this.GBoxManager.Controls.Add(this.txtPharmacyTimes);
            this.GBoxManager.Controls.Add(this.label37);
            this.GBoxManager.Controls.Add(this.label36);
            this.GBoxManager.Controls.Add(this.txtShouldPharmacyTimes);
            this.GBoxManager.Controls.Add(this.label35);
            this.GBoxManager.Controls.Add(this.label26);
            this.GBoxManager.Controls.Add(this.txtVisitTimes);
            this.GBoxManager.Controls.Add(this.label25);
            this.GBoxManager.Controls.Add(this.label24);
            this.GBoxManager.Controls.Add(this.txtShouldVisitTimes);
            this.GBoxManager.Controls.Add(this.txtEstimateDoctor);
            this.GBoxManager.Controls.Add(this.label38);
            this.GBoxManager.Controls.Add(this.label23);
            this.GBoxManager.Font = new System.Drawing.Font("宋体", 15F);
            this.GBoxManager.Location = new System.Drawing.Point(70, 573);
            this.GBoxManager.Name = "GBoxManager";
            this.GBoxManager.Size = new System.Drawing.Size(1400, 101);
            this.GBoxManager.TabIndex = 7;
            this.GBoxManager.TabStop = false;
            this.GBoxManager.Text = "全程管理情况";
            this.GBoxManager.Visible = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(243, 68);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(19, 20);
            this.label41.TabIndex = 64;
            this.label41.Text = "%";
            // 
            // txtPharmacyRate
            // 
            this.txtPharmacyRate.Location = new System.Drawing.Point(178, 63);
            this.txtPharmacyRate.MaxLength = 20;
            this.txtPharmacyRate.Name = "txtPharmacyRate";
            this.txtPharmacyRate.ReadOnly = true;
            this.txtPharmacyRate.Size = new System.Drawing.Size(54, 30);
            this.txtPharmacyRate.TabIndex = 4;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(92, 72);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(79, 20);
            this.label40.TabIndex = 62;
            this.label40.Text = "服药率:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 15F);
            this.label39.Location = new System.Drawing.Point(1189, 27);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 20);
            this.label39.TabIndex = 61;
            this.label39.Text = "次";
            // 
            // txtPharmacyTimes
            // 
            this.txtPharmacyTimes.Location = new System.Drawing.Point(1119, 22);
            this.txtPharmacyTimes.MaxLength = 2;
            this.txtPharmacyTimes.Name = "txtPharmacyTimes";
            this.txtPharmacyTimes.Size = new System.Drawing.Size(59, 30);
            this.txtPharmacyTimes.TabIndex = 3;
            this.txtPharmacyTimes.TextChanged += new System.EventHandler(this.txtPharmacyTimes_TextChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(962, 27);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(139, 20);
            this.label37.TabIndex = 59;
            this.label37.Text = "实际服药次数:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 15F);
            this.label36.Location = new System.Drawing.Point(850, 26);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 20);
            this.label36.TabIndex = 58;
            this.label36.Text = "次";
            // 
            // txtShouldPharmacyTimes
            // 
            this.txtShouldPharmacyTimes.Location = new System.Drawing.Point(778, 23);
            this.txtShouldPharmacyTimes.MaxLength = 2;
            this.txtShouldPharmacyTimes.Name = "txtShouldPharmacyTimes";
            this.txtShouldPharmacyTimes.Size = new System.Drawing.Size(59, 30);
            this.txtShouldPharmacyTimes.TabIndex = 2;
            this.txtShouldPharmacyTimes.TextChanged += new System.EventHandler(this.txtShouldPharmacyTimes_TextChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(653, 28);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(119, 20);
            this.label35.TabIndex = 56;
            this.label35.Text = "应服药次数:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F);
            this.label26.Location = new System.Drawing.Point(562, 30);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 20);
            this.label26.TabIndex = 55;
            this.label26.Text = "次";
            // 
            // txtVisitTimes
            // 
            this.txtVisitTimes.Location = new System.Drawing.Point(493, 27);
            this.txtVisitTimes.MaxLength = 20;
            this.txtVisitTimes.Name = "txtVisitTimes";
            this.txtVisitTimes.Size = new System.Drawing.Size(59, 30);
            this.txtVisitTimes.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(309, 33);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(179, 20);
            this.label25.TabIndex = 53;
            this.label25.Text = "实际访视患者次数:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 15F);
            this.label24.Location = new System.Drawing.Point(238, 34);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 20);
            this.label24.TabIndex = 52;
            this.label24.Text = "次";
            // 
            // txtShouldVisitTimes
            // 
            this.txtShouldVisitTimes.Location = new System.Drawing.Point(178, 30);
            this.txtShouldVisitTimes.MaxLength = 20;
            this.txtShouldVisitTimes.Name = "txtShouldVisitTimes";
            this.txtShouldVisitTimes.Size = new System.Drawing.Size(54, 30);
            this.txtShouldVisitTimes.TabIndex = 0;
            // 
            // txtEstimateDoctor
            // 
            this.txtEstimateDoctor.Location = new System.Drawing.Point(493, 67);
            this.txtEstimateDoctor.MaxLength = 20;
            this.txtEstimateDoctor.Name = "txtEstimateDoctor";
            this.txtEstimateDoctor.Size = new System.Drawing.Size(144, 30);
            this.txtEstimateDoctor.TabIndex = 5;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(385, 73);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(99, 20);
            this.label38.TabIndex = 0;
            this.label38.Text = "评估医生:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(159, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "应访视患者次数:";
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.txtHandleView);
            this.groupBox9.Controls.Add(this.txtReferralResult);
            this.groupBox9.Controls.Add(this.label17);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.dtpNextVisitDate);
            this.groupBox9.Controls.Add(this.txtReferralOrg);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.tbDoctor);
            this.groupBox9.Controls.Add(this.txtReferralReason);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox9.Location = new System.Drawing.Point(70, 405);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1400, 87);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            // 
            // txtHandleView
            // 
            this.txtHandleView.Location = new System.Drawing.Point(154, 52);
            this.txtHandleView.Name = "txtHandleView";
            this.txtHandleView.Size = new System.Drawing.Size(247, 30);
            this.txtHandleView.TabIndex = 3;
            // 
            // txtReferralResult
            // 
            this.txtReferralResult.Location = new System.Drawing.Point(1052, 13);
            this.txtReferralResult.Name = "txtReferralResult";
            this.txtReferralResult.Size = new System.Drawing.Size(247, 30);
            this.txtReferralResult.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 15F);
            this.label17.Location = new System.Drawing.Point(53, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 45;
            this.label17.Text = "处理意见:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F);
            this.label16.Location = new System.Drawing.Point(887, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(159, 20);
            this.label16.TabIndex = 45;
            this.label16.Text = "两周内随访结果:";
            // 
            // dtpNextVisitDate
            // 
            this.dtpNextVisitDate.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpNextVisitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNextVisitDate.Location = new System.Drawing.Point(632, 50);
            this.dtpNextVisitDate.Name = "dtpNextVisitDate";
            this.dtpNextVisitDate.Size = new System.Drawing.Size(162, 30);
            this.dtpNextVisitDate.TabIndex = 4;
            // 
            // txtReferralOrg
            // 
            this.txtReferralOrg.Location = new System.Drawing.Point(635, 14);
            this.txtReferralOrg.MaxLength = 20;
            this.txtReferralOrg.Name = "txtReferralOrg";
            this.txtReferralOrg.Size = new System.Drawing.Size(141, 30);
            this.txtReferralOrg.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 15F);
            this.label18.Location = new System.Drawing.Point(487, 54);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(139, 20);
            this.label18.TabIndex = 43;
            this.label18.Text = "下次随访日期:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(508, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "机构及科别";
            // 
            // txtReferralReason
            // 
            this.txtReferralReason.Location = new System.Drawing.Point(156, 15);
            this.txtReferralReason.MaxLength = 20;
            this.txtReferralReason.Name = "txtReferralReason";
            this.txtReferralReason.Size = new System.Drawing.Size(144, 30);
            this.txtReferralReason.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(58, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "转诊原因";
            // 
            // GBoxStopCure
            // 
            this.GBoxStopCure.Controls.Add(this.panel2);
            this.GBoxStopCure.Controls.Add(this.label22);
            this.GBoxStopCure.Controls.Add(this.label21);
            this.GBoxStopCure.Controls.Add(this.dtpStopCureDate);
            this.GBoxStopCure.Font = new System.Drawing.Font("宋体", 15F);
            this.GBoxStopCure.Location = new System.Drawing.Point(70, 499);
            this.GBoxStopCure.Name = "GBoxStopCure";
            this.GBoxStopCure.Size = new System.Drawing.Size(1399, 63);
            this.GBoxStopCure.TabIndex = 6;
            this.GBoxStopCure.TabStop = false;
            this.GBoxStopCure.Text = "停止治疗";
            this.GBoxStopCure.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chbStopCureReason4);
            this.panel2.Controls.Add(this.chbStopCureReason3);
            this.panel2.Controls.Add(this.chbStopCureReason2);
            this.panel2.Controls.Add(this.chbStopCureReason1);
            this.panel2.Location = new System.Drawing.Point(153, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 35);
            this.panel2.TabIndex = 0;
            // 
            // chbStopCureReason4
            // 
            this.chbStopCureReason4.AutoSize = true;
            this.chbStopCureReason4.Font = new System.Drawing.Font("宋体", 15F);
            this.chbStopCureReason4.Location = new System.Drawing.Point(297, 9);
            this.chbStopCureReason4.Name = "chbStopCureReason4";
            this.chbStopCureReason4.Size = new System.Drawing.Size(168, 24);
            this.chbStopCureReason4.TabIndex = 3;
            this.chbStopCureReason4.Text = "转入耐多药治疗";
            this.chbStopCureReason4.UseVisualStyleBackColor = true;
            // 
            // chbStopCureReason3
            // 
            this.chbStopCureReason3.AutoSize = true;
            this.chbStopCureReason3.Font = new System.Drawing.Font("宋体", 15F);
            this.chbStopCureReason3.Location = new System.Drawing.Point(210, 10);
            this.chbStopCureReason3.Name = "chbStopCureReason3";
            this.chbStopCureReason3.Size = new System.Drawing.Size(68, 24);
            this.chbStopCureReason3.TabIndex = 2;
            this.chbStopCureReason3.Text = "丢失";
            this.chbStopCureReason3.UseVisualStyleBackColor = true;
            // 
            // chbStopCureReason2
            // 
            this.chbStopCureReason2.AutoSize = true;
            this.chbStopCureReason2.Font = new System.Drawing.Font("宋体", 15F);
            this.chbStopCureReason2.Location = new System.Drawing.Point(125, 10);
            this.chbStopCureReason2.Name = "chbStopCureReason2";
            this.chbStopCureReason2.Size = new System.Drawing.Size(68, 24);
            this.chbStopCureReason2.TabIndex = 1;
            this.chbStopCureReason2.Text = "死亡";
            this.chbStopCureReason2.UseVisualStyleBackColor = true;
            // 
            // chbStopCureReason1
            // 
            this.chbStopCureReason1.AutoSize = true;
            this.chbStopCureReason1.Font = new System.Drawing.Font("宋体", 15F);
            this.chbStopCureReason1.Location = new System.Drawing.Point(6, 10);
            this.chbStopCureReason1.Name = "chbStopCureReason1";
            this.chbStopCureReason1.Size = new System.Drawing.Size(108, 24);
            this.chbStopCureReason1.TabIndex = 0;
            this.chbStopCureReason1.Text = "完成疗程";
            this.chbStopCureReason1.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(903, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(139, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "停止治疗时间:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(139, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "停止治疗原因:";
            // 
            // dtpStopCureDate
            // 
            this.dtpStopCureDate.Font = new System.Drawing.Font("宋体", 15F);
            this.dtpStopCureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStopCureDate.Location = new System.Drawing.Point(1053, 24);
            this.dtpStopCureDate.Name = "dtpStopCureDate";
            this.dtpStopCureDate.Size = new System.Drawing.Size(162, 30);
            this.dtpStopCureDate.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnNoDrink);
            this.groupBox6.Controls.Add(this.btnNoSmoke);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.txtNextDayDrinkVolume);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.txtNextSmokeDayNum);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.txtDayDrinkVolume);
            this.groupBox6.Controls.Add(this.txtSmokeDayNum);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox6.Location = new System.Drawing.Point(70, 177);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1400, 58);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "生活方式评估";
            // 
            // btnNoDrink
            // 
            this.btnNoDrink.Location = new System.Drawing.Point(1130, 24);
            this.btnNoDrink.Name = "btnNoDrink";
            this.btnNoDrink.Size = new System.Drawing.Size(58, 30);
            this.btnNoDrink.TabIndex = 5;
            this.btnNoDrink.Text = "戒酒";
            this.btnNoDrink.UseVisualStyleBackColor = true;
            this.btnNoDrink.Click += new System.EventHandler(this.btnNoDrink_Click);
            // 
            // btnNoSmoke
            // 
            this.btnNoSmoke.Location = new System.Drawing.Point(518, 23);
            this.btnNoSmoke.Name = "btnNoSmoke";
            this.btnNoSmoke.Size = new System.Drawing.Size(57, 31);
            this.btnNoSmoke.TabIndex = 2;
            this.btnNoSmoke.Text = "戒烟";
            this.btnNoSmoke.UseVisualStyleBackColor = true;
            this.btnNoSmoke.Click += new System.EventHandler(this.btnNoSmoke_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 15F);
            this.label32.Location = new System.Drawing.Point(1092, 27);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 20);
            this.label32.TabIndex = 61;
            this.label32.Text = "两";
            // 
            // txtNextDayDrinkVolume
            // 
            this.txtNextDayDrinkVolume.Font = new System.Drawing.Font("宋体", 15F);
            this.txtNextDayDrinkVolume.Location = new System.Drawing.Point(1032, 24);
            this.txtNextDayDrinkVolume.MaxLength = 20;
            this.txtNextDayDrinkVolume.Name = "txtNextDayDrinkVolume";
            this.txtNextDayDrinkVolume.Size = new System.Drawing.Size(52, 30);
            this.txtNextDayDrinkVolume.TabIndex = 4;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(895, 28);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(129, 20);
            this.label31.TabIndex = 59;
            this.label31.Text = "下次随访目标";
            // 
            // txtNextSmokeDayNum
            // 
            this.txtNextSmokeDayNum.Location = new System.Drawing.Point(410, 24);
            this.txtNextSmokeDayNum.Name = "txtNextSmokeDayNum";
            this.txtNextSmokeDayNum.Size = new System.Drawing.Size(59, 30);
            this.txtNextSmokeDayNum.TabIndex = 1;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(275, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(129, 20);
            this.label29.TabIndex = 57;
            this.label29.Text = "下次随访目标";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F);
            this.label14.Location = new System.Drawing.Point(823, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "两";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 15F);
            this.label30.Location = new System.Drawing.Point(479, 27);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 20);
            this.label30.TabIndex = 55;
            this.label30.Text = "支";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F);
            this.label13.Location = new System.Drawing.Point(223, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 20);
            this.label13.TabIndex = 55;
            this.label13.Text = "支";
            // 
            // txtDayDrinkVolume
            // 
            this.txtDayDrinkVolume.Font = new System.Drawing.Font("宋体", 15F);
            this.txtDayDrinkVolume.Location = new System.Drawing.Point(751, 24);
            this.txtDayDrinkVolume.MaxLength = 20;
            this.txtDayDrinkVolume.Name = "txtDayDrinkVolume";
            this.txtDayDrinkVolume.Size = new System.Drawing.Size(64, 30);
            this.txtDayDrinkVolume.TabIndex = 3;
            // 
            // txtSmokeDayNum
            // 
            this.txtSmokeDayNum.Font = new System.Drawing.Font("宋体", 15F);
            this.txtSmokeDayNum.Location = new System.Drawing.Point(157, 24);
            this.txtSmokeDayNum.MaxLength = 20;
            this.txtSmokeDayNum.Name = "txtSmokeDayNum";
            this.txtSmokeDayNum.Size = new System.Drawing.Size(59, 30);
            this.txtSmokeDayNum.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F);
            this.label11.Location = new System.Drawing.Point(646, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "日饮酒量:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F);
            this.label12.Location = new System.Drawing.Point(53, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "日吸烟量:";
            // 
            // PTBVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.GBoxStopCure);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.GBoxManager);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PTBVisitForm";
            this.Text = "PTBVisitForm";
            this.Load += new System.EventHandler(this.PTBVisitForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.GBoxManager.ResumeLayout(false);
            this.GBoxManager.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.GBoxStopCure.ResumeLayout(false);
            this.GBoxStopCure.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDoctor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpFollowupDate;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radMZ;
        private System.Windows.Forms.RadioButton radFamily;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox ckGroup9;
        private System.Windows.Forms.CheckBox ckGroup8;
        private System.Windows.Forms.CheckBox ckGroup7;
        private System.Windows.Forms.CheckBox ckGroup6;
        private System.Windows.Forms.CheckBox ckGroup5;
        private System.Windows.Forms.CheckBox ckGroup4;
        private System.Windows.Forms.CheckBox ckGroup3;
        private System.Windows.Forms.CheckBox ckGroup2;
        private System.Windows.Forms.CheckBox ckGroup1;
        private System.Windows.Forms.CheckBox ckGroup0;
        private System.Windows.Forms.TextBox tbZzOther;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox chkDrugType4;
        private System.Windows.Forms.CheckBox chkDrugType3;
        private System.Windows.Forms.CheckBox chkDrugType2;
        private System.Windows.Forms.CheckBox chkDrugType1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rdoMedicationCompliance1;
        private System.Windows.Forms.RadioButton rdoMedicationCompliance2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChemotherapyScheme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.RadioButton rdoComplication2;
        private System.Windows.Forms.RadioButton rdoComplication1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton rdoAdr1;
        private System.Windows.Forms.RadioButton rdoAdr2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox GBoxManager;
        private System.Windows.Forms.TextBox txtEstimateDoctor;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtCureMonth;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RadioButton radPhone;
        private System.Windows.Forms.TextBox txtOmissiveTimes;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtAdrEx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtComplicationEx;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtHandleView;
        private System.Windows.Forms.TextBox txtReferralResult;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpNextVisitDate;
        private System.Windows.Forms.TextBox txtReferralOrg;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtReferralReason;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox GBoxStopCure;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbStopCureReason4;
        private System.Windows.Forms.CheckBox chbStopCureReason3;
        private System.Windows.Forms.CheckBox chbStopCureReason2;
        private System.Windows.Forms.CheckBox chbStopCureReason1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtPharmacyTimes;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtShouldPharmacyTimes;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtVisitTimes;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtShouldVisitTimes;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpStopCureDate;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton rdoSupervisor4;
        private System.Windows.Forms.RadioButton rdoSupervisor1;
        private System.Windows.Forms.RadioButton rdoSupervisor3;
        private System.Windows.Forms.RadioButton rdoSupervisor2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtPharmacyRate;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtNextDayDrinkVolume;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtNextSmokeDayNum;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDayDrinkVolume;
        private System.Windows.Forms.TextBox txtSmokeDayNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnNoSmoke;
        private System.Windows.Forms.Button btnNoDrink;

    }
}