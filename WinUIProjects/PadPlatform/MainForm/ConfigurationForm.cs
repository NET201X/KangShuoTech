using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using KangShuoTech.Utilities.Common;

namespace KangShuo
{
    public class ConfigurationForm : Form
    {
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private Button btnSetLogo;
        private ComboBox cbxCom;
        private ComboBox cbxSixPar;
        private List<CfgDescribe> cfgDess;
        private CheckBox checkBox1;
        private IContainer components;
        private XmlDocument document;
        private string file;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private string input = "";
        private List<CfgItem> listCfg;
        private XmlNode root;
        private TextBox tbInfo;
        private TextBox tbName;
        private TextBox tbValue;
        private TextBox textBox1;
        private TextBox textBox2;

        public ConfigurationForm()
        {
            this.InitializeComponent();
            this.cfgDess = new List<CfgDescribe>();
            CfgDescribe item = new CfgDescribe("ftpUpAddress", "ftp上传地址", true) {
                DisplayText = "ftp地址"
            };
            this.cfgDess.Add(item);
            CfgDescribe describe2 = new CfgDescribe("ftpUser", "ftp上传账号", true) {
                DisplayText = "ftp帐号"
            };
            this.cfgDess.Add(describe2);
            CfgDescribe describe3 = new CfgDescribe("ftpPwd", "ftp上传密码", true) {
                DisplayText = "ftp密码"
            };
            this.cfgDess.Add(describe3);
            CfgDescribe describe4 = new CfgDescribe("ProVersion", "产品版本，发往地区", true) {
                DisplayText = "产品版本"
            };
            this.cfgDess.Add(describe4);
            CfgDescribe describe5 = new CfgDescribe("isUpdate", "是否启用远程升级,1启用,0不启用") {
                DisplayText = "远程升级"
            };
            this.cfgDess.Add(describe5);
        }

