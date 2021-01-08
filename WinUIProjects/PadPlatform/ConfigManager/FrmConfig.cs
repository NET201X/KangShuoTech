using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using KangShuoTech.Utilities.Common;

namespace ConfigManager
{
    public class FrmConfig : Form
    {
        private Button btnCancel;
        private Button btnSave;
        private ComboBox cbbt;
        private ComboBox cbxSix;
        private CheckedListBox clbDin;
        private CheckedListBox clbFS;
        private DataGridViewTextBoxColumn col_descripe;
        private DataGridViewTextBoxColumn col_name;
        private DataGridViewCheckBoxColumn Column1;
        private IContainer components;
        private DataGridView dataGridView1;
        private XmlDocument document;
        private DataSet ds_whatsup;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbAccountPwd;
        private TextBox tbAutoUpdate;
        private TextBox tbAysSr;
        private TextBox tbDBAdr;
        private TextBox tbFireWall;
        private TextBox tbFtpAdr;
        private TextBox tbRdCard;
        private TextBox tbUpdateNo;
        private TextBox tbUploadAccount;
        private TextBox tbUploadAdr;
        private TextBox tbUploadCheckSr;
        private TextBox textBox1;
        private TextBox textBox11;
        private TextBox textBox13;
        private TextBox textBox15;
        private TextBox textBox17;
        private TextBox textBox19;
        private TextBox textBox2;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox7;
        private TextBox textBox9;
        private TreeView trvSetGroup;

        public FrmConfig()
        {
            this.InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlNode node = this.document.SelectSingleNode("config");
            if (!string.IsNullOrEmpty(this.cbxSix.Text))
            {
                string str = "";
                if (this.cbxSix.Text.Contains("永康"))
                {
                    str = "EcgServer.exe";
                }
                else if (this.cbxSix.Text.Contains("爱德康"))
                {
                    str = "EcgServer_ADECON.exe";
                }
                XmlNode node2 = node.SelectSingleNode("SixParameters");
                if (node2 == null)
                {
                    node2 = this.document.CreateNode("element", "SixParameters", "");
                    node.AppendChild(node2);
                }
                node2.InnerText = str;
            }
            XmlNode newChild = node.SelectSingleNode("BtAutoSave");
            if (newChild == null)
            {
                newChild = this.document.CreateNode("element", "BtAutoSave", "");
                node.AppendChild(newChild);
            }
            newChild.InnerText = (this.cbbt.Text == "") ? "no" : this.cbbt.Text;
            if (AppHelper.EncryptCode(this.tbUploadAccount.Text, 1) != node.SelectSingleNode("ftpUser").InnerText)
            {
                node.SelectSingleNode("ftpUser").InnerText = AppHelper.EncryptCode(this.tbUploadAccount.Text, 1);
            }
            if (AppHelper.EncryptCode(this.tbAccountPwd.Text, 1) != node.SelectSingleNode("ftpPwd").InnerText)
            {
                node.SelectSingleNode("ftpPwd").InnerText = AppHelper.EncryptCode(this.tbAccountPwd.Text, 1);
            }
            string str2 = "";
            for (int i = 0; i < this.clbFS.Items.Count; i++)
            {
                str2 = !this.clbFS.GetItemChecked(i) ? (str2 + "0") : (str2 + "1");
            }
            XmlNode node4 = node.SelectSingleNode("fsset");
            if (node4 == null)
            {
                node4 = this.document.CreateNode("element", "fsset", "");
                node.AppendChild(node4);
            }
            node4.InnerText = str2;
            string str3 = "";
            for (int j = 0; j < this.clbDin.Items.Count; j++)
            {
                str3 = !this.clbDin.GetItemChecked(j) ? (str3 + "0") : (str3 + "1");
            }
            XmlNode node5 = node.SelectSingleNode("ds_modify");
            if (node5 == null)
            {
                node5 = this.document.CreateNode("element", "ds_modify", "");
                node.AppendChild(node5);
            }
            node5.InnerText = str3;
            this.document.Save(ConfigHelper.cfgFileName);
            this.ds_whatsup.WriteXml(Application.StartupPath + @"\input_required.xml");
            MessageBox.Show("保存成功!");
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            this.document = new XmlDocument();
            this.document.Load(ConfigHelper.cfgFileName);
            XmlNode root = this.document.SelectSingleNode("config");
            this.node_binding("versionID", this.tbUpdateNo, root);
            this.node_binding("isUpdate", this.tbAutoUpdate, root);
            this.node_binding("IdCardType", this.tbRdCard, root);
            this.node_binding("FwAgree", this.tbFireWall, root);
            this.node_binding("ftpUpAddress", this.tbUploadAdr, root);
            this.tbUploadAccount.Text = AppHelper.EncryptCode(root.SelectSingleNode("ftpUser").InnerText, 1);
            this.tbAccountPwd.Text = AppHelper.EncryptCode(root.SelectSingleNode("ftpPwd").InnerText, 1);
            string str = (root.SelectSingleNode("SixParameters") == null) ? "" : root.SelectSingleNode("SixParameters").InnerText;
            if (string.IsNullOrEmpty(str))
            {
                this.cbxSix.SelectedIndex = 0;
            }
            else
            {
                if (str == "EcgServer.exe")
                {
                    this.cbxSix.SelectedIndex = 0;
                }
                else if (str == "EcgServer_ADECON.exe")
                {
                    this.cbxSix.SelectedIndex = 1;
                }
                this.cbxSix.Text = str;
            }
            string str2 = (root.SelectSingleNode("BtAutoSave") == null) ? "" : root.SelectSingleNode("BtAutoSave").InnerText;
            if (string.IsNullOrEmpty(str2))
            {
                this.cbbt.SelectedIndex = 0;
            }
            else
            {
                this.cbbt.Text = str2;
            }
            this.node_binding("anyview", this.tbDBAdr, root);
            this.node_binding("dbsynUrl", this.tbAysSr, root);
            this.node_binding("ftpUpdateFile", this.tbUploadCheckSr, root);
            XmlNode node2 = root.SelectSingleNode("fsset");
            if ((node2 != null) && !string.IsNullOrEmpty(node2.InnerXml))
            {
                char[] chArray = node2.InnerXml.ToArray<char>();
                int index = 0;
                foreach (char ch in chArray)
                {
                    if (this.clbFS.Items.Count > index)
                    {
                        this.clbFS.SetItemChecked(index, ch == '1');
                    }
                    index++;
                }
            }
            XmlNode node3 = root.SelectSingleNode("ds_modify");
            if ((node3 != null) && !string.IsNullOrEmpty(node3.InnerXml))
            {
                char[] chArray2 = node3.InnerXml.ToArray<char>();
                int num2 = 0;
                foreach (char ch2 in chArray2)
                {
                    if (this.clbDin.Items.Count > num2)
                    {
                        this.clbDin.SetItemChecked(num2, ch2 == '1');
                    }
                    num2++;
                }
            }
            this.ds_whatsup = new DataSet();
            this.ds_whatsup.ReadXml(Application.StartupPath + @"\input_required.xml");
            this.dataGridView1.DataSource = this.ds_whatsup.Tables[0];
        }

