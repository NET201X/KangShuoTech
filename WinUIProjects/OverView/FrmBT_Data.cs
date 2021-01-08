using KangShuoTech.DataAccessProjects.BLL;

namespace OverView
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using KangShuoTech.DataAccessProjects.Model;

    public class FrmBT_Data : Form
    {
        private Button btnClose;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private IContainer components;
        private DataGridView dataGridView1;

        public FrmBT_Data()
        {
            this.InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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

        private void FrmBT_Data_Load(object sender, EventArgs e)
        {
            List<DeviceInfoModel> modelList = new DeviceInfoBLL().GetModelList(string.Format("IDCardNo = '{0}' order by UpdateData desc", this.IDCardNo));
            List<DevRecord> list2 = new List<DevRecord>();
            foreach (DeviceInfoModel deviceinfo in modelList)
            {
                DevRecord rcd = this.GetRcd(deviceinfo);
                list2.Add(rcd);
            }
            this.dataGridView1.DataSource = list2;
        }

        private DevRecord GetRcd(DeviceInfoModel dev)
        {
            string str;
            DevRecord record = new DevRecord {
                RcdName = dev.DeviceName,
                RcdDate = dev.UpdateData
            };
            switch (dev.DeviceType)
            {
                case "20":
                    str = string.Format("收缩压{0}mmHg/舒张压{1}mmHg 心率{2}次/分钟", dev.Value1, dev.Value2, dev.Value3);
                    break;

                case "22":
                    str = string.Format("{0}Kg", dev.Value1);
                    break;

                case "24":
                    str = dev.Value1 + "mmol/L";
                    break;

                case "32":
                    str = string.Format("血氧{0} 脉率{1}", dev.Value1, dev.Value2);
                    break;

                case "33":
                    str = string.Format("尿胆原{0}潜血{1}胆红素{2}酮体{3}葡萄糖{4}蛋白质{5}PH{6}亚硝酸盐{7}白细胞{8}比重{9}维生素{10}", new object[] { dev.Value1, dev.Value2, dev.Value3, dev.Value4, dev.Value5, dev.Value6, dev.Value7, dev.Value8, dev.Value9, dev.Value10, dev.Value11 });
                    break;

                case "35":
                    str = dev.Value1;
                    break;

                case "40":
                    str = dev.Value1 + "℃";
                    break;

                case "98":
                    str = "呼吸频率:" + dev.Value1;
                    break;

                default:
                    str = dev.Value1;
                    break;
            }
            record.RcdResult = str;
            return record;
        }

        private void InitializeComponent()
        {
            this.btnClose = new Button();
            this.dataGridView1 = new DataGridView();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.btnClose.Location = new Point(0x1ce, 0xfc);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x57, 0x1b);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 });
            this.dataGridView1.Location = new Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x219, 230);
            this.dataGridView1.TabIndex = 2;
            this.Column1.DataPropertyName = "RcdName";
            this.Column1.HeaderText = "检测项";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            this.Column2.DataPropertyName = "RcdDate";
            this.Column2.HeaderText = "检测时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            this.Column3.DataPropertyName = "RcdResult";
            this.Column3.HeaderText = "检测记录";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 270;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            base.ClientSize = new Size(0x231, 0x11f);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.btnClose);
            this.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmBT_Data";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "蓝牙数据";
            base.Load += new EventHandler(this.FrmBT_Data_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        public string IDCardNo { get; set; }
    }
}

