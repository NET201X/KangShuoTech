namespace FocusGroup
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Timers;
    using System.Windows.Forms;

    public class TestForm : Form
    {
        private Button btnDown;
        private Button btnUp;
        private Button button1;
        private Button button2;
        private Button button3;
        private CheckBox checkBox1;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private CheckBox checkBox14;
        private CheckBox checkBox15;
        private CheckBox checkBox16;
        private CheckBox checkBox17;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private IContainer components;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label40;
        private Label label41;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label80;
        private Label label81;
        private Label label9;
        private int m_top;
        private bool on_status;
        private Panel panel1;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Panel panel17;
        private Panel panel18;
        private Panel panel2;
        private Panel panel21;
        private Panel panel22;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Point point_ed;
        private Point point_st;
        private Point position = new Point(0, 0);
        private RadioButton radioButton1;
        private RadioButton radioButton10;
        private RadioButton radioButton11;
        private RadioButton radioButton12;
        private RadioButton radioButton13;
        private RadioButton radioButton14;
        private RadioButton radioButton15;
        private RadioButton radioButton16;
        private RadioButton radioButton17;
        private RadioButton radioButton18;
        private RadioButton radioButton2;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private RadioButton radioButton9;
        private int step = 10;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbAge;
        private TextBox tbArchiveid;
        private TextBox tbHusbandName;
        private TextBox tbHusbandPhone;
        private TextBox tbIDCARD;
        private TextBox tbName;
        private TextBox textBox1;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox2;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox52;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private System.Timers.Timer time_up;
        private System.Timers.Timer timer_down;

        public TestForm()
        {
            this.InitializeComponent();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.timer_down == null)
            {
                this.timer_down = new System.Timers.Timer(10.0);
                this.timer_down.Elapsed += new ElapsedEventHandler(this.timer_down_Elapsed);
            }
            this.timer_down.Start();
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.timer_down != null)
            {
                this.timer_down.Stop();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.time_up == null)
            {
                this.time_up = new System.Timers.Timer(10.0);
                this.time_up.Elapsed += new ElapsedEventHandler(this.time_up_Elapsed);
            }
            this.time_up.Start();
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.time_up != null)
            {
                this.time_up.Stop();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label81 = new System.Windows.Forms.Label();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHusbandPhone = new System.Windows.Forms.TextBox();
            this.tbHusbandName = new System.Windows.Forms.TextBox();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbArchiveid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbIDCARD = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel22.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 585);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(989, 560);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 111;
            this.button3.Text = "下一页";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(890, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 110;
            this.button1.Text = "上一页";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(1074, 298);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(56, 53);
            this.btnDown.TabIndex = 109;
            this.btnDown.Text = "下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(1074, 239);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 53);
            this.btnUp.TabIndex = 108;
            this.btnUp.Text = "上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tableLayoutPanel1);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.tbIDCARD);
            this.panel6.Location = new System.Drawing.Point(99, 15);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(969, 535);
            this.panel6.TabIndex = 107;
            this.panel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseDown);
            this.panel6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseMove);
            this.panel6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44778F));
            this.tableLayoutPanel1.Controls.Add(this.panel21, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label80, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbHusbandPhone, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbHusbandName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbAge, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label26, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label24, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label25, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBox12, 5, 9);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label28, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label29, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbArchiveid, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 466);
            this.tableLayoutPanel1.TabIndex = 106;
            // 
            // panel21
            // 
            this.panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel21.Controls.Add(this.label81);
            this.panel21.Controls.Add(this.textBox52);
            this.panel21.Location = new System.Drawing.Point(748, 1);
            this.panel21.Margin = new System.Windows.Forms.Padding(0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(181, 30);
            this.panel21.TabIndex = 167;
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label81.Location = new System.Drawing.Point(145, 8);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(21, 14);
            this.label81.TabIndex = 145;
            this.label81.Text = "周";
            // 
            // textBox52
            // 
            this.textBox52.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox52.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox52.ForeColor = System.Drawing.Color.Black;
            this.textBox52.Location = new System.Drawing.Point(5, 4);
            this.textBox52.MaxLength = 3;
            this.textBox52.Multiline = true;
            this.textBox52.Name = "textBox52";
            this.textBox52.ReadOnly = true;
            this.textBox52.Size = new System.Drawing.Size(140, 23);
            this.textBox52.TabIndex = 111;
            // 
            // label80
            // 
            this.label80.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(674, 9);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(70, 14);
            this.label80.TabIndex = 167;
            this.label80.Text = "填表孕周:";
            // 
            // panel15
            // 
            this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel15, 5);
            this.panel15.Controls.Add(this.panel8);
            this.panel15.Controls.Add(this.panel9);
            this.panel15.Controls.Add(this.panel13);
            this.panel15.Controls.Add(this.panel17);
            this.panel15.Controls.Add(this.panel18);
            this.panel15.Location = new System.Drawing.Point(130, 373);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.tableLayoutPanel1.SetRowSpan(this.panel15, 3);
            this.panel15.Size = new System.Drawing.Size(799, 92);
            this.panel15.TabIndex = 167;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.radioButton5);
            this.panel8.Controls.Add(this.radioButton6);
            this.panel8.Controls.Add(this.textBox14);
            this.panel8.Controls.Add(this.label34);
            this.panel8.Location = new System.Drawing.Point(3, 63);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(379, 28);
            this.panel8.TabIndex = 118;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(138, 5);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(47, 16);
            this.radioButton5.TabIndex = 150;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "异常";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(51, 5);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(71, 16);
            this.radioButton6.TabIndex = 149;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "未见异常";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // textBox14
            // 
            this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox14.ForeColor = System.Drawing.Color.Black;
            this.textBox14.Location = new System.Drawing.Point(197, 2);
            this.textBox14.MaxLength = 20;
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(172, 23);
            this.textBox14.TabIndex = 111;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(3, 7);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(42, 14);
            this.label34.TabIndex = 147;
            this.label34.Text = "附件:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.radioButton11);
            this.panel9.Controls.Add(this.radioButton12);
            this.panel9.Controls.Add(this.textBox21);
            this.panel9.Controls.Add(this.label38);
            this.panel9.Location = new System.Drawing.Point(417, 32);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(379, 28);
            this.panel9.TabIndex = 117;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(138, 5);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(47, 16);
            this.radioButton11.TabIndex = 150;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "异常";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(51, 5);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(71, 16);
            this.radioButton12.TabIndex = 149;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "未见异常";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // textBox21
            // 
            this.textBox21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox21.ForeColor = System.Drawing.Color.Black;
            this.textBox21.Location = new System.Drawing.Point(197, 2);
            this.textBox21.MaxLength = 20;
            this.textBox21.Multiline = true;
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(172, 23);
            this.textBox21.TabIndex = 111;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(3, 7);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(42, 14);
            this.label38.TabIndex = 147;
            this.label38.Text = "子宫:";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.radioButton13);
            this.panel13.Controls.Add(this.radioButton14);
            this.panel13.Controls.Add(this.textBox22);
            this.panel13.Controls.Add(this.label39);
            this.panel13.Location = new System.Drawing.Point(3, 32);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(379, 28);
            this.panel13.TabIndex = 116;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(138, 5);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(47, 16);
            this.radioButton13.TabIndex = 150;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "异常";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(51, 5);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(71, 16);
            this.radioButton14.TabIndex = 149;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "未见异常";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // textBox22
            // 
            this.textBox22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox22.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox22.ForeColor = System.Drawing.Color.Black;
            this.textBox22.Location = new System.Drawing.Point(197, 2);
            this.textBox22.MaxLength = 20;
            this.textBox22.Multiline = true;
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(172, 23);
            this.textBox22.TabIndex = 111;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(3, 7);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(42, 14);
            this.label39.TabIndex = 147;
            this.label39.Text = "宫颈:";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.radioButton15);
            this.panel17.Controls.Add(this.radioButton16);
            this.panel17.Controls.Add(this.textBox23);
            this.panel17.Controls.Add(this.label40);
            this.panel17.Location = new System.Drawing.Point(417, 1);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(379, 28);
            this.panel17.TabIndex = 115;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(138, 5);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(47, 16);
            this.radioButton15.TabIndex = 150;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "异常";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(51, 5);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(71, 16);
            this.radioButton16.TabIndex = 149;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "未见异常";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // textBox23
            // 
            this.textBox23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox23.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox23.ForeColor = System.Drawing.Color.Black;
            this.textBox23.Location = new System.Drawing.Point(197, 2);
            this.textBox23.MaxLength = 20;
            this.textBox23.Multiline = true;
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(172, 23);
            this.textBox23.TabIndex = 111;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(3, 7);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 14);
            this.label40.TabIndex = 147;
            this.label40.Text = "阴道:";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.radioButton17);
            this.panel18.Controls.Add(this.radioButton18);
            this.panel18.Controls.Add(this.textBox24);
            this.panel18.Controls.Add(this.label41);
            this.panel18.Location = new System.Drawing.Point(3, 1);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(379, 28);
            this.panel18.TabIndex = 114;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(138, 5);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(47, 16);
            this.radioButton17.TabIndex = 150;
            this.radioButton17.TabStop = true;
            this.radioButton17.Text = "异常";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.Location = new System.Drawing.Point(51, 5);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(71, 16);
            this.radioButton18.TabIndex = 149;
            this.radioButton18.TabStop = true;
            this.radioButton18.Text = "未见异常";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // textBox24
            // 
            this.textBox24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox24.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox24.ForeColor = System.Drawing.Color.Black;
            this.textBox24.Location = new System.Drawing.Point(197, 2);
            this.textBox24.MaxLength = 20;
            this.textBox24.Multiline = true;
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(172, 23);
            this.textBox24.TabIndex = 111;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(3, 7);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(42, 14);
            this.label41.TabIndex = 147;
            this.label41.Text = "外阴:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 2);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.label32);
            this.panel7.Controls.Add(this.textBox13);
            this.panel7.Location = new System.Drawing.Point(130, 311);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(308, 30);
            this.panel7.TabIndex = 111;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 23);
            this.button2.TabIndex = 146;
            this.button2.Text = ".....";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(150, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 14);
            this.label32.TabIndex = 145;
            this.label32.Text = "mmhg";
            // 
            // textBox13
            // 
            this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox13.ForeColor = System.Drawing.Color.Black;
            this.textBox13.Location = new System.Drawing.Point(3, 2);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(141, 23);
            this.textBox13.TabIndex = 111;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.textBox11);
            this.panel5.Location = new System.Drawing.Point(439, 280);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(179, 30);
            this.panel5.TabIndex = 109;
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(152, 8);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(21, 14);
            this.label31.TabIndex = 145;
            this.label31.Text = "㎏";
            // 
            // textBox11
            // 
            this.textBox11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox11.ForeColor = System.Drawing.Color.Black;
            this.textBox11.Location = new System.Drawing.Point(4, 4);
            this.textBox11.MaxLength = 6;
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(140, 23);
            this.textBox11.TabIndex = 111;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label30);
            this.panel4.Controls.Add(this.textBox18);
            this.panel4.Location = new System.Drawing.Point(130, 280);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(179, 30);
            this.panel4.TabIndex = 108;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(152, 8);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(21, 14);
            this.label30.TabIndex = 145;
            this.label30.Text = "㎝";
            // 
            // textBox18
            // 
            this.textBox18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox18.ForeColor = System.Drawing.Color.Black;
            this.textBox18.Location = new System.Drawing.Point(4, 4);
            this.textBox18.MaxLength = 3;
            this.textBox18.Multiline = true;
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(140, 23);
            this.textBox18.TabIndex = 111;
            // 
            // flowLayoutPanel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel3, 5);
            this.flowLayoutPanel3.Controls.Add(this.checkBox1);
            this.flowLayoutPanel3.Controls.Add(this.checkBox2);
            this.flowLayoutPanel3.Controls.Add(this.checkBox3);
            this.flowLayoutPanel3.Controls.Add(this.textBox17);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(130, 156);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(799, 29);
            this.flowLayoutPanel3.TabIndex = 109;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "遗传性疾病史";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(105, 8);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "精神病疾病史";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(207, 8);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "其他";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox17.ForeColor = System.Drawing.Color.Black;
            this.textBox17.Location = new System.Drawing.Point(261, 3);
            this.textBox17.MaxLength = 20;
            this.textBox17.Multiline = true;
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(174, 21);
            this.textBox17.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(56, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 160;
            this.label2.Text = "既 往 史:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(442, 97);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(173, 21);
            this.dateTimePicker2.TabIndex = 107;
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 5);
            this.flowLayoutPanel2.Controls.Add(this.checkBox7);
            this.flowLayoutPanel2.Controls.Add(this.checkBox8);
            this.flowLayoutPanel2.Controls.Add(this.checkBox9);
            this.flowLayoutPanel2.Controls.Add(this.checkBox10);
            this.flowLayoutPanel2.Controls.Add(this.checkBox11);
            this.flowLayoutPanel2.Controls.Add(this.checkBox12);
            this.flowLayoutPanel2.Controls.Add(this.checkBox13);
            this.flowLayoutPanel2.Controls.Add(this.checkBox14);
            this.flowLayoutPanel2.Controls.Add(this.textBox15);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(130, 125);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(799, 29);
            this.flowLayoutPanel2.TabIndex = 107;
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(3, 8);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(36, 16);
            this.checkBox7.TabIndex = 0;
            this.checkBox7.Text = "无";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(45, 8);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(66, 16);
            this.checkBox8.TabIndex = 1;
            this.checkBox8.Text = "2心脏病";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(117, 8);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(78, 16);
            this.checkBox9.TabIndex = 2;
            this.checkBox9.Text = "3肾脏疾病";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(201, 8);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(78, 16);
            this.checkBox10.TabIndex = 3;
            this.checkBox10.Text = "4肝脏疾病";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(285, 8);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(66, 16);
            this.checkBox11.TabIndex = 4;
            this.checkBox11.Text = "5高血压";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(357, 8);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(54, 16);
            this.checkBox12.TabIndex = 5;
            this.checkBox12.Text = "6贫血";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(417, 8);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(66, 16);
            this.checkBox13.TabIndex = 6;
            this.checkBox13.Text = "7糖尿病";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(489, 8);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(54, 16);
            this.checkBox14.TabIndex = 7;
            this.checkBox14.Text = "8其他";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox15.ForeColor = System.Drawing.Color.Black;
            this.textBox15.Location = new System.Drawing.Point(549, 3);
            this.textBox15.MaxLength = 20;
            this.textBox15.Multiline = true;
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(174, 21);
            this.textBox15.TabIndex = 107;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(133, 97);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(173, 21);
            this.dateTimePicker1.TabIndex = 106;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(439, 63);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 29);
            this.panel2.TabIndex = 106;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(357, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 14);
            this.label20.TabIndex = 152;
            this.label20.Text = "次";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(312, 3);
            this.textBox3.MaxLength = 2;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(39, 21);
            this.textBox3.TabIndex = 150;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(249, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 14);
            this.label21.TabIndex = 151;
            this.label21.Text = "刨宫产:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(128, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 14);
            this.label18.TabIndex = 149;
            this.label18.Text = "次";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(83, 3);
            this.textBox2.MaxLength = 2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(39, 21);
            this.textBox2.TabIndex = 142;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(7, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 148;
            this.label12.Text = "阴道分娩:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(133, 67);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 21);
            this.textBox1.TabIndex = 151;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(365, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 135;
            this.label10.Text = "产    次:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(56, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 112;
            this.label4.Text = "丈夫姓名:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(365, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 111;
            this.label16.Text = "丈夫年龄:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(674, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 133;
            this.label5.Text = "丈夫电话:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(56, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 134;
            this.label6.Text = "孕    次:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(56, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 129;
            this.label7.Text = "末次月经:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(365, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 128;
            this.label1.Text = "预 产 期:";
            // 
            // tbHusbandPhone
            // 
            this.tbHusbandPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandPhone.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandPhone.Location = new System.Drawing.Point(442, 36);
            this.tbHusbandPhone.MaxLength = 3;
            this.tbHusbandPhone.Name = "tbHusbandPhone";
            this.tbHusbandPhone.Size = new System.Drawing.Size(173, 21);
            this.tbHusbandPhone.TabIndex = 144;
            // 
            // tbHusbandName
            // 
            this.tbHusbandName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHusbandName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHusbandName.ForeColor = System.Drawing.Color.Black;
            this.tbHusbandName.Location = new System.Drawing.Point(133, 36);
            this.tbHusbandName.MaxLength = 15;
            this.tbHusbandName.Name = "tbHusbandName";
            this.tbHusbandName.Size = new System.Drawing.Size(173, 21);
            this.tbHusbandName.TabIndex = 143;
            // 
            // tbAge
            // 
            this.tbAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAge.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAge.ForeColor = System.Drawing.Color.Black;
            this.tbAge.Location = new System.Drawing.Point(751, 36);
            this.tbAge.MaxLength = 15;
            this.tbAge.Name = "tbAge";
            this.tbAge.ReadOnly = true;
            this.tbAge.Size = new System.Drawing.Size(173, 21);
            this.tbAge.TabIndex = 132;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(56, 319);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 14);
            this.label26.TabIndex = 157;
            this.label26.Text = "血    压:";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(56, 288);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 14);
            this.label24.TabIndex = 135;
            this.label24.Text = "身    高:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(365, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 153;
            this.label9.Text = "体    重:";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(674, 288);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 14);
            this.label25.TabIndex = 155;
            this.label25.Text = "体质指数:";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox12.ForeColor = System.Drawing.Color.Black;
            this.textBox12.Location = new System.Drawing.Point(751, 283);
            this.textBox12.MaxLength = 6;
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(173, 21);
            this.textBox12.TabIndex = 156;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(42, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 14);
            this.label11.TabIndex = 147;
            this.label11.Text = "妇科手术史:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 5);
            this.panel3.Controls.Add(this.textBox9);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.textBox8);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(130, 249);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 30);
            this.panel3.TabIndex = 152;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox9.ForeColor = System.Drawing.Color.Black;
            this.textBox9.Location = new System.Drawing.Point(542, 3);
            this.textBox9.MaxLength = 2;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(39, 21);
            this.textBox9.TabIndex = 151;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(445, 7);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 14);
            this.label23.TabIndex = 150;
            this.label23.Text = "5初生儿缺陷";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox8.ForeColor = System.Drawing.Color.Black;
            this.textBox8.Location = new System.Drawing.Point(400, 3);
            this.textBox8.MaxLength = 2;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(39, 21);
            this.textBox8.TabIndex = 149;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(303, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 14);
            this.label22.TabIndex = 148;
            this.label22.Text = "4新生儿死亡:";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox7.ForeColor = System.Drawing.Color.Black;
            this.textBox7.Location = new System.Drawing.Point(258, 3);
            this.textBox7.MaxLength = 2;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(39, 21);
            this.textBox7.TabIndex = 147;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(203, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 14);
            this.label19.TabIndex = 146;
            this.label19.Text = "3死产:";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox6.ForeColor = System.Drawing.Color.Black;
            this.textBox6.Location = new System.Drawing.Point(158, 3);
            this.textBox6.MaxLength = 2;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(39, 21);
            this.textBox6.TabIndex = 145;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(103, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 14);
            this.label17.TabIndex = 144;
            this.label17.Text = "2死胎:";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox5.ForeColor = System.Drawing.Color.Black;
            this.textBox5.Location = new System.Drawing.Point(58, 3);
            this.textBox5.MaxLength = 2;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(39, 21);
            this.textBox5.TabIndex = 143;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(3, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 129;
            this.label14.Text = "1流产:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(42, 226);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 14);
            this.label15.TabIndex = 146;
            this.label15.Text = "妇科手术史:";
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel11, 2);
            this.panel11.Controls.Add(this.textBox4);
            this.panel11.Controls.Add(this.radioButton2);
            this.panel11.Controls.Add(this.radioButton1);
            this.panel11.Location = new System.Drawing.Point(130, 218);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(308, 30);
            this.panel11.TabIndex = 107;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(131, 2);
            this.textBox4.MaxLength = 20;
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(174, 23);
            this.textBox4.TabIndex = 111;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(65, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(35, 16);
            this.radioButton2.TabIndex = 110;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "有";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 16);
            this.radioButton1.TabIndex = 109;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "无";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(56, 164);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 161;
            this.label28.Text = "家 族 史:";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(56, 195);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 14);
            this.label29.TabIndex = 162;
            this.label29.Text = "个 人 史:";
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 5);
            this.flowLayoutPanel1.Controls.Add(this.checkBox4);
            this.flowLayoutPanel1.Controls.Add(this.checkBox5);
            this.flowLayoutPanel1.Controls.Add(this.checkBox6);
            this.flowLayoutPanel1.Controls.Add(this.checkBox15);
            this.flowLayoutPanel1.Controls.Add(this.checkBox16);
            this.flowLayoutPanel1.Controls.Add(this.checkBox17);
            this.flowLayoutPanel1.Controls.Add(this.textBox16);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(130, 187);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(799, 29);
            this.flowLayoutPanel1.TabIndex = 163;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(3, 8);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "吸烟";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(57, 8);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(48, 16);
            this.checkBox5.TabIndex = 1;
            this.checkBox5.Text = "饮酒";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(111, 8);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(72, 16);
            this.checkBox6.TabIndex = 2;
            this.checkBox6.Text = "服用药物";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(189, 8);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(120, 16);
            this.checkBox15.TabIndex = 3;
            this.checkBox15.Text = "接触有毒有害物质";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(315, 8);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(84, 16);
            this.checkBox16.TabIndex = 4;
            this.checkBox16.Text = "接触放射线";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(405, 8);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(48, 16);
            this.checkBox17.TabIndex = 5;
            this.checkBox17.Text = "其他";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox16.ForeColor = System.Drawing.Color.Black;
            this.textBox16.Location = new System.Drawing.Point(459, 3);
            this.textBox16.MaxLength = 20;
            this.textBox16.Multiline = true;
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(174, 21);
            this.textBox16.TabIndex = 107;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(56, 350);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(70, 14);
            this.label33.TabIndex = 164;
            this.label33.Text = "听    诊:";
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(4, 378);
            this.label35.Name = "label35";
            this.tableLayoutPanel1.SetRowSpan(this.label35, 3);
            this.label35.Size = new System.Drawing.Size(122, 82);
            this.label35.TabIndex = 165;
            this.label35.Text = "妇科检查:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel14
            // 
            this.panel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel14, 5);
            this.panel14.Controls.Add(this.panel12);
            this.panel14.Controls.Add(this.panel22);
            this.panel14.Location = new System.Drawing.Point(130, 342);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(799, 30);
            this.panel14.TabIndex = 166;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.radioButton7);
            this.panel12.Controls.Add(this.radioButton8);
            this.panel12.Controls.Add(this.textBox19);
            this.panel12.Controls.Add(this.label36);
            this.panel12.Location = new System.Drawing.Point(417, 1);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(379, 28);
            this.panel12.TabIndex = 109;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(138, 5);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(47, 16);
            this.radioButton7.TabIndex = 150;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "异常";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(51, 5);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(71, 16);
            this.radioButton8.TabIndex = 149;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "未见异常";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // textBox19
            // 
            this.textBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox19.ForeColor = System.Drawing.Color.Black;
            this.textBox19.Location = new System.Drawing.Point(197, 2);
            this.textBox19.MaxLength = 20;
            this.textBox19.Multiline = true;
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(172, 23);
            this.textBox19.TabIndex = 111;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(3, 7);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(42, 14);
            this.label36.TabIndex = 147;
            this.label36.Text = "肺部:";
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.radioButton9);
            this.panel22.Controls.Add(this.radioButton10);
            this.panel22.Controls.Add(this.textBox20);
            this.panel22.Controls.Add(this.label37);
            this.panel22.Location = new System.Drawing.Point(3, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(379, 28);
            this.panel22.TabIndex = 108;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(138, 5);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(47, 16);
            this.radioButton9.TabIndex = 150;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "异常";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(51, 5);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(71, 16);
            this.radioButton10.TabIndex = 149;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "未见异常";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // textBox20
            // 
            this.textBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox20.ForeColor = System.Drawing.Color.Black;
            this.textBox20.Location = new System.Drawing.Point(197, 2);
            this.textBox20.MaxLength = 20;
            this.textBox20.Multiline = true;
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(172, 23);
            this.textBox20.TabIndex = 111;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(3, 7);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(42, 14);
            this.label37.TabIndex = 147;
            this.label37.Text = "心脏:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(56, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 100;
            this.label13.Text = "填表日期:";
            // 
            // tbArchiveid
            // 
            this.tbArchiveid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbArchiveid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbArchiveid.ForeColor = System.Drawing.Color.Black;
            this.tbArchiveid.Location = new System.Drawing.Point(133, 5);
            this.tbArchiveid.MaxLength = 30;
            this.tbArchiveid.Name = "tbArchiveid";
            this.tbArchiveid.ReadOnly = true;
            this.tbArchiveid.Size = new System.Drawing.Size(173, 21);
            this.tbArchiveid.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(365, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 101;
            this.label3.Text = "孕妇年龄:";
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(442, 5);
            this.tbName.MaxLength = 2;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(173, 21);
            this.tbName.TabIndex = 131;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(16, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 129;
            this.label8.Text = "姓    名:";
            // 
            // tbIDCARD
            // 
            this.tbIDCARD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbIDCARD.ForeColor = System.Drawing.Color.Black;
            this.tbIDCARD.Location = new System.Drawing.Point(91, 8);
            this.tbIDCARD.Name = "tbIDCARD";
            this.tbIDCARD.ReadOnly = true;
            this.tbIDCARD.Size = new System.Drawing.Size(173, 21);
            this.tbIDCARD.TabIndex = 135;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 609);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "TestForm";
            this.Text = "FrmTest";
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.ResumeLayout(false);

        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            this.point_st = e.Location;
            this.on_status = true;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.on_status)
            {
                this.point_ed = e.Location;
                this.panel6.Top += this.point_ed.Y - this.point_st.Y;
            }
        }

        private void panel6_MouseUp(object sender, MouseEventArgs e)
        {
            this.on_status = false;
        }

        private void SetPanel6_Top(int p_top)
        {
            Action<int> method = new Action<int>(this.SetPanel6_Top);
            if (this.panel6.InvokeRequired)
            {
                this.panel6.Invoke(method, new object[] { p_top });
            }
            else
            {
                this.panel6.Top = p_top;
                this.label8.Text = p_top.ToString();
            }
        }

        private void time_up_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.m_top++;
            if (this.m_top >= 0)
            {
                this.m_top = 0;
            }
            else
            {
                this.SetPanel6_Top(this.m_top);
            }
        }

        private void timer_down_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.m_top--;
            if (this.m_top <= (this.panel1.Height - this.panel6.Height))
            {
                this.m_top = this.panel1.Height - this.panel6.Height;
            }
            else
            {
                this.SetPanel6_Top(this.m_top);
            }
        }
    }
}