        private void btnBT_Click(object sender, EventArgs e)
        {
            new BTForm() { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将清空数据库中的所有数据和身份证验证系统中的数据，此操作不可逆！", "清空", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (File.Exists(Application.StartupPath + @"\wz.txt"))
                {
                    File.Delete(Application.StartupPath + @"\wz.txt");
                }
                if (File.Exists(Application.StartupPath + @"\zp.bmp"))
                {
                    File.Delete(Application.StartupPath + @"\zp.bmp");
                }
                if (File.Exists(Application.StartupPath + @"\wx.txt"))
                {
                    File.Delete(Application.StartupPath + @"\wx.txt");
                }
                string node = ConfigHelper.GetNode("anyview");
                try
                {
                    if (File.Exists(node))
                    {
                        File.Delete(node);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("删除" + node + "失败!");
                    LogHelper.LogError(exception);
                }
                try
                {
                    
                }
                catch (Exception exception2)
                {
                    LogHelper.LogError(exception2);
                }
                if (File.Exists(@"C:\Program Files\神思二代证\wz.txt"))
                {
                    File.Delete(@"C:\Program Files\神思二代证\wz.txt");
                }
                if (File.Exists(@"C:\Program Files\神思二代证\zp.bmp"))
                {
                    File.Delete(@"C:\Program Files\神思二代证\zp.bmp");
                }
                if (File.Exists(@"C:\Program Files\神思二代证\wx.txt"))
                {
                    File.Delete(@"C:\Program Files\神思二代证\wx.txt");
                }
                this.tbInfo.Text = "清理成功,程序将退出!";
                Thread.Sleep(0xbb8);
            }
        }

        private void btnLCD_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.listCfg.Count<CfgItem>(x => x.ErrorInput) <= 0)
            {
                foreach (CfgItem item in this.listCfg)
                {
                    item.SaveChange();
                }
                this.document.Save(this.file);
                if (!string.IsNullOrEmpty(this.cbxCom.Text))
                {
                    ConfigHelper.WriteNode("useLCD", "1");
                    ConfigHelper.WriteNode("comPort", this.cbxCom.Text);
                }
                else
                {
                    ConfigHelper.WriteNode("useLCD", "0");
                }
                if (!string.IsNullOrEmpty(this.cbxSixPar.Text))
                {
                    string str = "";
                    if (this.cbxSixPar.Text.Contains("永康"))
                    {
                        str = "EcgServer.exe";
                    }
                    else if (this.cbxSixPar.Text.Contains("爱德康"))
                    {
                        str = "EcgServer_ADECON.exe";
                    }
                    ConfigHelper.WriteNode("SixParameters", str);
                }
                MessageBox.Show("保存成功！", "配置", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btnSetLogo_Click(object sender, EventArgs e)
        {
            new EditLogoForm().ShowDialog();
        }

        private void cbxCom_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = this.checkBox1.Checked;
            for (int i = 0; i < this.listCfg.Count; i++)
            {
                this.listCfg[i].ReadOnly = !flag;
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

        private void FrmSetUp_KeyUp(object sender, KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode != Keys.F17)
            {
                if (keyCode != Keys.F23)
                {
                    return;
                }
            }
            else
            {
                this.btnSave.PerformClick();
                return;
            }
            this.btnCancel.PerformClick();
        }

        private void FrmSetUp_Load(object sender, EventArgs e)
        {
            this.file = ConfigHelper.cfgFileName;
            this.document = new XmlDocument();
            this.document.Load(this.file);
            this.root = this.document.SelectSingleNode("config");
            this.listCfg = new List<CfgItem>();
            string[] portNames = SerialPort.GetPortNames();
            string bthCom = this.GetBthCom();
            foreach (string str2 in portNames)
            {
                if (str2 != bthCom)
                {
                    this.cbxCom.Items.Add(str2);
                }
            }
            string node = ConfigHelper.GetNode("comPort");
            if (string.IsNullOrEmpty(node))
            {
                this.cbxCom.SelectedIndex = -1;
            }
            else
            {
                this.cbxCom.Text = node;
            }
            string str4 = ConfigHelper.GetNode("SixParameters");
            if (string.IsNullOrEmpty(str4))
            {
                this.cbxSixPar.SelectedIndex = 0;
            }
            else
            {
                if (str4 == "EcgServer.exe")
                {
                    this.cbxSixPar.SelectedIndex = 0;
                }
                else if (str4 == "EcgServer_ADECON.exe")
                {
                    this.cbxSixPar.SelectedIndex = 1;
                }
                this.cbxSixPar.Text = str4;
            }
            this.cbxCom.SelectedIndexChanged += new EventHandler(this.cbxCom_SelectedIndexChanged);
            this.flowLayoutPanel1.SuspendLayout();
            //using (IEnumerator enumerator = this.root.ChildNodes.GetEnumerator())
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        XmlNode item = (XmlNode) enumerator.Current;
            //        CfgDescribe describe = this.cfgDess.Find(c => c.Name == item.Name);
            //        if ((describe != null) && describe.CanSee)
            //        {
            //            CfgItem item;
            //            item = new CfgItem(this.tbName, this.tbValue, describe.DisplayText, item, describe.Whats) {
            //                discripInfo = (CfgItem.DiscripInfo) Delegate.Combine(item.discripInfo, new CfgItem.DiscripInfo(this.updateTbInfoText))
            //            };
            //            this.listCfg.Add(item);
            //            this.flowLayoutPanel1.Controls.Add(item.TName);
            //            this.flowLayoutPanel1.Controls.Add(item.TValue);
            //        }
            //    }
            //}
            this.flowLayoutPanel1.ResumeLayout(false);
        }

        private string GetBthCom()
        {
            string str = "";
            RegistryKey key = Registry.LocalMachine.OpenSubKey("HARDWARE", true).OpenSubKey("DEVICEMAP", true).OpenSubKey("SERIALCOMM", true);
            if (key == null)
            {
                return string.Empty;
            }
            string[] valueNames = key.GetValueNames();
            for (int i = 0; i < valueNames.Length; i++)
            {
                if (valueNames[i].Contains("BthModem"))
                {
                    str = key.GetValue(valueNames[i]).ToString();
                }
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.tbName = new TextBox();
            this.tbValue = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.tbInfo = new TextBox();
            this.groupBox1 = new GroupBox();
            this.btnSetLogo = new Button();
            this.cbxSixPar = new ComboBox();
            this.cbxCom = new ComboBox();
            this.btnClear = new Button();
            this.checkBox1 = new CheckBox();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = SystemColors.Window;
            this.flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.tbName);
            this.flowLayoutPanel1.Controls.Add(this.tbValue);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.cbxCom);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Controls.Add(this.cbxSixPar);
            this.flowLayoutPanel1.Location = new Point(6, 0x2a);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(360, 0xed);
            this.flowLayoutPanel1.TabIndex = 0;
            this.tbName.Location = new Point(3, 3);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new Size(0x7e, 0x15);
            this.tbName.TabIndex = 5;
            this.tbName.Text = "配置项";
            this.tbName.TextAlign = HorizontalAlignment.Center;
            this.tbValue.Location = new Point(0x87, 3);
            this.tbValue.Name = "tbValue";
            this.tbValue.ReadOnly = true;
            this.tbValue.Size = new Size(180, 0x15);
            this.tbValue.TabIndex = 4;
            this.tbValue.Text = "值";
            this.tbValue.TextAlign = HorizontalAlignment.Center;
            this.btnSave.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnSave.Location = new Point(0xb3, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x58, 0x1d);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnCancel.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnCancel.Location = new Point(0x116, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x58, 0x1d);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.tbInfo.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.tbInfo.ForeColor = SystemColors.Desktop;
            this.tbInfo.Location = new Point(0x61, 14);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new Size(0x10d, 0x17);
            this.tbInfo.TabIndex = 3;
            this.groupBox1.Controls.Add(this.btnSetLogo);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.tbInfo);
            this.groupBox1.Location = new Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x174, 0x167);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.btnSetLogo.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnSetLogo.Location = new Point(10, 320);
            this.btnSetLogo.Name = "btnSetLogo";
            this.btnSetLogo.Size = new Size(0x8e, 0x1d);
            this.btnSetLogo.TabIndex = 12;
            this.btnSetLogo.Text = "设置标题和Logo";
            this.btnSetLogo.UseVisualStyleBackColor = true;
            this.btnSetLogo.Visible = false;
            this.btnSetLogo.Click += new EventHandler(this.btnSetLogo_Click);
            this.cbxSixPar.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSixPar.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cbxSixPar.FormattingEnabled = true;
            this.cbxSixPar.Items.AddRange(new object[] { "永康多参数仪", "爱德康多参数仪" });
            this.cbxSixPar.Location = new Point(0x87, 0x3a);
            this.cbxSixPar.Name = "cbxSixPar";
            this.cbxSixPar.Size = new Size(180, 0x16);
            this.cbxSixPar.TabIndex = 11;
            this.cbxCom.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxCom.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cbxCom.FormattingEnabled = true;
            this.cbxCom.Location = new Point(0x87, 30);
            this.cbxCom.Name = "cbxCom";
            this.cbxCom.Size = new Size(180, 0x16);
            this.cbxCom.TabIndex = 9;
            this.btnClear.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnClear.Location = new Point(0x116, 0x11d);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(0x55, 0x1d);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清空数据";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.checkBox1.Location = new Point(9, 0x12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x52, 0x12);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "修改配置";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.textBox1.Location = new Point(3, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0x7e, 0x15);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "液晶屏设置";
            this.textBox1.TextAlign = HorizontalAlignment.Center;
            this.textBox2.Location = new Point(3, 0x3a);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(0x7e, 0x15);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "多参数设置";
            this.textBox2.TextAlign = HorizontalAlignment.Center;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x18a, 0x176);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ConfigurationForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            this.Text = "程序配置";
            base.Load += new EventHandler(this.FrmSetUp_Load);
            base.KeyUp += new KeyEventHandler(this.FrmSetUp_KeyUp);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Q:
                case Keys.C:
                case Keys.T:
                    input += keyData.ToString();
                    break;
                case Keys.Return:
                    if (input == "QCT" && !checkBox1.Checked)
                    {
                        //flowLayoutPanel1.SuspendLayout();
                        btnClear.Visible = true;

                        foreach (XmlNode item in root.ChildNodes)
                        {
                            CfgDescribe cfgd = cfgDess.Find(c => { return c.Name == item.Name; });
                            if (cfgd != null && !cfgd.CanSee)
                            {
                                cfgd.CanSee = true;

                                CfgItem cfg = new CfgItem(tbName, tbValue, cfgd.DisplayText, item, cfgd.Whats);
                                cfg.discripInfo += new CfgItem.DiscripInfo(updateTbInfoText);
                                listCfg.Add(cfg);

                                flowLayoutPanel1.Controls.Add(cfg.TName);
                                flowLayoutPanel1.Controls.Add(cfg.TValue);
                            }
                        }
                        //flowLayoutPanel1.ResumeLayout(false);
                    }
                    input = "";
                    break;
                default:
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void updateTbInfoText(CfgItem sender, string info)
        {
            this.tbInfo.Text = info;
            if (sender.Node.Name == "CityNo")
            {
                bool flag1 = this.checkBox1.Checked;
            }
        }

