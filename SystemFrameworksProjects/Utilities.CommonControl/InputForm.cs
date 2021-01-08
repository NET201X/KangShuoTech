namespace KangShuoTech.Utilities.CommonControl
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO.Ports;
    using System.Text;
    using System.Windows.Forms;

    public class InputForm : Form
    {
        public bool CanBeNull = true;
        private string caption = "";
        private ComboBox comboBox1;
        private IContainer components;
        private string input = "";
        private Label label1;
        private Label label2;
        private Label lbResult;
        private int maxBytesCount;
        private TextBox textBox1;

        public InputForm()
        {
            this.InitializeComponent();
            this.ErrorInput = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = this.comboBox1.Text;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            this.label2.Text = this.caption;
            this.textBox1.Text = this.input;
            if (this.caption == "请输入LCD通信串口号:")
            {
                List<string> registData = this.GetRegistData();
                foreach (string str in SerialPort.GetPortNames())
                {
                    bool flag = false;
                    for (int i = 0; i < registData.Count; i++)
                    {
                        if (str == registData[i])
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        this.comboBox1.Items.Add(str);
                    }
                }
                this.comboBox1.Visible = true;
                this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            }
        }

        public List<string> GetRegistData()
        {
            List<string> list = new List<string>();
            RegistryKey key = Registry.LocalMachine.OpenSubKey("HARDWARE", true).OpenSubKey("DEVICEMAP", true).OpenSubKey("SERIALCOMM", true);
            string[] valueNames = key.GetValueNames();
            for (int i = 0; i < valueNames.Length; i++)
            {
                if (valueNames[i].Contains("BthModem"))
                {
                    list.Add(key.GetValue(valueNames[i]).ToString());
                }
            }
            return list;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(192, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 38);
            this.label1.TabIndex = 90;
            this.label1.Text = "  确 定  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(133, 102);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 68);
            this.textBox1.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(112, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 38);
            this.label2.TabIndex = 92;
            this.label2.Text = "请输入地区信息：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbResult
            // 
            this.lbResult.BackColor = System.Drawing.Color.White;
            this.lbResult.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbResult.ForeColor = System.Drawing.Color.Black;
            this.lbResult.Location = new System.Drawing.Point(353, 96);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(116, 38);
            this.lbResult.TabIndex = 93;
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(133, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 24);
            this.comboBox1.TabIndex = 94;
            this.comboBox1.Visible = false;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = Properties.Resources.picSaved_Image;
            this.ClientSize = new System.Drawing.Size(481, 263);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!this.CanBeNull && (this.textBox1.Text.Trim() == ""))
            {
                this.lbResult.Text = "不能为空!";
                this.lbResult.ForeColor = System.Drawing.Color.Red;
            }
            else if (this.ErrorInput)
            {
                this.lbResult.Text = "输入有误!";
            }
            else
            {
                this.input = this.textBox1.Text;
                base.DialogResult = DialogResult.OK;
            }
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.textBox1.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.textBox1.BackColor = System.Drawing.Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        public bool ErrorInput { get; set; }

        public string InputString
        {
            get
            {
                return this.input;
            }
            set
            {
                this.input = value;
            }
        }

        public int MaxBytesCount
        {
            get
            {
                return this.maxBytesCount;
            }
            set
            {
                if (value > 0)
                {
                    this.maxBytesCount = value;
                    this.textBox1.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public string MCaption
        {
            set
            {
                this.caption = value;
            }
        }
    }
}