        private void InitializeComponent()
        {
            TreeNode node = new TreeNode("常规设置");
            TreeNode node2 = new TreeNode("接口与地址");
            TreeNode node3 = new TreeNode("功能项");
            TreeNode node4 = new TreeNode("设备测量");
            TreeNode node5 = new TreeNode("必填项");
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.splitContainer1 = new SplitContainer();
            this.trvSetGroup = new TreeView();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.clbFS = new CheckedListBox();
            this.textBox21 = new TextBox();
            this.tbAutoUpdate = new TextBox();
            this.tbUpdateNo = new TextBox();
            this.tbRdCard = new TextBox();
            this.tbUploadAdr = new TextBox();
            this.tbFireWall = new TextBox();
            this.tbUploadAccount = new TextBox();
            this.textBox9 = new TextBox();
            this.textBox11 = new TextBox();
            this.textBox5 = new TextBox();
            this.textBox7 = new TextBox();
            this.textBox1 = new TextBox();
            this.textBox4 = new TextBox();
            this.tbFtpAdr = new TextBox();
            this.tbAccountPwd = new TextBox();
            this.textBox13 = new TextBox();
            this.tbDBAdr = new TextBox();
            this.textBox15 = new TextBox();
            this.tbAysSr = new TextBox();
            this.tbUploadCheckSr = new TextBox();
            this.textBox17 = new TextBox();
            this.textBox20 = new TextBox();
            this.cbxSix = new ComboBox();
            this.textBox19 = new TextBox();
            this.textBox22 = new TextBox();
            this.dataGridView1 = new DataGridView();
            this.col_name = new DataGridViewTextBoxColumn();
            this.col_descripe = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewCheckBoxColumn();
            this.clbDin = new CheckedListBox();
            this.textBox2 = new TextBox();
            this.cbbt = new ComboBox();
            this.splitContainer1.BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.btnSave.Location = new Point(0x1cf, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x57, 0x1b);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnCancel.Location = new Point(0x241, 470);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x57, 0x1b);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "关 闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.splitContainer1.Location = new Point(14, 14);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.trvSetGroup);
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new Size(0x2a5, 0x1b9);
            this.splitContainer1.SplitterDistance = 0x94;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 5;
            this.trvSetGroup.Location = new Point(3, 3);
            this.trvSetGroup.Name = "trvSetGroup";
            node.Name = "节点0";
            node.Text = "常规设置";
            node2.Name = "节点1";
            node2.Text = "接口与地址";
            node3.Name = "节点2";
            node3.Text = "功能项";
            node4.Name = "节点3";
            node4.Text = "设备测量";
            node5.Name = "节点4";
            node5.Text = "必填项";
            this.trvSetGroup.Nodes.AddRange(new TreeNode[] { node, node2, node3, node4, node5 });
            this.trvSetGroup.Size = new Size(0x89, 0x7c);
            this.trvSetGroup.TabIndex = 0;
            this.trvSetGroup.AfterSelect += new TreeViewEventHandler(this.treeView1_AfterSelect);
            this.tableLayoutPanel1.BackgroundImageLayout = ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.55602f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.44398f));
            this.tableLayoutPanel1.Controls.Add(this.cbbt, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.clbFS, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.textBox21, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.tbAutoUpdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbUpdateNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbRdCard, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbUploadAdr, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbFireWall, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbUploadAccount, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbFtpAdr, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbAccountPwd, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBox13, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tbDBAdr, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBox15, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.tbAysSr, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.tbUploadCheckSr, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.textBox17, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.textBox20, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxSix, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox19, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.textBox22, 0, 0x10);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0x10);
            this.tableLayoutPanel1.Controls.Add(this.clbDin, 1, 14);
            this.tableLayoutPanel1.Location = new Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 0x11;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 71f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 140f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 416f));
            this.tableLayoutPanel1.Size = new Size(0x1e3, 0x466);
            this.tableLayoutPanel1.TabIndex = 7;
            this.clbFS.FormattingEnabled = true;
            this.clbFS.Items.AddRange(new object[] { "档案信息", "随访人群", "纸质档案", "综合查询", "免疫接种", "条码打印", "多参数仪", "拍取照片" });
            this.clbFS.Location = new Point(0x84, 0x16c);
            this.clbFS.MultiColumn = true;
            this.clbFS.Name = "clbFS";
            this.tableLayoutPanel1.SetRowSpan(this.clbFS, 2);
            this.clbFS.Size = new Size(0x15b, 0x5e);
            this.clbFS.TabIndex = 1;
            this.textBox21.Location = new Point(4, 0x1d2);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new Size(0x77, 0x17);
            this.textBox21.TabIndex = 0x1f;
            this.textBox21.Text = "测量数据输入";
            this.textBox21.TextAlign = HorizontalAlignment.Center;
            this.tbAutoUpdate.Location = new Point(0x84, 0x22);
            this.tbAutoUpdate.Name = "tbAutoUpdate";
            this.tbAutoUpdate.Size = new Size(0x15b, 0x17);
            this.tbAutoUpdate.TabIndex = 7;
            this.tbUpdateNo.Location = new Point(0x84, 4);
            this.tbUpdateNo.Name = "tbUpdateNo";
            this.tbUpdateNo.Size = new Size(0x15b, 0x17);
            this.tbUpdateNo.TabIndex = 4;
            this.tbRdCard.Location = new Point(0x84, 0x5e);
            this.tbRdCard.Name = "tbRdCard";
            this.tbRdCard.Size = new Size(0x15b, 0x17);
            this.tbRdCard.TabIndex = 8;
            this.tbUploadAdr.Location = new Point(0x84, 0xb8);
            this.tbUploadAdr.Name = "tbUploadAdr";
            this.tbUploadAdr.Size = new Size(0x15b, 0x17);
            this.tbUploadAdr.TabIndex = 11;
            this.tbFireWall.Location = new Point(0x84, 0x7c);
            this.tbFireWall.Name = "tbFireWall";
            this.tbFireWall.Size = new Size(0x15b, 0x17);
            this.tbFireWall.TabIndex = 13;
            this.tbUploadAccount.Location = new Point(0x84, 0xd6);
            this.tbUploadAccount.Name = "tbUploadAccount";
            this.tbUploadAccount.Size = new Size(0x15b, 0x17);
            this.tbUploadAccount.TabIndex = 15;
            this.textBox9.Location = new Point(4, 4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new Size(0x77, 0x17);
            this.textBox9.TabIndex = 14;
            this.textBox9.Text = "产品升级号";
            this.textBox9.TextAlign = HorizontalAlignment.Center;
            this.textBox11.Location = new Point(4, 0x22);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new Size(0x77, 0x17);
            this.textBox11.TabIndex = 0x10;
            this.textBox11.Text = "自动升级";
            this.textBox11.TextAlign = HorizontalAlignment.Center;
            this.textBox5.Location = new Point(4, 0x5e);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new Size(0x77, 0x17);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "身份证读卡器";
            this.textBox5.TextAlign = HorizontalAlignment.Center;
            this.textBox7.Location = new Point(4, 0x7c);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new Size(0x77, 0x17);
            this.textBox7.TabIndex = 12;
            this.textBox7.Text = "防火墙是否关闭";
            this.textBox7.TextAlign = HorizontalAlignment.Center;
            this.textBox1.Location = new Point(4, 0xd6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0x77, 0x17);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "上传账号";
            this.textBox1.TextAlign = HorizontalAlignment.Center;
            this.textBox4.Location = new Point(4, 0xf4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new Size(0x77, 0x17);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "上传密码";
            this.textBox4.TextAlign = HorizontalAlignment.Center;
            this.tbFtpAdr.Location = new Point(4, 0xb8);
            this.tbFtpAdr.Name = "tbFtpAdr";
            this.tbFtpAdr.ReadOnly = true;
            this.tbFtpAdr.Size = new Size(0x77, 0x17);
            this.tbFtpAdr.TabIndex = 5;
            this.tbFtpAdr.Text = "上传地址";
            this.tbFtpAdr.TextAlign = HorizontalAlignment.Center;
            this.tbAccountPwd.Location = new Point(0x84, 0xf4);
            this.tbAccountPwd.Name = "tbAccountPwd";
            this.tbAccountPwd.Size = new Size(0x15b, 0x17);
            this.tbAccountPwd.TabIndex = 0x11;
            this.textBox13.Location = new Point(4, 0x112);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new Size(0x77, 0x17);
            this.textBox13.TabIndex = 0x12;
            this.textBox13.Text = "数据库地址";
            this.textBox13.TextAlign = HorizontalAlignment.Center;
            this.tbDBAdr.Location = new Point(0x84, 0x112);
            this.tbDBAdr.Name = "tbDBAdr";
            this.tbDBAdr.Size = new Size(0x15b, 0x17);
            this.tbDBAdr.TabIndex = 0x13;
            this.textBox15.Location = new Point(4, 0x130);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new Size(0x77, 0x17);
            this.textBox15.TabIndex = 20;
            this.textBox15.Text = "数据同步接口";
            this.textBox15.TextAlign = HorizontalAlignment.Center;
            this.tbAysSr.Location = new Point(0x84, 0x130);
            this.tbAysSr.Name = "tbAysSr";
            this.tbAysSr.Size = new Size(0x15b, 0x17);
            this.tbAysSr.TabIndex = 0x15;
            this.tbUploadCheckSr.Location = new Point(0x84, 0x14e);
            this.tbUploadCheckSr.Name = "tbUploadCheckSr";
            this.tbUploadCheckSr.Size = new Size(0x15b, 0x17);
            this.tbUploadCheckSr.TabIndex = 0x17;
            this.textBox17.Location = new Point(4, 0x14e);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new Size(0x77, 0x17);
            this.textBox17.TabIndex = 0x16;
            this.textBox17.Text = "上传验证接口";
            this.textBox17.TextAlign = HorizontalAlignment.Center;
            this.textBox20.Location = new Point(4, 0x9a);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new Size(0x77, 0x17);
            this.textBox20.TabIndex = 0x1d;
            this.textBox20.Text = "多参选择";
            this.textBox20.TextAlign = HorizontalAlignment.Center;
            this.cbxSix.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSix.FormattingEnabled = true;
            this.cbxSix.Items.AddRange(new object[] { "永康多参数仪", "爱德康多参数仪" });
            this.cbxSix.Location = new Point(0x84, 0x9a);
            this.cbxSix.Name = "cbxSix";
            this.cbxSix.Size = new Size(0x15b, 0x16);
            this.cbxSix.TabIndex = 30;
            this.textBox19.Location = new Point(4, 0x16c);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new Size(0x77, 0x17);
            this.textBox19.TabIndex = 0x18;
            this.textBox19.Text = "功能配置";
            this.textBox19.TextAlign = HorizontalAlignment.Center;
            this.textBox22.Location = new Point(4, 0x27f);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new Size(0x77, 0x17);
            this.textBox22.TabIndex = 0x21;
            this.textBox22.Text = "体检必填项";
            this.textBox22.TextAlign = HorizontalAlignment.Center;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.col_name, this.col_descripe, this.Column1 });
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0x84, 0x27f);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x15b, 0x1e3);
            this.dataGridView1.TabIndex = 0x22;
            this.col_name.DataPropertyName = "NAME";
            style.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.col_name.DefaultCellStyle = style;
            this.col_name.HeaderText = "名称";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Resizable = DataGridViewTriState.True;
            this.col_name.Visible = false;
            this.col_name.Width = 120;
            this.col_descripe.DataPropertyName = "COMMENT";
            style2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.col_descripe.DefaultCellStyle = style2;
            this.col_descripe.HeaderText = "说明";
            this.col_descripe.Name = "col_descripe";
            this.col_descripe.ReadOnly = true;
            this.col_descripe.Width = 290;
            this.Column1.DataPropertyName = "IS_REQUIRED";
            this.Column1.FalseValue = "0";
            this.Column1.HeaderText = " ";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "1";
            this.Column1.Width = 30;
            this.clbDin.FormattingEnabled = true;
            this.clbDin.Items.AddRange(new object[] { "腰围", "呼吸频率", "体温", "身高", "体重", "脉率", "左侧血压", "右侧血压", "心率", "血红蛋白", "空腹血糖", "尿常规(无效)", "总胆固醇", "甘油三酯", "血清高密度脂蛋白胆固醇" });
            this.clbDin.Location = new Point(0x84, 0x1d2);
            this.clbDin.MultiColumn = true;
            this.clbDin.Name = "clbDin";
            this.tableLayoutPanel1.SetRowSpan(this.clbDin, 2);
            this.clbDin.Size = new Size(0x15b, 0xa6);
            this.clbDin.TabIndex = 1;
            this.textBox2.Location = new Point(4, 0x40);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(0x77, 0x17);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "蓝牙弹窗保存";
            this.textBox2.TextAlign = HorizontalAlignment.Center;
            this.cbbt.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbbt.FormattingEnabled = true;
            this.cbbt.Items.AddRange(new object[] { "yes", "no" });
            this.cbbt.Location = new Point(0x84, 0x40);
            this.cbbt.Name = "cbbt";
            this.cbbt.Size = new Size(0xcd, 0x16);
            this.cbbt.TabIndex = 0x1f;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x2c9, 0x206);
            base.Controls.Add(this.splitContainer1);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmConfig";
            this.Text = "设置";
            base.Load += new EventHandler(this.FrmConfig_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        private void node_binding(string nodename, TextBox tb, XmlNode root)
        {
            XmlNode dataSource = root.SelectSingleNode(nodename);
            if (dataSource != null)
            {
                tb.DataBindings.Add(new Binding("Text", dataSource, "InnerXml", false, DataSourceUpdateMode.OnPropertyChanged));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int num = 0;
            string text = e.Node.Text;
            if (text != null)
            {
                if (!(text == "常规设置"))
                {
                    if (text == "接口与地址")
                    {
                        num = 0x9a;
                    }
                    else if (text == "功能项")
                    {
                        num = 0x14e;
                    }
                    else if (text == "设备测量")
                    {
                        num = 0x1b4;
                    }
                    else if (text == "必填项")
                    {
                        num = 0x261;
                    }
                }
                else
                {
                    num = 0;
                }
            }
            this.splitContainer1.Panel2.VerticalScroll.Value = num;
        }
    }
}