        internal class CfgDescribe
        {
            public CfgDescribe(string n, string w)
            {
                this.Name = n;
                this.Whats = w;
                this.CanSee = false;
            }

            public CfgDescribe(string n, string w, bool c)
            {
                this.Name = n;
                this.Whats = w;
                this.CanSee = c;
            }

            public bool CanSee { get; set; }

            public string DisplayText { get; set; }

            public string Name { get; set; }

            public string Whats { get; set; }
        }

        internal class CfgItem
        {
            public DiscripInfo discripInfo;
            private bool stfff = true;

            public CfgItem(TextBox t1, TextBox t2, string nameDisplay, XmlNode node, string info)
            {
                this.Discription = info;
                this.Node = node;
                this.Changed = false;
                this.TName = new TextBox();
                this.TName.Size = t1.Size;
                this.TName.ReadOnly = true;
                this.TName.Text = nameDisplay;
                this.TName.TextAlign = HorizontalAlignment.Center;
                this.TValue = new TextBox();
                this.TValue.Size = t2.Size;
                this.TValue.TextAlign = HorizontalAlignment.Center;
                if ((node.Name == "ftpUser") || (node.Name == "ftpPwd"))
                {
                    string str = AppHelper.EncryptCode(node.InnerText, 1);
                    node.InnerXml = str;
                }
                this.TValue.DataBindings.Add(new Binding("Text", node, "InnerXml", false, DataSourceUpdateMode.OnPropertyChanged));
                this.TValue.TextChanged += new EventHandler(this.TValue_TextChanged);
                this.TValue.GotFocus += new EventHandler(this.TValue_GotFocus);
                this.CanSee = true;
                this.ReadOnly = true;
            }

