using KangShuoTech.Utilities.Common;

namespace ArchiveInfo
{
    
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class RequiredFieldForm : Form
    {
        private Button btnCancel;
        private Button btnSave;
        private CheckedListBox clbDin;
        private IContainer components;
        private DataGridView dataGridView1;
        private DataSet ds_whatsup;
        private string input = "";
        private TextBox textBox21;
        private DataGridViewTextBoxColumn col_name;
        private DataGridViewTextBoxColumn col_descripe;
        private DataGridViewCheckBoxColumn Column1;
        private TextBox textBox22;

        public RequiredFieldForm()
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
            string str = "";
            for (int i = 0; i < this.clbDin.Items.Count; i++)
            {
                str = !this.clbDin.GetItemChecked(i) ? (str + "0") : (str + "1");
            }
            ConfigHelper.WriteNode("ds_modify", str);
            this.ds_whatsup.WriteXml(Application.StartupPath + @"\input_required.xml");
            base.DialogResult = DialogResult.OK;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void RequiredFieldForm_Load(object sender, EventArgs e)
        {
            string node = ConfigHelper.GetNode("ds_modify");
            if (!string.IsNullOrEmpty(node))
            {
                char[] chArray = node.ToArray<char>();
                int index = 0;
                foreach (char ch in chArray)
                {
                    if (this.clbDin.Items.Count > index)
                    {
                        this.clbDin.SetItemChecked(index, ch == '1');
                    }
                    index++;
                }
            }
            this.ds_whatsup = new DataSet();
            this.ds_whatsup.ReadXml(Application.StartupPath + @"\input_required.xml");
            this.dataGridView1.DataSource = this.ds_whatsup.Tables[0];
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_descripe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clbDin = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_descripe,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(248, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(350, 382);
            this.dataGridView1.TabIndex = 35;
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "NAME";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.col_name.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_name.HeaderText = "名称";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_name.Visible = false;
            this.col_name.Width = 120;
            // 
            // col_descripe
            // 
            this.col_descripe.DataPropertyName = "COMMENT";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.col_descripe.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_descripe.HeaderText = "说明";
            this.col_descripe.Name = "col_descripe";
            this.col_descripe.ReadOnly = true;
            this.col_descripe.Width = 290;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ISREQUIRED";
            this.Column1.FalseValue = "0";
            this.Column1.HeaderText = " ";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "1";
            this.Column1.Width = 30;
            // 
            // clbDin
            // 
            this.clbDin.CheckOnClick = true;
            this.clbDin.FormattingEnabled = true;
            this.clbDin.Items.AddRange(new object[] {
            "腰围",
            "呼吸频率",
            "体温",
            "身高",
            "体重",
            "脉率",
            "左侧血压",
            "右侧血压",
            "心率",
            "血红蛋白",
            "空腹血糖",
            "尿常规(无效)",
            "总胆固醇",
            "甘油三酯",
            "血清高密度脂蛋白胆固醇"});
            this.clbDin.Location = new System.Drawing.Point(14, 42);
            this.clbDin.MultiColumn = true;
            this.clbDin.Name = "clbDin";
            this.clbDin.Size = new System.Drawing.Size(228, 382);
            this.clbDin.TabIndex = 36;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(511, 458);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "关 闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox21.Location = new System.Drawing.Point(14, 13);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(119, 23);
            this.textBox21.TabIndex = 39;
            this.textBox21.Text = "测量数据输入";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox22.Location = new System.Drawing.Point(248, 13);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(119, 23);
            this.textBox22.TabIndex = 40;
            this.textBox22.Text = "体检必填项";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RequiredFieldForm
            // 
            this.ClientSize = new System.Drawing.Size(616, 497);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.clbDin);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequiredFieldForm";
            this.ShowIcon = false;
            this.Text = "设置必填项";
            this.Load += new System.EventHandler(this.RequiredFieldForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.N:
                case Keys.O:
                case Keys.S:
                case Keys.T:
                case Keys.V:
                case Keys.E:
                case Keys.A:
                {
                    RequiredFieldForm required = this;
                    string str = required.input + keyData.ToString();
                    required.input = str;
                    break;
                }
                case Keys.Enter:
                    if (this.input == "QCTSET")
                    {
                        this.clbDin.Enabled = true;
                    }
                    this.input = "";
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}

