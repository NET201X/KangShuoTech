using System;
using System.ComponentModel;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.OldPeople
{
    public class OldPeopleMedForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private IContainer components;
        private int CurX;
        private int CurY;
        private int max_loc;
        private bool Mousedown;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel23;
        private Panel panel24;
        private Panel panel25;
        private Panel panel26;
        private Panel panel27;
        private Panel panel28;
        private Panel panel29;
        private Panel panel3;
        private Panel panel30;
        private Panel panel31;
        private Panel panel32;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private RadioButton radioButton1;
        private RadioButton radioButton10;
        private RadioButton radioButton100;
        private RadioButton radioButton101;
        private RadioButton radioButton102;
        private RadioButton radioButton103;
        private RadioButton radioButton104;
        private RadioButton radioButton105;
        private RadioButton radioButton106;
        private RadioButton radioButton107;
        private RadioButton radioButton108;
        private RadioButton radioButton109;
        private RadioButton radioButton11;
        private RadioButton radioButton110;
        private RadioButton radioButton111;
        private RadioButton radioButton112;
        private RadioButton radioButton113;
        private RadioButton radioButton114;
        private RadioButton radioButton115;
        private RadioButton radioButton116;
        private RadioButton radioButton117;
        private RadioButton radioButton118;
        private RadioButton radioButton119;
        private RadioButton radioButton12;
        private RadioButton radioButton120;
        private RadioButton radioButton121;
        private RadioButton radioButton122;
        private RadioButton radioButton123;
        private RadioButton radioButton124;
        private RadioButton radioButton125;
        private RadioButton radioButton126;
        private RadioButton radioButton127;
        private RadioButton radioButton128;
        private RadioButton radioButton129;
        private RadioButton radioButton13;
        private RadioButton radioButton130;
        private RadioButton radioButton131;
        private RadioButton radioButton132;
        private RadioButton radioButton133;
        private RadioButton radioButton134;
        private RadioButton radioButton135;
        private RadioButton radioButton136;
        private RadioButton radioButton137;
        private RadioButton radioButton138;
        private RadioButton radioButton139;
        private RadioButton radioButton14;
        private RadioButton radioButton140;
        private RadioButton radioButton141;
        private RadioButton radioButton142;
        private RadioButton radioButton143;
        private RadioButton radioButton144;
        private RadioButton radioButton145;
        private RadioButton radioButton146;
        private RadioButton radioButton147;
        private RadioButton radioButton148;
        private RadioButton radioButton149;
        private RadioButton radioButton15;
        private RadioButton radioButton150;
        private RadioButton radioButton151;
        private RadioButton radioButton152;
        private RadioButton radioButton153;
        private RadioButton radioButton154;
        private RadioButton radioButton155;
        private RadioButton radioButton16;
        private RadioButton radioButton17;
        private RadioButton radioButton18;
        private RadioButton radioButton19;
        private RadioButton radioButton2;
        private RadioButton radioButton20;
        private RadioButton radioButton21;
        private RadioButton radioButton22;
        private RadioButton radioButton23;
        private RadioButton radioButton24;
        private RadioButton radioButton25;
        private RadioButton radioButton26;
        private RadioButton radioButton27;
        private RadioButton radioButton28;
        private RadioButton radioButton29;
        private RadioButton radioButton3;
        private RadioButton radioButton30;
        private RadioButton radioButton31;
        private RadioButton radioButton32;
        private RadioButton radioButton33;
        private RadioButton radioButton34;
        private RadioButton radioButton35;
        private RadioButton radioButton36;
        private RadioButton radioButton37;
        private RadioButton radioButton38;
        private RadioButton radioButton39;
        private RadioButton radioButton4;
        private RadioButton radioButton40;
        private RadioButton radioButton41;
        private RadioButton radioButton42;
        private RadioButton radioButton43;
        private RadioButton radioButton44;
        private RadioButton radioButton45;
        private RadioButton radioButton46;
        private RadioButton radioButton47;
        private RadioButton radioButton48;
        private RadioButton radioButton49;
        private RadioButton radioButton5;
        private RadioButton radioButton50;
        private RadioButton radioButton51;
        private RadioButton radioButton52;
        private RadioButton radioButton53;
        private RadioButton radioButton54;
        private RadioButton radioButton55;
        private RadioButton radioButton56;
        private RadioButton radioButton57;
        private RadioButton radioButton58;
        private RadioButton radioButton59;
        private RadioButton radioButton6;
        private RadioButton radioButton60;
        private RadioButton radioButton61;
        private RadioButton radioButton62;
        private RadioButton radioButton63;
        private RadioButton radioButton64;
        private RadioButton radioButton65;
        private RadioButton radioButton66;
        private RadioButton radioButton67;
        private RadioButton radioButton68;
        private RadioButton radioButton69;
        private RadioButton radioButton7;
        private RadioButton radioButton70;
        private RadioButton radioButton71;
        private RadioButton radioButton72;
        private RadioButton radioButton73;
        private RadioButton radioButton74;
        private RadioButton radioButton75;
        private RadioButton radioButton76;
        private RadioButton radioButton77;
        private RadioButton radioButton78;
        private RadioButton radioButton79;
        private RadioButton radioButton8;
        private RadioButton radioButton80;
        private RadioButton radioButton81;
        private RadioButton radioButton82;
        private RadioButton radioButton83;
        private RadioButton radioButton84;
        private RadioButton radioButton85;
        private RadioButton radioButton86;
        private RadioButton radioButton87;
        private RadioButton radioButton88;
        private RadioButton radioButton89;
        private RadioButton radioButton9;
        private RadioButton radioButton90;
        private RadioButton radioButton91;
        private RadioButton radioButton92;
        private RadioButton radioButton93;
        private RadioButton radioButton94;
        private RadioButton radioButton95;
        private RadioButton radioButton96;
        private RadioButton radioButton97;
        private RadioButton radioButton98;
        private RadioButton radioButton99;

        public OldPeopleMedForm()
        {
            this.InitializeComponent();
            this.max_loc = this.panel1.Location.Y;
            base.VerticalScroll.SmallChange = 1;
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitEveryThing()
        {
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.radioButton141 = new System.Windows.Forms.RadioButton();
            this.radioButton142 = new System.Windows.Forms.RadioButton();
            this.radioButton143 = new System.Windows.Forms.RadioButton();
            this.radioButton144 = new System.Windows.Forms.RadioButton();
            this.radioButton145 = new System.Windows.Forms.RadioButton();
            this.panel31 = new System.Windows.Forms.Panel();
            this.radioButton146 = new System.Windows.Forms.RadioButton();
            this.radioButton147 = new System.Windows.Forms.RadioButton();
            this.radioButton148 = new System.Windows.Forms.RadioButton();
            this.radioButton149 = new System.Windows.Forms.RadioButton();
            this.radioButton150 = new System.Windows.Forms.RadioButton();
            this.panel32 = new System.Windows.Forms.Panel();
            this.radioButton151 = new System.Windows.Forms.RadioButton();
            this.radioButton152 = new System.Windows.Forms.RadioButton();
            this.radioButton153 = new System.Windows.Forms.RadioButton();
            this.radioButton154 = new System.Windows.Forms.RadioButton();
            this.radioButton155 = new System.Windows.Forms.RadioButton();
            this.panel29 = new System.Windows.Forms.Panel();
            this.radioButton136 = new System.Windows.Forms.RadioButton();
            this.radioButton137 = new System.Windows.Forms.RadioButton();
            this.radioButton138 = new System.Windows.Forms.RadioButton();
            this.radioButton139 = new System.Windows.Forms.RadioButton();
            this.radioButton140 = new System.Windows.Forms.RadioButton();
            this.panel26 = new System.Windows.Forms.Panel();
            this.radioButton121 = new System.Windows.Forms.RadioButton();
            this.radioButton122 = new System.Windows.Forms.RadioButton();
            this.radioButton123 = new System.Windows.Forms.RadioButton();
            this.radioButton124 = new System.Windows.Forms.RadioButton();
            this.radioButton125 = new System.Windows.Forms.RadioButton();
            this.panel27 = new System.Windows.Forms.Panel();
            this.radioButton126 = new System.Windows.Forms.RadioButton();
            this.radioButton127 = new System.Windows.Forms.RadioButton();
            this.radioButton128 = new System.Windows.Forms.RadioButton();
            this.radioButton129 = new System.Windows.Forms.RadioButton();
            this.radioButton130 = new System.Windows.Forms.RadioButton();
            this.panel28 = new System.Windows.Forms.Panel();
            this.radioButton131 = new System.Windows.Forms.RadioButton();
            this.radioButton132 = new System.Windows.Forms.RadioButton();
            this.radioButton133 = new System.Windows.Forms.RadioButton();
            this.radioButton134 = new System.Windows.Forms.RadioButton();
            this.radioButton135 = new System.Windows.Forms.RadioButton();
            this.panel19 = new System.Windows.Forms.Panel();
            this.radioButton86 = new System.Windows.Forms.RadioButton();
            this.radioButton87 = new System.Windows.Forms.RadioButton();
            this.radioButton88 = new System.Windows.Forms.RadioButton();
            this.radioButton89 = new System.Windows.Forms.RadioButton();
            this.radioButton90 = new System.Windows.Forms.RadioButton();
            this.panel20 = new System.Windows.Forms.Panel();
            this.radioButton91 = new System.Windows.Forms.RadioButton();
            this.radioButton92 = new System.Windows.Forms.RadioButton();
            this.radioButton93 = new System.Windows.Forms.RadioButton();
            this.radioButton94 = new System.Windows.Forms.RadioButton();
            this.radioButton95 = new System.Windows.Forms.RadioButton();
            this.panel21 = new System.Windows.Forms.Panel();
            this.radioButton96 = new System.Windows.Forms.RadioButton();
            this.radioButton97 = new System.Windows.Forms.RadioButton();
            this.radioButton98 = new System.Windows.Forms.RadioButton();
            this.radioButton99 = new System.Windows.Forms.RadioButton();
            this.radioButton100 = new System.Windows.Forms.RadioButton();
            this.panel22 = new System.Windows.Forms.Panel();
            this.radioButton101 = new System.Windows.Forms.RadioButton();
            this.radioButton102 = new System.Windows.Forms.RadioButton();
            this.radioButton103 = new System.Windows.Forms.RadioButton();
            this.radioButton104 = new System.Windows.Forms.RadioButton();
            this.radioButton105 = new System.Windows.Forms.RadioButton();
            this.panel23 = new System.Windows.Forms.Panel();
            this.radioButton106 = new System.Windows.Forms.RadioButton();
            this.radioButton107 = new System.Windows.Forms.RadioButton();
            this.radioButton108 = new System.Windows.Forms.RadioButton();
            this.radioButton109 = new System.Windows.Forms.RadioButton();
            this.radioButton110 = new System.Windows.Forms.RadioButton();
            this.panel24 = new System.Windows.Forms.Panel();
            this.radioButton111 = new System.Windows.Forms.RadioButton();
            this.radioButton112 = new System.Windows.Forms.RadioButton();
            this.radioButton113 = new System.Windows.Forms.RadioButton();
            this.radioButton114 = new System.Windows.Forms.RadioButton();
            this.radioButton115 = new System.Windows.Forms.RadioButton();
            this.panel25 = new System.Windows.Forms.Panel();
            this.radioButton116 = new System.Windows.Forms.RadioButton();
            this.radioButton117 = new System.Windows.Forms.RadioButton();
            this.radioButton118 = new System.Windows.Forms.RadioButton();
            this.radioButton119 = new System.Windows.Forms.RadioButton();
            this.radioButton120 = new System.Windows.Forms.RadioButton();
            this.panel18 = new System.Windows.Forms.Panel();
            this.radioButton81 = new System.Windows.Forms.RadioButton();
            this.radioButton82 = new System.Windows.Forms.RadioButton();
            this.radioButton83 = new System.Windows.Forms.RadioButton();
            this.radioButton84 = new System.Windows.Forms.RadioButton();
            this.radioButton85 = new System.Windows.Forms.RadioButton();
            this.panel16 = new System.Windows.Forms.Panel();
            this.radioButton71 = new System.Windows.Forms.RadioButton();
            this.radioButton72 = new System.Windows.Forms.RadioButton();
            this.radioButton73 = new System.Windows.Forms.RadioButton();
            this.radioButton74 = new System.Windows.Forms.RadioButton();
            this.radioButton75 = new System.Windows.Forms.RadioButton();
            this.panel15 = new System.Windows.Forms.Panel();
            this.radioButton66 = new System.Windows.Forms.RadioButton();
            this.radioButton67 = new System.Windows.Forms.RadioButton();
            this.radioButton68 = new System.Windows.Forms.RadioButton();
            this.radioButton69 = new System.Windows.Forms.RadioButton();
            this.radioButton70 = new System.Windows.Forms.RadioButton();
            this.panel17 = new System.Windows.Forms.Panel();
            this.radioButton76 = new System.Windows.Forms.RadioButton();
            this.radioButton77 = new System.Windows.Forms.RadioButton();
            this.radioButton78 = new System.Windows.Forms.RadioButton();
            this.radioButton79 = new System.Windows.Forms.RadioButton();
            this.radioButton80 = new System.Windows.Forms.RadioButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.radioButton46 = new System.Windows.Forms.RadioButton();
            this.radioButton47 = new System.Windows.Forms.RadioButton();
            this.radioButton48 = new System.Windows.Forms.RadioButton();
            this.radioButton49 = new System.Windows.Forms.RadioButton();
            this.radioButton50 = new System.Windows.Forms.RadioButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.radioButton41 = new System.Windows.Forms.RadioButton();
            this.radioButton42 = new System.Windows.Forms.RadioButton();
            this.radioButton43 = new System.Windows.Forms.RadioButton();
            this.radioButton44 = new System.Windows.Forms.RadioButton();
            this.radioButton45 = new System.Windows.Forms.RadioButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.radioButton51 = new System.Windows.Forms.RadioButton();
            this.radioButton52 = new System.Windows.Forms.RadioButton();
            this.radioButton53 = new System.Windows.Forms.RadioButton();
            this.radioButton54 = new System.Windows.Forms.RadioButton();
            this.radioButton55 = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioButton21 = new System.Windows.Forms.RadioButton();
            this.radioButton22 = new System.Windows.Forms.RadioButton();
            this.radioButton23 = new System.Windows.Forms.RadioButton();
            this.radioButton24 = new System.Windows.Forms.RadioButton();
            this.radioButton25 = new System.Windows.Forms.RadioButton();
            this.panel13 = new System.Windows.Forms.Panel();
            this.radioButton56 = new System.Windows.Forms.RadioButton();
            this.radioButton57 = new System.Windows.Forms.RadioButton();
            this.radioButton58 = new System.Windows.Forms.RadioButton();
            this.radioButton59 = new System.Windows.Forms.RadioButton();
            this.radioButton60 = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.panel14 = new System.Windows.Forms.Panel();
            this.radioButton61 = new System.Windows.Forms.RadioButton();
            this.radioButton62 = new System.Windows.Forms.RadioButton();
            this.radioButton63 = new System.Windows.Forms.RadioButton();
            this.radioButton64 = new System.Windows.Forms.RadioButton();
            this.radioButton65 = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radioButton26 = new System.Windows.Forms.RadioButton();
            this.radioButton27 = new System.Windows.Forms.RadioButton();
            this.radioButton28 = new System.Windows.Forms.RadioButton();
            this.radioButton29 = new System.Windows.Forms.RadioButton();
            this.radioButton30 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.radioButton31 = new System.Windows.Forms.RadioButton();
            this.radioButton32 = new System.Windows.Forms.RadioButton();
            this.radioButton33 = new System.Windows.Forms.RadioButton();
            this.radioButton34 = new System.Windows.Forms.RadioButton();
            this.radioButton35 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.radioButton36 = new System.Windows.Forms.RadioButton();
            this.radioButton37 = new System.Windows.Forms.RadioButton();
            this.radioButton38 = new System.Windows.Forms.RadioButton();
            this.radioButton39 = new System.Windows.Forms.RadioButton();
            this.radioButton40 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::FocusGroup.Properties.Resources.old_med;
            this.panel1.Controls.Add(this.panel30);
            this.panel1.Controls.Add(this.panel31);
            this.panel1.Controls.Add(this.panel32);
            this.panel1.Controls.Add(this.panel29);
            this.panel1.Controls.Add(this.panel26);
            this.panel1.Controls.Add(this.panel27);
            this.panel1.Controls.Add(this.panel28);
            this.panel1.Controls.Add(this.panel19);
            this.panel1.Controls.Add(this.panel20);
            this.panel1.Controls.Add(this.panel21);
            this.panel1.Controls.Add(this.panel22);
            this.panel1.Controls.Add(this.panel23);
            this.panel1.Controls.Add(this.panel24);
            this.panel1.Controls.Add(this.panel25);
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.panel16);
            this.panel1.Controls.Add(this.panel15);
            this.panel1.Controls.Add(this.panel17);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel14);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(142, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 1688);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.Transparent;
            this.panel30.Controls.Add(this.radioButton141);
            this.panel30.Controls.Add(this.radioButton142);
            this.panel30.Controls.Add(this.radioButton143);
            this.panel30.Controls.Add(this.radioButton144);
            this.panel30.Controls.Add(this.radioButton145);
            this.panel30.Location = new System.Drawing.Point(476, 1244);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(484, 28);
            this.panel30.TabIndex = 30;
            // 
            // radioButton141
            // 
            this.radioButton141.AutoSize = true;
            this.radioButton141.Location = new System.Drawing.Point(422, 7);
            this.radioButton141.Name = "radioButton141";
            this.radioButton141.Size = new System.Drawing.Size(39, 18);
            this.radioButton141.TabIndex = 4;
            this.radioButton141.TabStop = true;
            this.radioButton141.Text = "  ";
            this.radioButton141.UseVisualStyleBackColor = true;
            // 
            // radioButton142
            // 
            this.radioButton142.AutoSize = true;
            this.radioButton142.Location = new System.Drawing.Point(323, 5);
            this.radioButton142.Name = "radioButton142";
            this.radioButton142.Size = new System.Drawing.Size(39, 18);
            this.radioButton142.TabIndex = 3;
            this.radioButton142.TabStop = true;
            this.radioButton142.Text = "  ";
            this.radioButton142.UseVisualStyleBackColor = true;
            // 
            // radioButton143
            // 
            this.radioButton143.AutoSize = true;
            this.radioButton143.Location = new System.Drawing.Point(223, 5);
            this.radioButton143.Name = "radioButton143";
            this.radioButton143.Size = new System.Drawing.Size(39, 18);
            this.radioButton143.TabIndex = 2;
            this.radioButton143.TabStop = true;
            this.radioButton143.Text = "  ";
            this.radioButton143.UseVisualStyleBackColor = true;
            // 
            // radioButton144
            // 
            this.radioButton144.AutoSize = true;
            this.radioButton144.Location = new System.Drawing.Point(16, 5);
            this.radioButton144.Name = "radioButton144";
            this.radioButton144.Size = new System.Drawing.Size(46, 18);
            this.radioButton144.TabIndex = 0;
            this.radioButton144.TabStop = true;
            this.radioButton144.Text = "   ";
            this.radioButton144.UseVisualStyleBackColor = true;
            // 
            // radioButton145
            // 
            this.radioButton145.AutoSize = true;
            this.radioButton145.Location = new System.Drawing.Point(118, 5);
            this.radioButton145.Name = "radioButton145";
            this.radioButton145.Size = new System.Drawing.Size(39, 18);
            this.radioButton145.TabIndex = 1;
            this.radioButton145.TabStop = true;
            this.radioButton145.Text = "  ";
            this.radioButton145.UseVisualStyleBackColor = true;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.Transparent;
            this.panel31.Controls.Add(this.radioButton146);
            this.panel31.Controls.Add(this.radioButton147);
            this.panel31.Controls.Add(this.radioButton148);
            this.panel31.Controls.Add(this.radioButton149);
            this.panel31.Controls.Add(this.radioButton150);
            this.panel31.Location = new System.Drawing.Point(476, 1213);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(484, 28);
            this.panel31.TabIndex = 29;
            // 
            // radioButton146
            // 
            this.radioButton146.AutoSize = true;
            this.radioButton146.Location = new System.Drawing.Point(422, 4);
            this.radioButton146.Name = "radioButton146";
            this.radioButton146.Size = new System.Drawing.Size(39, 18);
            this.radioButton146.TabIndex = 4;
            this.radioButton146.TabStop = true;
            this.radioButton146.Text = "  ";
            this.radioButton146.UseVisualStyleBackColor = true;
            // 
            // radioButton147
            // 
            this.radioButton147.AutoSize = true;
            this.radioButton147.Location = new System.Drawing.Point(323, 5);
            this.radioButton147.Name = "radioButton147";
            this.radioButton147.Size = new System.Drawing.Size(39, 18);
            this.radioButton147.TabIndex = 3;
            this.radioButton147.TabStop = true;
            this.radioButton147.Text = "  ";
            this.radioButton147.UseVisualStyleBackColor = true;
            // 
            // radioButton148
            // 
            this.radioButton148.AutoSize = true;
            this.radioButton148.Location = new System.Drawing.Point(223, 5);
            this.radioButton148.Name = "radioButton148";
            this.radioButton148.Size = new System.Drawing.Size(39, 18);
            this.radioButton148.TabIndex = 2;
            this.radioButton148.TabStop = true;
            this.radioButton148.Text = "  ";
            this.radioButton148.UseVisualStyleBackColor = true;
            // 
            // radioButton149
            // 
            this.radioButton149.AutoSize = true;
            this.radioButton149.Location = new System.Drawing.Point(16, 5);
            this.radioButton149.Name = "radioButton149";
            this.radioButton149.Size = new System.Drawing.Size(46, 18);
            this.radioButton149.TabIndex = 0;
            this.radioButton149.TabStop = true;
            this.radioButton149.Text = "   ";
            this.radioButton149.UseVisualStyleBackColor = true;
            // 
            // radioButton150
            // 
            this.radioButton150.AutoSize = true;
            this.radioButton150.Location = new System.Drawing.Point(118, 5);
            this.radioButton150.Name = "radioButton150";
            this.radioButton150.Size = new System.Drawing.Size(39, 18);
            this.radioButton150.TabIndex = 1;
            this.radioButton150.TabStop = true;
            this.radioButton150.Text = "  ";
            this.radioButton150.UseVisualStyleBackColor = true;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.Transparent;
            this.panel32.Controls.Add(this.radioButton151);
            this.panel32.Controls.Add(this.radioButton152);
            this.panel32.Controls.Add(this.radioButton153);
            this.panel32.Controls.Add(this.radioButton154);
            this.panel32.Controls.Add(this.radioButton155);
            this.panel32.Location = new System.Drawing.Point(476, 1176);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(484, 28);
            this.panel32.TabIndex = 28;
            // 
            // radioButton151
            // 
            this.radioButton151.AutoSize = true;
            this.radioButton151.Location = new System.Drawing.Point(422, 4);
            this.radioButton151.Name = "radioButton151";
            this.radioButton151.Size = new System.Drawing.Size(39, 18);
            this.radioButton151.TabIndex = 4;
            this.radioButton151.TabStop = true;
            this.radioButton151.Text = "  ";
            this.radioButton151.UseVisualStyleBackColor = true;
            // 
            // radioButton152
            // 
            this.radioButton152.AutoSize = true;
            this.radioButton152.Location = new System.Drawing.Point(323, 5);
            this.radioButton152.Name = "radioButton152";
            this.radioButton152.Size = new System.Drawing.Size(39, 18);
            this.radioButton152.TabIndex = 3;
            this.radioButton152.TabStop = true;
            this.radioButton152.Text = "  ";
            this.radioButton152.UseVisualStyleBackColor = true;
            // 
            // radioButton153
            // 
            this.radioButton153.AutoSize = true;
            this.radioButton153.Location = new System.Drawing.Point(223, 5);
            this.radioButton153.Name = "radioButton153";
            this.radioButton153.Size = new System.Drawing.Size(39, 18);
            this.radioButton153.TabIndex = 2;
            this.radioButton153.TabStop = true;
            this.radioButton153.Text = "  ";
            this.radioButton153.UseVisualStyleBackColor = true;
            // 
            // radioButton154
            // 
            this.radioButton154.AutoSize = true;
            this.radioButton154.Location = new System.Drawing.Point(16, 5);
            this.radioButton154.Name = "radioButton154";
            this.radioButton154.Size = new System.Drawing.Size(46, 18);
            this.radioButton154.TabIndex = 0;
            this.radioButton154.TabStop = true;
            this.radioButton154.Text = "   ";
            this.radioButton154.UseVisualStyleBackColor = true;
            // 
            // radioButton155
            // 
            this.radioButton155.AutoSize = true;
            this.radioButton155.Location = new System.Drawing.Point(118, 5);
            this.radioButton155.Name = "radioButton155";
            this.radioButton155.Size = new System.Drawing.Size(39, 18);
            this.radioButton155.TabIndex = 1;
            this.radioButton155.TabStop = true;
            this.radioButton155.Text = "  ";
            this.radioButton155.UseVisualStyleBackColor = true;
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.Transparent;
            this.panel29.Controls.Add(this.radioButton136);
            this.panel29.Controls.Add(this.radioButton137);
            this.panel29.Controls.Add(this.radioButton138);
            this.panel29.Controls.Add(this.radioButton139);
            this.panel29.Controls.Add(this.radioButton140);
            this.panel29.Location = new System.Drawing.Point(476, 1093);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(484, 46);
            this.panel29.TabIndex = 27;
            // 
            // radioButton136
            // 
            this.radioButton136.AutoSize = true;
            this.radioButton136.Location = new System.Drawing.Point(422, 9);
            this.radioButton136.Name = "radioButton136";
            this.radioButton136.Size = new System.Drawing.Size(39, 18);
            this.radioButton136.TabIndex = 4;
            this.radioButton136.TabStop = true;
            this.radioButton136.Text = "  ";
            this.radioButton136.UseVisualStyleBackColor = true;
            // 
            // radioButton137
            // 
            this.radioButton137.AutoSize = true;
            this.radioButton137.Location = new System.Drawing.Point(323, 1);
            this.radioButton137.Name = "radioButton137";
            this.radioButton137.Size = new System.Drawing.Size(39, 18);
            this.radioButton137.TabIndex = 3;
            this.radioButton137.TabStop = true;
            this.radioButton137.Text = "  ";
            this.radioButton137.UseVisualStyleBackColor = true;
            // 
            // radioButton138
            // 
            this.radioButton138.AutoSize = true;
            this.radioButton138.Location = new System.Drawing.Point(223, 0);
            this.radioButton138.Name = "radioButton138";
            this.radioButton138.Size = new System.Drawing.Size(39, 18);
            this.radioButton138.TabIndex = 2;
            this.radioButton138.TabStop = true;
            this.radioButton138.Text = "  ";
            this.radioButton138.UseVisualStyleBackColor = true;
            // 
            // radioButton139
            // 
            this.radioButton139.AutoSize = true;
            this.radioButton139.Location = new System.Drawing.Point(16, 9);
            this.radioButton139.Name = "radioButton139";
            this.radioButton139.Size = new System.Drawing.Size(46, 18);
            this.radioButton139.TabIndex = 0;
            this.radioButton139.TabStop = true;
            this.radioButton139.Text = "   ";
            this.radioButton139.UseVisualStyleBackColor = true;
            // 
            // radioButton140
            // 
            this.radioButton140.AutoSize = true;
            this.radioButton140.Location = new System.Drawing.Point(118, 1);
            this.radioButton140.Name = "radioButton140";
            this.radioButton140.Size = new System.Drawing.Size(39, 18);
            this.radioButton140.TabIndex = 1;
            this.radioButton140.TabStop = true;
            this.radioButton140.Text = "  ";
            this.radioButton140.UseVisualStyleBackColor = true;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.Transparent;
            this.panel26.Controls.Add(this.radioButton121);
            this.panel26.Controls.Add(this.radioButton122);
            this.panel26.Controls.Add(this.radioButton123);
            this.panel26.Controls.Add(this.radioButton124);
            this.panel26.Controls.Add(this.radioButton125);
            this.panel26.Location = new System.Drawing.Point(476, 1062);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(484, 28);
            this.panel26.TabIndex = 26;
            // 
            // radioButton121
            // 
            this.radioButton121.AutoSize = true;
            this.radioButton121.Location = new System.Drawing.Point(422, 7);
            this.radioButton121.Name = "radioButton121";
            this.radioButton121.Size = new System.Drawing.Size(39, 18);
            this.radioButton121.TabIndex = 4;
            this.radioButton121.TabStop = true;
            this.radioButton121.Text = "  ";
            this.radioButton121.UseVisualStyleBackColor = true;
            // 
            // radioButton122
            // 
            this.radioButton122.AutoSize = true;
            this.radioButton122.Location = new System.Drawing.Point(323, 5);
            this.radioButton122.Name = "radioButton122";
            this.radioButton122.Size = new System.Drawing.Size(39, 18);
            this.radioButton122.TabIndex = 3;
            this.radioButton122.TabStop = true;
            this.radioButton122.Text = "  ";
            this.radioButton122.UseVisualStyleBackColor = true;
            // 
            // radioButton123
            // 
            this.radioButton123.AutoSize = true;
            this.radioButton123.Location = new System.Drawing.Point(223, 5);
            this.radioButton123.Name = "radioButton123";
            this.radioButton123.Size = new System.Drawing.Size(39, 18);
            this.radioButton123.TabIndex = 2;
            this.radioButton123.TabStop = true;
            this.radioButton123.Text = "  ";
            this.radioButton123.UseVisualStyleBackColor = true;
            // 
            // radioButton124
            // 
            this.radioButton124.AutoSize = true;
            this.radioButton124.Location = new System.Drawing.Point(16, 5);
            this.radioButton124.Name = "radioButton124";
            this.radioButton124.Size = new System.Drawing.Size(46, 18);
            this.radioButton124.TabIndex = 0;
            this.radioButton124.TabStop = true;
            this.radioButton124.Text = "   ";
            this.radioButton124.UseVisualStyleBackColor = true;
            // 
            // radioButton125
            // 
            this.radioButton125.AutoSize = true;
            this.radioButton125.Location = new System.Drawing.Point(118, 5);
            this.radioButton125.Name = "radioButton125";
            this.radioButton125.Size = new System.Drawing.Size(39, 18);
            this.radioButton125.TabIndex = 1;
            this.radioButton125.TabStop = true;
            this.radioButton125.Text = "  ";
            this.radioButton125.UseVisualStyleBackColor = true;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.Transparent;
            this.panel27.Controls.Add(this.radioButton126);
            this.panel27.Controls.Add(this.radioButton127);
            this.panel27.Controls.Add(this.radioButton128);
            this.panel27.Controls.Add(this.radioButton129);
            this.panel27.Controls.Add(this.radioButton130);
            this.panel27.Location = new System.Drawing.Point(476, 1031);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(484, 28);
            this.panel27.TabIndex = 25;
            // 
            // radioButton126
            // 
            this.radioButton126.AutoSize = true;
            this.radioButton126.Location = new System.Drawing.Point(422, 4);
            this.radioButton126.Name = "radioButton126";
            this.radioButton126.Size = new System.Drawing.Size(39, 18);
            this.radioButton126.TabIndex = 4;
            this.radioButton126.TabStop = true;
            this.radioButton126.Text = "  ";
            this.radioButton126.UseVisualStyleBackColor = true;
            // 
            // radioButton127
            // 
            this.radioButton127.AutoSize = true;
            this.radioButton127.Location = new System.Drawing.Point(323, 5);
            this.radioButton127.Name = "radioButton127";
            this.radioButton127.Size = new System.Drawing.Size(39, 18);
            this.radioButton127.TabIndex = 3;
            this.radioButton127.TabStop = true;
            this.radioButton127.Text = "  ";
            this.radioButton127.UseVisualStyleBackColor = true;
            // 
            // radioButton128
            // 
            this.radioButton128.AutoSize = true;
            this.radioButton128.Location = new System.Drawing.Point(223, 5);
            this.radioButton128.Name = "radioButton128";
            this.radioButton128.Size = new System.Drawing.Size(39, 18);
            this.radioButton128.TabIndex = 2;
            this.radioButton128.TabStop = true;
            this.radioButton128.Text = "  ";
            this.radioButton128.UseVisualStyleBackColor = true;
            // 
            // radioButton129
            // 
            this.radioButton129.AutoSize = true;
            this.radioButton129.Location = new System.Drawing.Point(16, 5);
            this.radioButton129.Name = "radioButton129";
            this.radioButton129.Size = new System.Drawing.Size(46, 18);
            this.radioButton129.TabIndex = 0;
            this.radioButton129.TabStop = true;
            this.radioButton129.Text = "   ";
            this.radioButton129.UseVisualStyleBackColor = true;
            // 
            // radioButton130
            // 
            this.radioButton130.AutoSize = true;
            this.radioButton130.Location = new System.Drawing.Point(118, 5);
            this.radioButton130.Name = "radioButton130";
            this.radioButton130.Size = new System.Drawing.Size(39, 18);
            this.radioButton130.TabIndex = 1;
            this.radioButton130.TabStop = true;
            this.radioButton130.Text = "  ";
            this.radioButton130.UseVisualStyleBackColor = true;
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.Transparent;
            this.panel28.Controls.Add(this.radioButton131);
            this.panel28.Controls.Add(this.radioButton132);
            this.panel28.Controls.Add(this.radioButton133);
            this.panel28.Controls.Add(this.radioButton134);
            this.panel28.Controls.Add(this.radioButton135);
            this.panel28.Location = new System.Drawing.Point(476, 1002);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(484, 28);
            this.panel28.TabIndex = 24;
            // 
            // radioButton131
            // 
            this.radioButton131.AutoSize = true;
            this.radioButton131.Location = new System.Drawing.Point(422, 4);
            this.radioButton131.Name = "radioButton131";
            this.radioButton131.Size = new System.Drawing.Size(39, 18);
            this.radioButton131.TabIndex = 4;
            this.radioButton131.TabStop = true;
            this.radioButton131.Text = "  ";
            this.radioButton131.UseVisualStyleBackColor = true;
            // 
            // radioButton132
            // 
            this.radioButton132.AutoSize = true;
            this.radioButton132.Location = new System.Drawing.Point(323, 5);
            this.radioButton132.Name = "radioButton132";
            this.radioButton132.Size = new System.Drawing.Size(39, 18);
            this.radioButton132.TabIndex = 3;
            this.radioButton132.TabStop = true;
            this.radioButton132.Text = "  ";
            this.radioButton132.UseVisualStyleBackColor = true;
            // 
            // radioButton133
            // 
            this.radioButton133.AutoSize = true;
            this.radioButton133.Location = new System.Drawing.Point(223, 5);
            this.radioButton133.Name = "radioButton133";
            this.radioButton133.Size = new System.Drawing.Size(39, 18);
            this.radioButton133.TabIndex = 2;
            this.radioButton133.TabStop = true;
            this.radioButton133.Text = "  ";
            this.radioButton133.UseVisualStyleBackColor = true;
            // 
            // radioButton134
            // 
            this.radioButton134.AutoSize = true;
            this.radioButton134.Location = new System.Drawing.Point(16, 5);
            this.radioButton134.Name = "radioButton134";
            this.radioButton134.Size = new System.Drawing.Size(46, 18);
            this.radioButton134.TabIndex = 0;
            this.radioButton134.TabStop = true;
            this.radioButton134.Text = "   ";
            this.radioButton134.UseVisualStyleBackColor = true;
            // 
            // radioButton135
            // 
            this.radioButton135.AutoSize = true;
            this.radioButton135.Location = new System.Drawing.Point(118, 5);
            this.radioButton135.Name = "radioButton135";
            this.radioButton135.Size = new System.Drawing.Size(39, 18);
            this.radioButton135.TabIndex = 1;
            this.radioButton135.TabStop = true;
            this.radioButton135.Text = "  ";
            this.radioButton135.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.Transparent;
            this.panel19.Controls.Add(this.radioButton86);
            this.panel19.Controls.Add(this.radioButton87);
            this.panel19.Controls.Add(this.radioButton88);
            this.panel19.Controls.Add(this.radioButton89);
            this.panel19.Controls.Add(this.radioButton90);
            this.panel19.Location = new System.Drawing.Point(476, 875);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(484, 28);
            this.panel19.TabIndex = 20;
            // 
            // radioButton86
            // 
            this.radioButton86.AutoSize = true;
            this.radioButton86.Location = new System.Drawing.Point(422, 4);
            this.radioButton86.Name = "radioButton86";
            this.radioButton86.Size = new System.Drawing.Size(39, 18);
            this.radioButton86.TabIndex = 4;
            this.radioButton86.TabStop = true;
            this.radioButton86.Text = "  ";
            this.radioButton86.UseVisualStyleBackColor = true;
            // 
            // radioButton87
            // 
            this.radioButton87.AutoSize = true;
            this.radioButton87.Location = new System.Drawing.Point(323, 5);
            this.radioButton87.Name = "radioButton87";
            this.radioButton87.Size = new System.Drawing.Size(39, 18);
            this.radioButton87.TabIndex = 3;
            this.radioButton87.TabStop = true;
            this.radioButton87.Text = "  ";
            this.radioButton87.UseVisualStyleBackColor = true;
            // 
            // radioButton88
            // 
            this.radioButton88.AutoSize = true;
            this.radioButton88.Location = new System.Drawing.Point(223, 5);
            this.radioButton88.Name = "radioButton88";
            this.radioButton88.Size = new System.Drawing.Size(39, 18);
            this.radioButton88.TabIndex = 2;
            this.radioButton88.TabStop = true;
            this.radioButton88.Text = "  ";
            this.radioButton88.UseVisualStyleBackColor = true;
            // 
            // radioButton89
            // 
            this.radioButton89.AutoSize = true;
            this.radioButton89.Location = new System.Drawing.Point(16, 5);
            this.radioButton89.Name = "radioButton89";
            this.radioButton89.Size = new System.Drawing.Size(46, 18);
            this.radioButton89.TabIndex = 0;
            this.radioButton89.TabStop = true;
            this.radioButton89.Text = "   ";
            this.radioButton89.UseVisualStyleBackColor = true;
            // 
            // radioButton90
            // 
            this.radioButton90.AutoSize = true;
            this.radioButton90.Location = new System.Drawing.Point(118, 5);
            this.radioButton90.Name = "radioButton90";
            this.radioButton90.Size = new System.Drawing.Size(39, 18);
            this.radioButton90.TabIndex = 1;
            this.radioButton90.TabStop = true;
            this.radioButton90.Text = "  ";
            this.radioButton90.UseVisualStyleBackColor = true;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.Transparent;
            this.panel20.Controls.Add(this.radioButton91);
            this.panel20.Controls.Add(this.radioButton92);
            this.panel20.Controls.Add(this.radioButton93);
            this.panel20.Controls.Add(this.radioButton94);
            this.panel20.Controls.Add(this.radioButton95);
            this.panel20.Location = new System.Drawing.Point(476, 967);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(484, 28);
            this.panel20.TabIndex = 23;
            // 
            // radioButton91
            // 
            this.radioButton91.AutoSize = true;
            this.radioButton91.Location = new System.Drawing.Point(422, 4);
            this.radioButton91.Name = "radioButton91";
            this.radioButton91.Size = new System.Drawing.Size(39, 18);
            this.radioButton91.TabIndex = 4;
            this.radioButton91.TabStop = true;
            this.radioButton91.Text = "  ";
            this.radioButton91.UseVisualStyleBackColor = true;
            // 
            // radioButton92
            // 
            this.radioButton92.AutoSize = true;
            this.radioButton92.Location = new System.Drawing.Point(323, 5);
            this.radioButton92.Name = "radioButton92";
            this.radioButton92.Size = new System.Drawing.Size(39, 18);
            this.radioButton92.TabIndex = 3;
            this.radioButton92.TabStop = true;
            this.radioButton92.Text = "  ";
            this.radioButton92.UseVisualStyleBackColor = true;
            // 
            // radioButton93
            // 
            this.radioButton93.AutoSize = true;
            this.radioButton93.Location = new System.Drawing.Point(223, 5);
            this.radioButton93.Name = "radioButton93";
            this.radioButton93.Size = new System.Drawing.Size(39, 18);
            this.radioButton93.TabIndex = 2;
            this.radioButton93.TabStop = true;
            this.radioButton93.Text = "  ";
            this.radioButton93.UseVisualStyleBackColor = true;
            // 
            // radioButton94
            // 
            this.radioButton94.AutoSize = true;
            this.radioButton94.Location = new System.Drawing.Point(16, 5);
            this.radioButton94.Name = "radioButton94";
            this.radioButton94.Size = new System.Drawing.Size(46, 18);
            this.radioButton94.TabIndex = 0;
            this.radioButton94.TabStop = true;
            this.radioButton94.Text = "   ";
            this.radioButton94.UseVisualStyleBackColor = true;
            // 
            // radioButton95
            // 
            this.radioButton95.AutoSize = true;
            this.radioButton95.Location = new System.Drawing.Point(118, 5);
            this.radioButton95.Name = "radioButton95";
            this.radioButton95.Size = new System.Drawing.Size(39, 18);
            this.radioButton95.TabIndex = 1;
            this.radioButton95.TabStop = true;
            this.radioButton95.Text = "  ";
            this.radioButton95.UseVisualStyleBackColor = true;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.Transparent;
            this.panel21.Controls.Add(this.radioButton96);
            this.panel21.Controls.Add(this.radioButton97);
            this.panel21.Controls.Add(this.radioButton98);
            this.panel21.Controls.Add(this.radioButton99);
            this.panel21.Controls.Add(this.radioButton100);
            this.panel21.Location = new System.Drawing.Point(476, 843);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(484, 28);
            this.panel21.TabIndex = 19;
            // 
            // radioButton96
            // 
            this.radioButton96.AutoSize = true;
            this.radioButton96.Location = new System.Drawing.Point(422, 4);
            this.radioButton96.Name = "radioButton96";
            this.radioButton96.Size = new System.Drawing.Size(39, 18);
            this.radioButton96.TabIndex = 4;
            this.radioButton96.TabStop = true;
            this.radioButton96.Text = "  ";
            this.radioButton96.UseVisualStyleBackColor = true;
            // 
            // radioButton97
            // 
            this.radioButton97.AutoSize = true;
            this.radioButton97.Location = new System.Drawing.Point(323, 5);
            this.radioButton97.Name = "radioButton97";
            this.radioButton97.Size = new System.Drawing.Size(39, 18);
            this.radioButton97.TabIndex = 3;
            this.radioButton97.TabStop = true;
            this.radioButton97.Text = "  ";
            this.radioButton97.UseVisualStyleBackColor = true;
            // 
            // radioButton98
            // 
            this.radioButton98.AutoSize = true;
            this.radioButton98.Location = new System.Drawing.Point(223, 5);
            this.radioButton98.Name = "radioButton98";
            this.radioButton98.Size = new System.Drawing.Size(39, 18);
            this.radioButton98.TabIndex = 2;
            this.radioButton98.TabStop = true;
            this.radioButton98.Text = "  ";
            this.radioButton98.UseVisualStyleBackColor = true;
            // 
            // radioButton99
            // 
            this.radioButton99.AutoSize = true;
            this.radioButton99.Location = new System.Drawing.Point(16, 5);
            this.radioButton99.Name = "radioButton99";
            this.radioButton99.Size = new System.Drawing.Size(46, 18);
            this.radioButton99.TabIndex = 0;
            this.radioButton99.TabStop = true;
            this.radioButton99.Text = "   ";
            this.radioButton99.UseVisualStyleBackColor = true;
            // 
            // radioButton100
            // 
            this.radioButton100.AutoSize = true;
            this.radioButton100.Location = new System.Drawing.Point(118, 5);
            this.radioButton100.Name = "radioButton100";
            this.radioButton100.Size = new System.Drawing.Size(39, 18);
            this.radioButton100.TabIndex = 1;
            this.radioButton100.TabStop = true;
            this.radioButton100.Text = "  ";
            this.radioButton100.UseVisualStyleBackColor = true;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Transparent;
            this.panel22.Controls.Add(this.radioButton101);
            this.panel22.Controls.Add(this.radioButton102);
            this.panel22.Controls.Add(this.radioButton103);
            this.panel22.Controls.Add(this.radioButton104);
            this.panel22.Controls.Add(this.radioButton105);
            this.panel22.Location = new System.Drawing.Point(476, 936);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(484, 28);
            this.panel22.TabIndex = 22;
            // 
            // radioButton101
            // 
            this.radioButton101.AutoSize = true;
            this.radioButton101.Location = new System.Drawing.Point(422, 4);
            this.radioButton101.Name = "radioButton101";
            this.radioButton101.Size = new System.Drawing.Size(39, 18);
            this.radioButton101.TabIndex = 4;
            this.radioButton101.TabStop = true;
            this.radioButton101.Text = "  ";
            this.radioButton101.UseVisualStyleBackColor = true;
            // 
            // radioButton102
            // 
            this.radioButton102.AutoSize = true;
            this.radioButton102.Location = new System.Drawing.Point(323, 5);
            this.radioButton102.Name = "radioButton102";
            this.radioButton102.Size = new System.Drawing.Size(39, 18);
            this.radioButton102.TabIndex = 3;
            this.radioButton102.TabStop = true;
            this.radioButton102.Text = "  ";
            this.radioButton102.UseVisualStyleBackColor = true;
            // 
            // radioButton103
            // 
            this.radioButton103.AutoSize = true;
            this.radioButton103.Location = new System.Drawing.Point(223, 5);
            this.radioButton103.Name = "radioButton103";
            this.radioButton103.Size = new System.Drawing.Size(39, 18);
            this.radioButton103.TabIndex = 2;
            this.radioButton103.TabStop = true;
            this.radioButton103.Text = "  ";
            this.radioButton103.UseVisualStyleBackColor = true;
            // 
            // radioButton104
            // 
            this.radioButton104.AutoSize = true;
            this.radioButton104.Location = new System.Drawing.Point(16, 5);
            this.radioButton104.Name = "radioButton104";
            this.radioButton104.Size = new System.Drawing.Size(46, 18);
            this.radioButton104.TabIndex = 0;
            this.radioButton104.TabStop = true;
            this.radioButton104.Text = "   ";
            this.radioButton104.UseVisualStyleBackColor = true;
            // 
            // radioButton105
            // 
            this.radioButton105.AutoSize = true;
            this.radioButton105.Location = new System.Drawing.Point(118, 5);
            this.radioButton105.Name = "radioButton105";
            this.radioButton105.Size = new System.Drawing.Size(39, 18);
            this.radioButton105.TabIndex = 1;
            this.radioButton105.TabStop = true;
            this.radioButton105.Text = "  ";
            this.radioButton105.UseVisualStyleBackColor = true;
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.Transparent;
            this.panel23.Controls.Add(this.radioButton106);
            this.panel23.Controls.Add(this.radioButton107);
            this.panel23.Controls.Add(this.radioButton108);
            this.panel23.Controls.Add(this.radioButton109);
            this.panel23.Controls.Add(this.radioButton110);
            this.panel23.Location = new System.Drawing.Point(476, 807);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(484, 28);
            this.panel23.TabIndex = 18;
            // 
            // radioButton106
            // 
            this.radioButton106.AutoSize = true;
            this.radioButton106.Location = new System.Drawing.Point(422, 6);
            this.radioButton106.Name = "radioButton106";
            this.radioButton106.Size = new System.Drawing.Size(39, 18);
            this.radioButton106.TabIndex = 4;
            this.radioButton106.TabStop = true;
            this.radioButton106.Text = "  ";
            this.radioButton106.UseVisualStyleBackColor = true;
            // 
            // radioButton107
            // 
            this.radioButton107.AutoSize = true;
            this.radioButton107.Location = new System.Drawing.Point(323, 5);
            this.radioButton107.Name = "radioButton107";
            this.radioButton107.Size = new System.Drawing.Size(39, 18);
            this.radioButton107.TabIndex = 3;
            this.radioButton107.TabStop = true;
            this.radioButton107.Text = "  ";
            this.radioButton107.UseVisualStyleBackColor = true;
            // 
            // radioButton108
            // 
            this.radioButton108.AutoSize = true;
            this.radioButton108.Location = new System.Drawing.Point(223, 5);
            this.radioButton108.Name = "radioButton108";
            this.radioButton108.Size = new System.Drawing.Size(39, 18);
            this.radioButton108.TabIndex = 2;
            this.radioButton108.TabStop = true;
            this.radioButton108.Text = "  ";
            this.radioButton108.UseVisualStyleBackColor = true;
            // 
            // radioButton109
            // 
            this.radioButton109.AutoSize = true;
            this.radioButton109.Location = new System.Drawing.Point(16, 5);
            this.radioButton109.Name = "radioButton109";
            this.radioButton109.Size = new System.Drawing.Size(46, 18);
            this.radioButton109.TabIndex = 0;
            this.radioButton109.TabStop = true;
            this.radioButton109.Text = "   ";
            this.radioButton109.UseVisualStyleBackColor = true;
            // 
            // radioButton110
            // 
            this.radioButton110.AutoSize = true;
            this.radioButton110.Location = new System.Drawing.Point(118, 5);
            this.radioButton110.Name = "radioButton110";
            this.radioButton110.Size = new System.Drawing.Size(39, 18);
            this.radioButton110.TabIndex = 1;
            this.radioButton110.TabStop = true;
            this.radioButton110.Text = "  ";
            this.radioButton110.UseVisualStyleBackColor = true;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.Transparent;
            this.panel24.Controls.Add(this.radioButton111);
            this.panel24.Controls.Add(this.radioButton112);
            this.panel24.Controls.Add(this.radioButton113);
            this.panel24.Controls.Add(this.radioButton114);
            this.panel24.Controls.Add(this.radioButton115);
            this.panel24.Location = new System.Drawing.Point(476, 907);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(484, 28);
            this.panel24.TabIndex = 21;
            // 
            // radioButton111
            // 
            this.radioButton111.AutoSize = true;
            this.radioButton111.Location = new System.Drawing.Point(422, 4);
            this.radioButton111.Name = "radioButton111";
            this.radioButton111.Size = new System.Drawing.Size(39, 18);
            this.radioButton111.TabIndex = 4;
            this.radioButton111.TabStop = true;
            this.radioButton111.Text = "  ";
            this.radioButton111.UseVisualStyleBackColor = true;
            // 
            // radioButton112
            // 
            this.radioButton112.AutoSize = true;
            this.radioButton112.Location = new System.Drawing.Point(323, 5);
            this.radioButton112.Name = "radioButton112";
            this.radioButton112.Size = new System.Drawing.Size(39, 18);
            this.radioButton112.TabIndex = 3;
            this.radioButton112.TabStop = true;
            this.radioButton112.Text = "  ";
            this.radioButton112.UseVisualStyleBackColor = true;
            // 
            // radioButton113
            // 
            this.radioButton113.AutoSize = true;
            this.radioButton113.Location = new System.Drawing.Point(223, 5);
            this.radioButton113.Name = "radioButton113";
            this.radioButton113.Size = new System.Drawing.Size(39, 18);
            this.radioButton113.TabIndex = 2;
            this.radioButton113.TabStop = true;
            this.radioButton113.Text = "  ";
            this.radioButton113.UseVisualStyleBackColor = true;
            // 
            // radioButton114
            // 
            this.radioButton114.AutoSize = true;
            this.radioButton114.Location = new System.Drawing.Point(16, 5);
            this.radioButton114.Name = "radioButton114";
            this.radioButton114.Size = new System.Drawing.Size(46, 18);
            this.radioButton114.TabIndex = 0;
            this.radioButton114.TabStop = true;
            this.radioButton114.Text = "   ";
            this.radioButton114.UseVisualStyleBackColor = true;
            // 
            // radioButton115
            // 
            this.radioButton115.AutoSize = true;
            this.radioButton115.Location = new System.Drawing.Point(118, 5);
            this.radioButton115.Name = "radioButton115";
            this.radioButton115.Size = new System.Drawing.Size(39, 18);
            this.radioButton115.TabIndex = 1;
            this.radioButton115.TabStop = true;
            this.radioButton115.Text = "  ";
            this.radioButton115.UseVisualStyleBackColor = true;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.Transparent;
            this.panel25.Controls.Add(this.radioButton116);
            this.panel25.Controls.Add(this.radioButton117);
            this.panel25.Controls.Add(this.radioButton118);
            this.panel25.Controls.Add(this.radioButton119);
            this.panel25.Controls.Add(this.radioButton120);
            this.panel25.Location = new System.Drawing.Point(476, 774);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(484, 28);
            this.panel25.TabIndex = 17;
            // 
            // radioButton116
            // 
            this.radioButton116.AutoSize = true;
            this.radioButton116.Location = new System.Drawing.Point(422, 4);
            this.radioButton116.Name = "radioButton116";
            this.radioButton116.Size = new System.Drawing.Size(39, 18);
            this.radioButton116.TabIndex = 4;
            this.radioButton116.TabStop = true;
            this.radioButton116.Text = "  ";
            this.radioButton116.UseVisualStyleBackColor = true;
            // 
            // radioButton117
            // 
            this.radioButton117.AutoSize = true;
            this.radioButton117.Location = new System.Drawing.Point(323, 5);
            this.radioButton117.Name = "radioButton117";
            this.radioButton117.Size = new System.Drawing.Size(39, 18);
            this.radioButton117.TabIndex = 3;
            this.radioButton117.TabStop = true;
            this.radioButton117.Text = "  ";
            this.radioButton117.UseVisualStyleBackColor = true;
            // 
            // radioButton118
            // 
            this.radioButton118.AutoSize = true;
            this.radioButton118.Location = new System.Drawing.Point(223, 5);
            this.radioButton118.Name = "radioButton118";
            this.radioButton118.Size = new System.Drawing.Size(39, 18);
            this.radioButton118.TabIndex = 2;
            this.radioButton118.TabStop = true;
            this.radioButton118.Text = "  ";
            this.radioButton118.UseVisualStyleBackColor = true;
            // 
            // radioButton119
            // 
            this.radioButton119.AutoSize = true;
            this.radioButton119.Location = new System.Drawing.Point(16, 5);
            this.radioButton119.Name = "radioButton119";
            this.radioButton119.Size = new System.Drawing.Size(46, 18);
            this.radioButton119.TabIndex = 0;
            this.radioButton119.TabStop = true;
            this.radioButton119.Text = "   ";
            this.radioButton119.UseVisualStyleBackColor = true;
            // 
            // radioButton120
            // 
            this.radioButton120.AutoSize = true;
            this.radioButton120.Location = new System.Drawing.Point(118, 5);
            this.radioButton120.Name = "radioButton120";
            this.radioButton120.Size = new System.Drawing.Size(39, 18);
            this.radioButton120.TabIndex = 1;
            this.radioButton120.TabStop = true;
            this.radioButton120.Text = "  ";
            this.radioButton120.UseVisualStyleBackColor = true;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.Transparent;
            this.panel18.Controls.Add(this.radioButton81);
            this.panel18.Controls.Add(this.radioButton82);
            this.panel18.Controls.Add(this.radioButton83);
            this.panel18.Controls.Add(this.radioButton84);
            this.panel18.Controls.Add(this.radioButton85);
            this.panel18.Location = new System.Drawing.Point(476, 718);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(484, 28);
            this.panel18.TabIndex = 16;
            // 
            // radioButton81
            // 
            this.radioButton81.AutoSize = true;
            this.radioButton81.Location = new System.Drawing.Point(422, 0);
            this.radioButton81.Name = "radioButton81";
            this.radioButton81.Size = new System.Drawing.Size(39, 18);
            this.radioButton81.TabIndex = 4;
            this.radioButton81.TabStop = true;
            this.radioButton81.Text = "  ";
            this.radioButton81.UseVisualStyleBackColor = true;
            // 
            // radioButton82
            // 
            this.radioButton82.AutoSize = true;
            this.radioButton82.Location = new System.Drawing.Point(323, 5);
            this.radioButton82.Name = "radioButton82";
            this.radioButton82.Size = new System.Drawing.Size(39, 18);
            this.radioButton82.TabIndex = 3;
            this.radioButton82.TabStop = true;
            this.radioButton82.Text = "  ";
            this.radioButton82.UseVisualStyleBackColor = true;
            // 
            // radioButton83
            // 
            this.radioButton83.AutoSize = true;
            this.radioButton83.Location = new System.Drawing.Point(223, 5);
            this.radioButton83.Name = "radioButton83";
            this.radioButton83.Size = new System.Drawing.Size(39, 18);
            this.radioButton83.TabIndex = 2;
            this.radioButton83.TabStop = true;
            this.radioButton83.Text = "  ";
            this.radioButton83.UseVisualStyleBackColor = true;
            // 
            // radioButton84
            // 
            this.radioButton84.AutoSize = true;
            this.radioButton84.Location = new System.Drawing.Point(16, 5);
            this.radioButton84.Name = "radioButton84";
            this.radioButton84.Size = new System.Drawing.Size(46, 18);
            this.radioButton84.TabIndex = 0;
            this.radioButton84.TabStop = true;
            this.radioButton84.Text = "   ";
            this.radioButton84.UseVisualStyleBackColor = true;
            // 
            // radioButton85
            // 
            this.radioButton85.AutoSize = true;
            this.radioButton85.Location = new System.Drawing.Point(118, 5);
            this.radioButton85.Name = "radioButton85";
            this.radioButton85.Size = new System.Drawing.Size(39, 18);
            this.radioButton85.TabIndex = 1;
            this.radioButton85.TabStop = true;
            this.radioButton85.Text = "  ";
            this.radioButton85.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Transparent;
            this.panel16.Controls.Add(this.radioButton71);
            this.panel16.Controls.Add(this.radioButton72);
            this.panel16.Controls.Add(this.radioButton73);
            this.panel16.Controls.Add(this.radioButton74);
            this.panel16.Controls.Add(this.radioButton75);
            this.panel16.Location = new System.Drawing.Point(476, 689);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(484, 28);
            this.panel16.TabIndex = 15;
            // 
            // radioButton71
            // 
            this.radioButton71.AutoSize = true;
            this.radioButton71.Location = new System.Drawing.Point(422, 4);
            this.radioButton71.Name = "radioButton71";
            this.radioButton71.Size = new System.Drawing.Size(39, 18);
            this.radioButton71.TabIndex = 4;
            this.radioButton71.TabStop = true;
            this.radioButton71.Text = "  ";
            this.radioButton71.UseVisualStyleBackColor = true;
            // 
            // radioButton72
            // 
            this.radioButton72.AutoSize = true;
            this.radioButton72.Location = new System.Drawing.Point(323, 5);
            this.radioButton72.Name = "radioButton72";
            this.radioButton72.Size = new System.Drawing.Size(39, 18);
            this.radioButton72.TabIndex = 3;
            this.radioButton72.TabStop = true;
            this.radioButton72.Text = "  ";
            this.radioButton72.UseVisualStyleBackColor = true;
            // 
            // radioButton73
            // 
            this.radioButton73.AutoSize = true;
            this.radioButton73.Location = new System.Drawing.Point(223, 5);
            this.radioButton73.Name = "radioButton73";
            this.radioButton73.Size = new System.Drawing.Size(39, 18);
            this.radioButton73.TabIndex = 2;
            this.radioButton73.TabStop = true;
            this.radioButton73.Text = "  ";
            this.radioButton73.UseVisualStyleBackColor = true;
            // 
            // radioButton74
            // 
            this.radioButton74.AutoSize = true;
            this.radioButton74.Location = new System.Drawing.Point(16, 5);
            this.radioButton74.Name = "radioButton74";
            this.radioButton74.Size = new System.Drawing.Size(46, 18);
            this.radioButton74.TabIndex = 0;
            this.radioButton74.TabStop = true;
            this.radioButton74.Text = "   ";
            this.radioButton74.UseVisualStyleBackColor = true;
            // 
            // radioButton75
            // 
            this.radioButton75.AutoSize = true;
            this.radioButton75.Location = new System.Drawing.Point(118, 5);
            this.radioButton75.Name = "radioButton75";
            this.radioButton75.Size = new System.Drawing.Size(39, 18);
            this.radioButton75.TabIndex = 1;
            this.radioButton75.TabStop = true;
            this.radioButton75.Text = "  ";
            this.radioButton75.UseVisualStyleBackColor = true;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Transparent;
            this.panel15.Controls.Add(this.radioButton66);
            this.panel15.Controls.Add(this.radioButton67);
            this.panel15.Controls.Add(this.radioButton68);
            this.panel15.Controls.Add(this.radioButton69);
            this.panel15.Controls.Add(this.radioButton70);
            this.panel15.Location = new System.Drawing.Point(476, 607);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(484, 28);
            this.panel15.TabIndex = 14;
            // 
            // radioButton66
            // 
            this.radioButton66.AutoSize = true;
            this.radioButton66.Location = new System.Drawing.Point(422, -2);
            this.radioButton66.Name = "radioButton66";
            this.radioButton66.Size = new System.Drawing.Size(39, 18);
            this.radioButton66.TabIndex = 4;
            this.radioButton66.TabStop = true;
            this.radioButton66.Text = "  ";
            this.radioButton66.UseVisualStyleBackColor = true;
            // 
            // radioButton67
            // 
            this.radioButton67.AutoSize = true;
            this.radioButton67.Location = new System.Drawing.Point(323, 5);
            this.radioButton67.Name = "radioButton67";
            this.radioButton67.Size = new System.Drawing.Size(39, 18);
            this.radioButton67.TabIndex = 3;
            this.radioButton67.TabStop = true;
            this.radioButton67.Text = "  ";
            this.radioButton67.UseVisualStyleBackColor = true;
            // 
            // radioButton68
            // 
            this.radioButton68.AutoSize = true;
            this.radioButton68.Location = new System.Drawing.Point(223, 5);
            this.radioButton68.Name = "radioButton68";
            this.radioButton68.Size = new System.Drawing.Size(39, 18);
            this.radioButton68.TabIndex = 2;
            this.radioButton68.TabStop = true;
            this.radioButton68.Text = "  ";
            this.radioButton68.UseVisualStyleBackColor = true;
            // 
            // radioButton69
            // 
            this.radioButton69.AutoSize = true;
            this.radioButton69.Location = new System.Drawing.Point(16, 5);
            this.radioButton69.Name = "radioButton69";
            this.radioButton69.Size = new System.Drawing.Size(46, 18);
            this.radioButton69.TabIndex = 0;
            this.radioButton69.TabStop = true;
            this.radioButton69.Text = "   ";
            this.radioButton69.UseVisualStyleBackColor = true;
            // 
            // radioButton70
            // 
            this.radioButton70.AutoSize = true;
            this.radioButton70.Location = new System.Drawing.Point(118, 5);
            this.radioButton70.Name = "radioButton70";
            this.radioButton70.Size = new System.Drawing.Size(39, 18);
            this.radioButton70.TabIndex = 1;
            this.radioButton70.TabStop = true;
            this.radioButton70.Text = "  ";
            this.radioButton70.UseVisualStyleBackColor = true;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Transparent;
            this.panel17.Controls.Add(this.radioButton76);
            this.panel17.Controls.Add(this.radioButton77);
            this.panel17.Controls.Add(this.radioButton78);
            this.panel17.Controls.Add(this.radioButton79);
            this.panel17.Controls.Add(this.radioButton80);
            this.panel17.Location = new System.Drawing.Point(476, 658);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(484, 28);
            this.panel17.TabIndex = 14;
            // 
            // radioButton76
            // 
            this.radioButton76.AutoSize = true;
            this.radioButton76.Location = new System.Drawing.Point(422, 4);
            this.radioButton76.Name = "radioButton76";
            this.radioButton76.Size = new System.Drawing.Size(39, 18);
            this.radioButton76.TabIndex = 4;
            this.radioButton76.TabStop = true;
            this.radioButton76.Text = "  ";
            this.radioButton76.UseVisualStyleBackColor = true;
            // 
            // radioButton77
            // 
            this.radioButton77.AutoSize = true;
            this.radioButton77.Location = new System.Drawing.Point(323, 5);
            this.radioButton77.Name = "radioButton77";
            this.radioButton77.Size = new System.Drawing.Size(39, 18);
            this.radioButton77.TabIndex = 3;
            this.radioButton77.TabStop = true;
            this.radioButton77.Text = "  ";
            this.radioButton77.UseVisualStyleBackColor = true;
            // 
            // radioButton78
            // 
            this.radioButton78.AutoSize = true;
            this.radioButton78.Location = new System.Drawing.Point(223, 5);
            this.radioButton78.Name = "radioButton78";
            this.radioButton78.Size = new System.Drawing.Size(39, 18);
            this.radioButton78.TabIndex = 2;
            this.radioButton78.TabStop = true;
            this.radioButton78.Text = "  ";
            this.radioButton78.UseVisualStyleBackColor = true;
            // 
            // radioButton79
            // 
            this.radioButton79.AutoSize = true;
            this.radioButton79.Location = new System.Drawing.Point(16, 5);
            this.radioButton79.Name = "radioButton79";
            this.radioButton79.Size = new System.Drawing.Size(46, 18);
            this.radioButton79.TabIndex = 0;
            this.radioButton79.TabStop = true;
            this.radioButton79.Text = "   ";
            this.radioButton79.UseVisualStyleBackColor = true;
            // 
            // radioButton80
            // 
            this.radioButton80.AutoSize = true;
            this.radioButton80.Location = new System.Drawing.Point(118, 5);
            this.radioButton80.Name = "radioButton80";
            this.radioButton80.Size = new System.Drawing.Size(39, 18);
            this.radioButton80.TabIndex = 1;
            this.radioButton80.TabStop = true;
            this.radioButton80.Text = "  ";
            this.radioButton80.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.radioButton46);
            this.panel11.Controls.Add(this.radioButton47);
            this.panel11.Controls.Add(this.radioButton48);
            this.panel11.Controls.Add(this.radioButton49);
            this.panel11.Controls.Add(this.radioButton50);
            this.panel11.Location = new System.Drawing.Point(476, 572);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(484, 28);
            this.panel11.TabIndex = 13;
            // 
            // radioButton46
            // 
            this.radioButton46.AutoSize = true;
            this.radioButton46.Location = new System.Drawing.Point(422, 4);
            this.radioButton46.Name = "radioButton46";
            this.radioButton46.Size = new System.Drawing.Size(39, 18);
            this.radioButton46.TabIndex = 4;
            this.radioButton46.TabStop = true;
            this.radioButton46.Text = "  ";
            this.radioButton46.UseVisualStyleBackColor = true;
            // 
            // radioButton47
            // 
            this.radioButton47.AutoSize = true;
            this.radioButton47.Location = new System.Drawing.Point(323, 5);
            this.radioButton47.Name = "radioButton47";
            this.radioButton47.Size = new System.Drawing.Size(39, 18);
            this.radioButton47.TabIndex = 3;
            this.radioButton47.TabStop = true;
            this.radioButton47.Text = "  ";
            this.radioButton47.UseVisualStyleBackColor = true;
            // 
            // radioButton48
            // 
            this.radioButton48.AutoSize = true;
            this.radioButton48.Location = new System.Drawing.Point(223, 5);
            this.radioButton48.Name = "radioButton48";
            this.radioButton48.Size = new System.Drawing.Size(39, 18);
            this.radioButton48.TabIndex = 2;
            this.radioButton48.TabStop = true;
            this.radioButton48.Text = "  ";
            this.radioButton48.UseVisualStyleBackColor = true;
            // 
            // radioButton49
            // 
            this.radioButton49.AutoSize = true;
            this.radioButton49.Location = new System.Drawing.Point(16, 5);
            this.radioButton49.Name = "radioButton49";
            this.radioButton49.Size = new System.Drawing.Size(46, 18);
            this.radioButton49.TabIndex = 0;
            this.radioButton49.TabStop = true;
            this.radioButton49.Text = "   ";
            this.radioButton49.UseVisualStyleBackColor = true;
            // 
            // radioButton50
            // 
            this.radioButton50.AutoSize = true;
            this.radioButton50.Location = new System.Drawing.Point(118, 5);
            this.radioButton50.Name = "radioButton50";
            this.radioButton50.Size = new System.Drawing.Size(39, 18);
            this.radioButton50.TabIndex = 1;
            this.radioButton50.TabStop = true;
            this.radioButton50.Text = "  ";
            this.radioButton50.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.radioButton41);
            this.panel10.Controls.Add(this.radioButton42);
            this.panel10.Controls.Add(this.radioButton43);
            this.panel10.Controls.Add(this.radioButton44);
            this.panel10.Controls.Add(this.radioButton45);
            this.panel10.Location = new System.Drawing.Point(476, 436);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(484, 28);
            this.panel10.TabIndex = 10;
            // 
            // radioButton41
            // 
            this.radioButton41.AutoSize = true;
            this.radioButton41.Location = new System.Drawing.Point(422, 4);
            this.radioButton41.Name = "radioButton41";
            this.radioButton41.Size = new System.Drawing.Size(39, 18);
            this.radioButton41.TabIndex = 4;
            this.radioButton41.TabStop = true;
            this.radioButton41.Text = "  ";
            this.radioButton41.UseVisualStyleBackColor = true;
            // 
            // radioButton42
            // 
            this.radioButton42.AutoSize = true;
            this.radioButton42.Location = new System.Drawing.Point(323, 5);
            this.radioButton42.Name = "radioButton42";
            this.radioButton42.Size = new System.Drawing.Size(39, 18);
            this.radioButton42.TabIndex = 3;
            this.radioButton42.TabStop = true;
            this.radioButton42.Text = "  ";
            this.radioButton42.UseVisualStyleBackColor = true;
            // 
            // radioButton43
            // 
            this.radioButton43.AutoSize = true;
            this.radioButton43.Location = new System.Drawing.Point(223, 5);
            this.radioButton43.Name = "radioButton43";
            this.radioButton43.Size = new System.Drawing.Size(39, 18);
            this.radioButton43.TabIndex = 2;
            this.radioButton43.TabStop = true;
            this.radioButton43.Text = "  ";
            this.radioButton43.UseVisualStyleBackColor = true;
            // 
            // radioButton44
            // 
            this.radioButton44.AutoSize = true;
            this.radioButton44.Location = new System.Drawing.Point(16, 5);
            this.radioButton44.Name = "radioButton44";
            this.radioButton44.Size = new System.Drawing.Size(46, 18);
            this.radioButton44.TabIndex = 0;
            this.radioButton44.TabStop = true;
            this.radioButton44.Text = "   ";
            this.radioButton44.UseVisualStyleBackColor = true;
            // 
            // radioButton45
            // 
            this.radioButton45.AutoSize = true;
            this.radioButton45.Location = new System.Drawing.Point(118, 5);
            this.radioButton45.Name = "radioButton45";
            this.radioButton45.Size = new System.Drawing.Size(39, 18);
            this.radioButton45.TabIndex = 1;
            this.radioButton45.TabStop = true;
            this.radioButton45.Text = "  ";
            this.radioButton45.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.radioButton51);
            this.panel12.Controls.Add(this.radioButton52);
            this.panel12.Controls.Add(this.radioButton53);
            this.panel12.Controls.Add(this.radioButton54);
            this.panel12.Controls.Add(this.radioButton55);
            this.panel12.Location = new System.Drawing.Point(476, 541);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(484, 28);
            this.panel12.TabIndex = 12;
            // 
            // radioButton51
            // 
            this.radioButton51.AutoSize = true;
            this.radioButton51.Location = new System.Drawing.Point(422, 4);
            this.radioButton51.Name = "radioButton51";
            this.radioButton51.Size = new System.Drawing.Size(39, 18);
            this.radioButton51.TabIndex = 4;
            this.radioButton51.TabStop = true;
            this.radioButton51.Text = "  ";
            this.radioButton51.UseVisualStyleBackColor = true;
            // 
            // radioButton52
            // 
            this.radioButton52.AutoSize = true;
            this.radioButton52.Location = new System.Drawing.Point(323, 5);
            this.radioButton52.Name = "radioButton52";
            this.radioButton52.Size = new System.Drawing.Size(39, 18);
            this.radioButton52.TabIndex = 3;
            this.radioButton52.TabStop = true;
            this.radioButton52.Text = "  ";
            this.radioButton52.UseVisualStyleBackColor = true;
            // 
            // radioButton53
            // 
            this.radioButton53.AutoSize = true;
            this.radioButton53.Location = new System.Drawing.Point(223, 5);
            this.radioButton53.Name = "radioButton53";
            this.radioButton53.Size = new System.Drawing.Size(39, 18);
            this.radioButton53.TabIndex = 2;
            this.radioButton53.TabStop = true;
            this.radioButton53.Text = "  ";
            this.radioButton53.UseVisualStyleBackColor = true;
            // 
            // radioButton54
            // 
            this.radioButton54.AutoSize = true;
            this.radioButton54.Location = new System.Drawing.Point(16, 5);
            this.radioButton54.Name = "radioButton54";
            this.radioButton54.Size = new System.Drawing.Size(46, 18);
            this.radioButton54.TabIndex = 0;
            this.radioButton54.TabStop = true;
            this.radioButton54.Text = "   ";
            this.radioButton54.UseVisualStyleBackColor = true;
            // 
            // radioButton55
            // 
            this.radioButton55.AutoSize = true;
            this.radioButton55.Location = new System.Drawing.Point(118, 5);
            this.radioButton55.Name = "radioButton55";
            this.radioButton55.Size = new System.Drawing.Size(39, 18);
            this.radioButton55.TabIndex = 1;
            this.radioButton55.TabStop = true;
            this.radioButton55.Text = "  ";
            this.radioButton55.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.radioButton21);
            this.panel6.Controls.Add(this.radioButton22);
            this.panel6.Controls.Add(this.radioButton23);
            this.panel6.Controls.Add(this.radioButton24);
            this.panel6.Controls.Add(this.radioButton25);
            this.panel6.Location = new System.Drawing.Point(476, 411);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(484, 28);
            this.panel6.TabIndex = 9;
            // 
            // radioButton21
            // 
            this.radioButton21.AutoSize = true;
            this.radioButton21.Location = new System.Drawing.Point(422, 4);
            this.radioButton21.Name = "radioButton21";
            this.radioButton21.Size = new System.Drawing.Size(39, 18);
            this.radioButton21.TabIndex = 4;
            this.radioButton21.TabStop = true;
            this.radioButton21.Text = "  ";
            this.radioButton21.UseVisualStyleBackColor = true;
            // 
            // radioButton22
            // 
            this.radioButton22.AutoSize = true;
            this.radioButton22.Location = new System.Drawing.Point(323, 5);
            this.radioButton22.Name = "radioButton22";
            this.radioButton22.Size = new System.Drawing.Size(39, 18);
            this.radioButton22.TabIndex = 3;
            this.radioButton22.TabStop = true;
            this.radioButton22.Text = "  ";
            this.radioButton22.UseVisualStyleBackColor = true;
            // 
            // radioButton23
            // 
            this.radioButton23.AutoSize = true;
            this.radioButton23.Location = new System.Drawing.Point(223, 5);
            this.radioButton23.Name = "radioButton23";
            this.radioButton23.Size = new System.Drawing.Size(39, 18);
            this.radioButton23.TabIndex = 2;
            this.radioButton23.TabStop = true;
            this.radioButton23.Text = "  ";
            this.radioButton23.UseVisualStyleBackColor = true;
            // 
            // radioButton24
            // 
            this.radioButton24.AutoSize = true;
            this.radioButton24.Location = new System.Drawing.Point(16, 5);
            this.radioButton24.Name = "radioButton24";
            this.radioButton24.Size = new System.Drawing.Size(46, 18);
            this.radioButton24.TabIndex = 0;
            this.radioButton24.TabStop = true;
            this.radioButton24.Text = "   ";
            this.radioButton24.UseVisualStyleBackColor = true;
            // 
            // radioButton25
            // 
            this.radioButton25.AutoSize = true;
            this.radioButton25.Location = new System.Drawing.Point(118, 5);
            this.radioButton25.Name = "radioButton25";
            this.radioButton25.Size = new System.Drawing.Size(39, 18);
            this.radioButton25.TabIndex = 1;
            this.radioButton25.TabStop = true;
            this.radioButton25.Text = "  ";
            this.radioButton25.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Controls.Add(this.radioButton56);
            this.panel13.Controls.Add(this.radioButton57);
            this.panel13.Controls.Add(this.radioButton58);
            this.panel13.Controls.Add(this.radioButton59);
            this.panel13.Controls.Add(this.radioButton60);
            this.panel13.Location = new System.Drawing.Point(476, 508);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(484, 28);
            this.panel13.TabIndex = 11;
            // 
            // radioButton56
            // 
            this.radioButton56.AutoSize = true;
            this.radioButton56.Location = new System.Drawing.Point(422, 4);
            this.radioButton56.Name = "radioButton56";
            this.radioButton56.Size = new System.Drawing.Size(39, 18);
            this.radioButton56.TabIndex = 4;
            this.radioButton56.TabStop = true;
            this.radioButton56.Text = "  ";
            this.radioButton56.UseVisualStyleBackColor = true;
            // 
            // radioButton57
            // 
            this.radioButton57.AutoSize = true;
            this.radioButton57.Location = new System.Drawing.Point(323, 5);
            this.radioButton57.Name = "radioButton57";
            this.radioButton57.Size = new System.Drawing.Size(39, 18);
            this.radioButton57.TabIndex = 3;
            this.radioButton57.TabStop = true;
            this.radioButton57.Text = "  ";
            this.radioButton57.UseVisualStyleBackColor = true;
            // 
            // radioButton58
            // 
            this.radioButton58.AutoSize = true;
            this.radioButton58.Location = new System.Drawing.Point(223, 5);
            this.radioButton58.Name = "radioButton58";
            this.radioButton58.Size = new System.Drawing.Size(39, 18);
            this.radioButton58.TabIndex = 2;
            this.radioButton58.TabStop = true;
            this.radioButton58.Text = "  ";
            this.radioButton58.UseVisualStyleBackColor = true;
            // 
            // radioButton59
            // 
            this.radioButton59.AutoSize = true;
            this.radioButton59.Location = new System.Drawing.Point(16, 5);
            this.radioButton59.Name = "radioButton59";
            this.radioButton59.Size = new System.Drawing.Size(46, 18);
            this.radioButton59.TabIndex = 0;
            this.radioButton59.TabStop = true;
            this.radioButton59.Text = "   ";
            this.radioButton59.UseVisualStyleBackColor = true;
            // 
            // radioButton60
            // 
            this.radioButton60.AutoSize = true;
            this.radioButton60.Location = new System.Drawing.Point(118, 5);
            this.radioButton60.Name = "radioButton60";
            this.radioButton60.Size = new System.Drawing.Size(39, 18);
            this.radioButton60.TabIndex = 1;
            this.radioButton60.TabStop = true;
            this.radioButton60.Text = "  ";
            this.radioButton60.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.radioButton16);
            this.panel5.Controls.Add(this.radioButton17);
            this.panel5.Controls.Add(this.radioButton18);
            this.panel5.Controls.Add(this.radioButton19);
            this.panel5.Controls.Add(this.radioButton20);
            this.panel5.Location = new System.Drawing.Point(476, 289);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 28);
            this.panel5.TabIndex = 5;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(422, 4);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(39, 18);
            this.radioButton16.TabIndex = 4;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "  ";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(323, 5);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(39, 18);
            this.radioButton17.TabIndex = 3;
            this.radioButton17.TabStop = true;
            this.radioButton17.Text = "  ";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.Location = new System.Drawing.Point(223, 5);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(39, 18);
            this.radioButton18.TabIndex = 2;
            this.radioButton18.TabStop = true;
            this.radioButton18.Text = "  ";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // radioButton19
            // 
            this.radioButton19.AutoSize = true;
            this.radioButton19.Location = new System.Drawing.Point(16, 5);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Size = new System.Drawing.Size(46, 18);
            this.radioButton19.TabIndex = 0;
            this.radioButton19.TabStop = true;
            this.radioButton19.Text = "   ";
            this.radioButton19.UseVisualStyleBackColor = true;
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.Location = new System.Drawing.Point(118, 5);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(39, 18);
            this.radioButton20.TabIndex = 1;
            this.radioButton20.TabStop = true;
            this.radioButton20.Text = "  ";
            this.radioButton20.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Controls.Add(this.radioButton61);
            this.panel14.Controls.Add(this.radioButton62);
            this.panel14.Controls.Add(this.radioButton63);
            this.panel14.Controls.Add(this.radioButton64);
            this.panel14.Controls.Add(this.radioButton65);
            this.panel14.Location = new System.Drawing.Point(476, 476);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(484, 28);
            this.panel14.TabIndex = 10;
            // 
            // radioButton61
            // 
            this.radioButton61.AutoSize = true;
            this.radioButton61.Location = new System.Drawing.Point(422, 4);
            this.radioButton61.Name = "radioButton61";
            this.radioButton61.Size = new System.Drawing.Size(39, 18);
            this.radioButton61.TabIndex = 4;
            this.radioButton61.TabStop = true;
            this.radioButton61.Text = "  ";
            this.radioButton61.UseVisualStyleBackColor = true;
            // 
            // radioButton62
            // 
            this.radioButton62.AutoSize = true;
            this.radioButton62.Location = new System.Drawing.Point(323, 5);
            this.radioButton62.Name = "radioButton62";
            this.radioButton62.Size = new System.Drawing.Size(39, 18);
            this.radioButton62.TabIndex = 3;
            this.radioButton62.TabStop = true;
            this.radioButton62.Text = "  ";
            this.radioButton62.UseVisualStyleBackColor = true;
            // 
            // radioButton63
            // 
            this.radioButton63.AutoSize = true;
            this.radioButton63.Location = new System.Drawing.Point(223, 5);
            this.radioButton63.Name = "radioButton63";
            this.radioButton63.Size = new System.Drawing.Size(39, 18);
            this.radioButton63.TabIndex = 2;
            this.radioButton63.TabStop = true;
            this.radioButton63.Text = "  ";
            this.radioButton63.UseVisualStyleBackColor = true;
            // 
            // radioButton64
            // 
            this.radioButton64.AutoSize = true;
            this.radioButton64.Location = new System.Drawing.Point(16, 5);
            this.radioButton64.Name = "radioButton64";
            this.radioButton64.Size = new System.Drawing.Size(46, 18);
            this.radioButton64.TabIndex = 0;
            this.radioButton64.TabStop = true;
            this.radioButton64.Text = "   ";
            this.radioButton64.UseVisualStyleBackColor = true;
            // 
            // radioButton65
            // 
            this.radioButton65.AutoSize = true;
            this.radioButton65.Location = new System.Drawing.Point(118, 5);
            this.radioButton65.Name = "radioButton65";
            this.radioButton65.Size = new System.Drawing.Size(39, 18);
            this.radioButton65.TabIndex = 1;
            this.radioButton65.TabStop = true;
            this.radioButton65.Text = "  ";
            this.radioButton65.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.radioButton26);
            this.panel7.Controls.Add(this.radioButton27);
            this.panel7.Controls.Add(this.radioButton28);
            this.panel7.Controls.Add(this.radioButton29);
            this.panel7.Controls.Add(this.radioButton30);
            this.panel7.Location = new System.Drawing.Point(476, 380);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(484, 28);
            this.panel7.TabIndex = 8;
            // 
            // radioButton26
            // 
            this.radioButton26.AutoSize = true;
            this.radioButton26.Location = new System.Drawing.Point(422, 4);
            this.radioButton26.Name = "radioButton26";
            this.radioButton26.Size = new System.Drawing.Size(39, 18);
            this.radioButton26.TabIndex = 4;
            this.radioButton26.TabStop = true;
            this.radioButton26.Text = "  ";
            this.radioButton26.UseVisualStyleBackColor = true;
            // 
            // radioButton27
            // 
            this.radioButton27.AutoSize = true;
            this.radioButton27.Location = new System.Drawing.Point(323, 5);
            this.radioButton27.Name = "radioButton27";
            this.radioButton27.Size = new System.Drawing.Size(39, 18);
            this.radioButton27.TabIndex = 3;
            this.radioButton27.TabStop = true;
            this.radioButton27.Text = "  ";
            this.radioButton27.UseVisualStyleBackColor = true;
            // 
            // radioButton28
            // 
            this.radioButton28.AutoSize = true;
            this.radioButton28.Location = new System.Drawing.Point(223, 5);
            this.radioButton28.Name = "radioButton28";
            this.radioButton28.Size = new System.Drawing.Size(39, 18);
            this.radioButton28.TabIndex = 2;
            this.radioButton28.TabStop = true;
            this.radioButton28.Text = "  ";
            this.radioButton28.UseVisualStyleBackColor = true;
            // 
            // radioButton29
            // 
            this.radioButton29.AutoSize = true;
            this.radioButton29.Location = new System.Drawing.Point(16, 5);
            this.radioButton29.Name = "radioButton29";
            this.radioButton29.Size = new System.Drawing.Size(46, 18);
            this.radioButton29.TabIndex = 0;
            this.radioButton29.TabStop = true;
            this.radioButton29.Text = "   ";
            this.radioButton29.UseVisualStyleBackColor = true;
            // 
            // radioButton30
            // 
            this.radioButton30.AutoSize = true;
            this.radioButton30.Location = new System.Drawing.Point(118, 5);
            this.radioButton30.Name = "radioButton30";
            this.radioButton30.Size = new System.Drawing.Size(39, 18);
            this.radioButton30.TabIndex = 1;
            this.radioButton30.TabStop = true;
            this.radioButton30.Text = "  ";
            this.radioButton30.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.radioButton11);
            this.panel4.Controls.Add(this.radioButton12);
            this.panel4.Controls.Add(this.radioButton13);
            this.panel4.Controls.Add(this.radioButton14);
            this.panel4.Controls.Add(this.radioButton15);
            this.panel4.Location = new System.Drawing.Point(476, 258);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 28);
            this.panel4.TabIndex = 4;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(422, 4);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(39, 18);
            this.radioButton11.TabIndex = 4;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "  ";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(323, 5);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(39, 18);
            this.radioButton12.TabIndex = 3;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "  ";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(223, 5);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(39, 18);
            this.radioButton13.TabIndex = 2;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "  ";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(16, 5);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(46, 18);
            this.radioButton14.TabIndex = 0;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "   ";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(118, 5);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(39, 18);
            this.radioButton15.TabIndex = 1;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "  ";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.radioButton31);
            this.panel8.Controls.Add(this.radioButton32);
            this.panel8.Controls.Add(this.radioButton33);
            this.panel8.Controls.Add(this.radioButton34);
            this.panel8.Controls.Add(this.radioButton35);
            this.panel8.Location = new System.Drawing.Point(476, 347);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(484, 28);
            this.panel8.TabIndex = 7;
            // 
            // radioButton31
            // 
            this.radioButton31.AutoSize = true;
            this.radioButton31.Location = new System.Drawing.Point(422, 4);
            this.radioButton31.Name = "radioButton31";
            this.radioButton31.Size = new System.Drawing.Size(39, 18);
            this.radioButton31.TabIndex = 4;
            this.radioButton31.TabStop = true;
            this.radioButton31.Text = "  ";
            this.radioButton31.UseVisualStyleBackColor = true;
            // 
            // radioButton32
            // 
            this.radioButton32.AutoSize = true;
            this.radioButton32.Location = new System.Drawing.Point(323, 5);
            this.radioButton32.Name = "radioButton32";
            this.radioButton32.Size = new System.Drawing.Size(39, 18);
            this.radioButton32.TabIndex = 3;
            this.radioButton32.TabStop = true;
            this.radioButton32.Text = "  ";
            this.radioButton32.UseVisualStyleBackColor = true;
            // 
            // radioButton33
            // 
            this.radioButton33.AutoSize = true;
            this.radioButton33.Location = new System.Drawing.Point(223, 5);
            this.radioButton33.Name = "radioButton33";
            this.radioButton33.Size = new System.Drawing.Size(39, 18);
            this.radioButton33.TabIndex = 2;
            this.radioButton33.TabStop = true;
            this.radioButton33.Text = "  ";
            this.radioButton33.UseVisualStyleBackColor = true;
            // 
            // radioButton34
            // 
            this.radioButton34.AutoSize = true;
            this.radioButton34.Location = new System.Drawing.Point(16, 5);
            this.radioButton34.Name = "radioButton34";
            this.radioButton34.Size = new System.Drawing.Size(46, 18);
            this.radioButton34.TabIndex = 0;
            this.radioButton34.TabStop = true;
            this.radioButton34.Text = "   ";
            this.radioButton34.UseVisualStyleBackColor = true;
            // 
            // radioButton35
            // 
            this.radioButton35.AutoSize = true;
            this.radioButton35.Location = new System.Drawing.Point(118, 5);
            this.radioButton35.Name = "radioButton35";
            this.radioButton35.Size = new System.Drawing.Size(39, 18);
            this.radioButton35.TabIndex = 1;
            this.radioButton35.TabStop = true;
            this.radioButton35.Text = "  ";
            this.radioButton35.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.radioButton6);
            this.panel3.Controls.Add(this.radioButton7);
            this.panel3.Controls.Add(this.radioButton8);
            this.panel3.Controls.Add(this.radioButton9);
            this.panel3.Controls.Add(this.radioButton10);
            this.panel3.Location = new System.Drawing.Point(476, 225);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 28);
            this.panel3.TabIndex = 3;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(422, 4);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(39, 18);
            this.radioButton6.TabIndex = 4;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "  ";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(323, 5);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(39, 18);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "  ";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(223, 5);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(39, 18);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "  ";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(16, 5);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(46, 18);
            this.radioButton9.TabIndex = 0;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "   ";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(118, 5);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(39, 18);
            this.radioButton10.TabIndex = 1;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "  ";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.radioButton36);
            this.panel9.Controls.Add(this.radioButton37);
            this.panel9.Controls.Add(this.radioButton38);
            this.panel9.Controls.Add(this.radioButton39);
            this.panel9.Controls.Add(this.radioButton40);
            this.panel9.Location = new System.Drawing.Point(476, 315);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(484, 28);
            this.panel9.TabIndex = 6;
            // 
            // radioButton36
            // 
            this.radioButton36.AutoSize = true;
            this.radioButton36.Location = new System.Drawing.Point(422, 4);
            this.radioButton36.Name = "radioButton36";
            this.radioButton36.Size = new System.Drawing.Size(39, 18);
            this.radioButton36.TabIndex = 4;
            this.radioButton36.TabStop = true;
            this.radioButton36.Text = "  ";
            this.radioButton36.UseVisualStyleBackColor = true;
            // 
            // radioButton37
            // 
            this.radioButton37.AutoSize = true;
            this.radioButton37.Location = new System.Drawing.Point(323, 5);
            this.radioButton37.Name = "radioButton37";
            this.radioButton37.Size = new System.Drawing.Size(39, 18);
            this.radioButton37.TabIndex = 3;
            this.radioButton37.TabStop = true;
            this.radioButton37.Text = "  ";
            this.radioButton37.UseVisualStyleBackColor = true;
            // 
            // radioButton38
            // 
            this.radioButton38.AutoSize = true;
            this.radioButton38.Location = new System.Drawing.Point(223, 5);
            this.radioButton38.Name = "radioButton38";
            this.radioButton38.Size = new System.Drawing.Size(39, 18);
            this.radioButton38.TabIndex = 2;
            this.radioButton38.TabStop = true;
            this.radioButton38.Text = "  ";
            this.radioButton38.UseVisualStyleBackColor = true;
            // 
            // radioButton39
            // 
            this.radioButton39.AutoSize = true;
            this.radioButton39.Location = new System.Drawing.Point(16, 5);
            this.radioButton39.Name = "radioButton39";
            this.radioButton39.Size = new System.Drawing.Size(46, 18);
            this.radioButton39.TabIndex = 0;
            this.radioButton39.TabStop = true;
            this.radioButton39.Text = "   ";
            this.radioButton39.UseVisualStyleBackColor = true;
            // 
            // radioButton40
            // 
            this.radioButton40.AutoSize = true;
            this.radioButton40.Location = new System.Drawing.Point(118, 5);
            this.radioButton40.Name = "radioButton40";
            this.radioButton40.Size = new System.Drawing.Size(39, 18);
            this.radioButton40.TabIndex = 1;
            this.radioButton40.TabStop = true;
            this.radioButton40.Text = "  ";
            this.radioButton40.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Location = new System.Drawing.Point(476, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 28);
            this.panel2.TabIndex = 2;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(422, 4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(39, 18);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "  ";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(323, 5);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(39, 18);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "  ";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(223, 5);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(39, 18);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "  ";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "   ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(118, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "  ";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // OldPeopleMedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1274, 640);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "OldPeopleMedForm";
            this.Text = "OldPeopleMedForm";
            this.panel1.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.CurX = e.X;
            this.CurY = e.Y;
            this.Mousedown = true;
            Cursor.Current = Cursors.Hand;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Mousedown)
            {
                Console.WriteLine(e.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Mousedown = false;
            Cursor.Current = Cursors.Default;
        }

        public bool SaveModelToDB()
        {
            return true;
        }

        public void UpdataToModel()
        {
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }
    }
}