            public void SaveChange()
            {
                if ((this.Node.Name == "ftpUser") || (this.Node.Name == "ftpPwd"))
                {
                    this.TValue.TextChanged -= new EventHandler(this.TValue_TextChanged);
                    this.Node.InnerXml = AppHelper.EncryptCode(this.Node.InnerXml, 1);
                }
                if (this.Changed)
                {
                    this.TName.BackColor = System.Drawing.Color.Green;
                    this.TName.Text = this.TName.Text.Trim(new char[] { '*' });
                    this.Changed = false;
                }
            }

            private void TValue_GotFocus(object sender, EventArgs e)
            {
                if (this.discripInfo != null)
                {
                    this.discripInfo(this, this.Discription);
                }
            }

            private void TValue_TextChanged(object sender, EventArgs e)
            {
                if (!this.stfff)
                {
                    this.TName.BackColor = System.Drawing.Color.Yellow;
                    this.TName.Text = this.Node.Name + "*";
                    this.Changed = true;
                }
                this.stfff = false;
                if ((this.Node.Name == "TownNo") || (this.Node.Name == "VillageNo"))
                {
                    if (this.TValue.Text.Length != 3)
                    {
                        this.TValue.BackColor = System.Drawing.Color.Salmon;
                        this.ErrorInput = true;
                    }
                    else
                    {
                        this.TValue.BackColor = System.Drawing.Color.WhiteSmoke;
                        this.ErrorInput = false;
                    }
                }
            }

            public bool CanSee
            {
                get
                {
                    return this.TValue.Visible;
                }
                set
                {
                    this.TName.Visible = value;
                    this.TValue.Visible = value;
                }
            }

            public bool Changed { get; set; }

            public string Discription { get; set; }

            public bool ErrorInput { get; set; }

            public XmlNode Node { get; set; }

            public bool ReadOnly
            {
                set
                {
                    this.TValue.ReadOnly = value;
                    if (this.Node.Name == "CityNo")
                    {
                        this.TValue.ReadOnly = true;
                    }
                }
            }

            public TextBox TName { get; set; }

            public string TNameDisplayText { get; set; }

            public TextBox TValue { get; set; }

            public delegate void DiscripInfo(ConfigurationForm.CfgItem sender, string info);
        }
    }
}

