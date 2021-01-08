namespace KangShuoTech.Utilities.CommonControl
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public class SingleItemUserControl : UserControl
    {
        private IContainer components;
        private Label lbItemName;
        private RadioButton rdNo;
        private RadioButton rdYes;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbInfo;

        public SingleItemUserControl()
        {
            this.InitializeComponent();
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
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.lbItemName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdNo
            // 
            this.rdNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdNo.Checked = true;
            this.rdNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdNo.Location = new System.Drawing.Point(79, 3);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(34, 25);
            this.rdNo.TabIndex = 15;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "无";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdYes
            // 
            this.rdYes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdYes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdYes.Location = new System.Drawing.Point(119, 3);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(34, 25);
            this.rdYes.TabIndex = 14;
            this.rdYes.Text = "有";
            this.rdYes.UseVisualStyleBackColor = true;
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInfo.Location = new System.Drawing.Point(159, 3);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(89, 23);
            this.tbInfo.TabIndex = 31;
            // 
            // lbItemName
            // 
            this.lbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbItemName.AutoSize = true;
            this.lbItemName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbItemName.Location = new System.Drawing.Point(3, 0);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbItemName.Size = new System.Drawing.Size(70, 31);
            this.lbItemName.TabIndex = 30;
            this.lbItemName.Text = "单项名称:";
            this.lbItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbItemName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbInfo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdYes, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(251, 31);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // SingleItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SingleItemUserControl";
            this.Size = new System.Drawing.Size(251, 31);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public string ItemName
        {
            get
            {
                return this.lbItemName.Text;
            }
            set
            {
                this.lbItemName.Text = value;
            }
        }
    }
}

