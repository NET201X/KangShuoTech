using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SelectForm : Form
    {
        private BindingSource bds;
        private Button btnCancel;
        private IContainer components;
        private DataGridView dataGridView1;
        private List<DeviceInfoModel> devInfo;
        private string m_DeviceType;
        private string m_User;
        private string mytypeName;
        private string m_direction ="";
        public SelectForm()
        {
            this.mytypeName = "";
            this.InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        public SelectForm(string userid, string deviceType, string direction)
        {
            this.mytypeName = "";
            this.InitializeComponent();
            this.m_User = userid;
            this.m_Result = new stru_result();
            this.m_DeviceType = deviceType;
            this.m_direction = direction;
            if (((this.m_DeviceType == "22") || (this.m_DeviceType == "52")) || (((this.m_DeviceType == "24") || (this.m_DeviceType == "40")) || (this.m_DeviceType == "41")))
            {
                base.Width = 220;
            }
            if ((this.m_DeviceType == "20") || (this.m_DeviceType == "42"))
            {
                base.Width = 420;
            }
            if (this.m_DeviceType == "33")
            {
                base.Width = 700;
            }
            if (this.m_DeviceType == "32")
            {
                base.Width = 400;
            }
            if (this.m_DeviceType == "35")
            {
                base.Width = 220;
            }
            if (this.m_DeviceType == "39")
            {
                base.Width = 220;
            }
            if (this.m_DeviceType == "98")
            {
                base.Width = 220;
            }
            if (this.m_DeviceType == "97")
            {
                base.Width = 400;
            }
        }

        public SelectForm(string userid, string deviceType)
        {
            this.mytypeName = "";
            this.InitializeComponent();
            this.m_User = userid;
            this.m_Result = new stru_result();
            this.m_DeviceType = deviceType;
            if (((this.m_DeviceType == "22") || (this.m_DeviceType == "52")) || (((this.m_DeviceType == "24") || (this.m_DeviceType == "40")) || (this.m_DeviceType == "41")))
            {
                base.Width = 220;
            }
            if ((this.m_DeviceType == "20") || (this.m_DeviceType == "42"))
            {
                base.Width = 420;
            }
            if (this.m_DeviceType == "33")
            {
                base.Width = 700;
            }
            if (this.m_DeviceType == "32")
            {
                base.Width = 400;
            }
            if (this.m_DeviceType == "35")
            {
                base.Width = 220;
            }
            if (this.m_DeviceType == "39")
            {
                base.Width = 220;
            }
            if (this.m_DeviceType == "98")
            {
                base.Width = 220;
            }
            if (this.m_DeviceType == "97")
            {
                base.Width = 400;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.bds.Position < 0)
            {
                this.m_Result.HasValue = false;
            }
            else
            {
                int position = this.bds.Position;
                DeviceInfoModel deviceinfo = this.bds.List[this.bds.Position] as DeviceInfoModel;
                if (deviceinfo != null)
                {
                    this.m_Result.datetime = deviceinfo.UpdateData;
                    this.m_Result.value1 = deviceinfo.Value1;
                    if (this.m_DeviceType == "20")
                    {
                        this.m_Result.value2 = deviceinfo.Value2;
                        this.m_Result.value3 = deviceinfo.Value3;
                       
                    }
                    if (this.m_DeviceType == "33")
                    {
                        this.m_Result.value2 = deviceinfo.Value2;
                        this.m_Result.value3 = deviceinfo.Value3;
                        this.m_Result.value4 = deviceinfo.Value4;
                        this.m_Result.value5 = deviceinfo.Value5;
                        this.m_Result.value6 = deviceinfo.Value6;
                        this.m_Result.value7 = deviceinfo.Value7;
                        this.m_Result.value8 = deviceinfo.Value8;
                        this.m_Result.value9 = deviceinfo.Value9;
                        this.m_Result.value10 = deviceinfo.Value10;
                        this.m_Result.value11 = deviceinfo.Value11;
                    }
                    if (this.m_DeviceType == "32")
                    {
                        this.m_Result.value2 = deviceinfo.Value2;
                    }
                    bool flag1 = this.m_DeviceType == "31";
                    bool flag2 = this.m_DeviceType == "35";
                    this.m_Result.HasValue = true;
                }
                base.DialogResult = DialogResult.OK;
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
        RequireBLL bll = new RequireBLL();

        private void FrmSelect_Load(object sender, EventArgs e)
        {
            string str = !(this.m_DeviceType == "24") ? string.Format(" IDCardNo = '{0}' and DEVICETYPE = '{1}' ", this.m_User, this.m_DeviceType) : string.Format(" IDCardNo = '{0}' and (devicetype = 24 or (devicetype = 35 and devicename = '血糖' )) ", this.m_User, this.m_DeviceType);
            if (this.m_DeviceType == "35")
            {
                str = str + string.Format(" and deviceName = '{0}'", this.mytypeName);
            }
            if (this.m_DeviceType == "20")
            {
                if (this.ItemTypeName == "心率")
                {
                    str = str + string.Format(" and Value3 != '' ", new object[0]);
                }
                if (this.ItemTypeName == "血压")
                {
                    str = str + string.Format(" and Value1 != '' ", new object[0]);
                }
            }
            this.devInfo = new DeviceInfoBLL().GetModelList(str + " ORDER BY ID DESC ");
            if (this.m_DeviceType == "20")
            {
                for (int j = 0; j < this.devInfo.Count; j++)
                {
                    if ((string.IsNullOrEmpty(this.devInfo[j].Value1 + this.devInfo[j].Value2) && !(this.ItemTypeName == "心率")) && (this.ItemTypeName == "血压"))
                    {
                        this.devInfo.RemoveAt(j);
                    }
                    if (string.IsNullOrEmpty(this.devInfo[j].Value3) && (this.ItemTypeName == "心率"))
                    {
                        this.devInfo.RemoveAt(j);
                    }
                }
                /// <summary>
                /// 左侧低血压
                /// </summary>
                RequireModel LeftLowModel = new RequireBLL().GetModel("健康体检", "一般状况", "左侧低血压");
                /// <summary>
                /// 左侧高血压
                /// </summary>
                RequireModel LeftHeightModel = new RequireBLL().GetModel("健康体检", "一般状况", "左侧高血压");
                /// <summary>
                /// 右侧低血压
                /// </summary>
                RequireModel RightLowModel = new RequireBLL().GetModel("健康体检", "一般状况", "右侧低血压");
                /// <summary>
                /// 右侧高血压
                /// </summary>
                RequireModel RightHeightModel = new RequireBLL().GetModel("健康体检", "一般状况", "右侧高血压");
                int num = 0;
                //山东禹城 单侧为右
                for (int i = 0; i < this.devInfo.Count; i++)
                {
                    //如果数据为左侧血压
                    if (devInfo[i].DeviceName == "左侧血压")
                    {
                        //判断默认项是否存在左侧高血压  value1 是左侧高血压
                        if (LeftHeightModel != null)
                        {
                            //判断是否可以转换int
                            if (int.TryParse(devInfo[i].Value1, out num))
                            {
                                //默认项是偶数
                                if (LeftHeightModel.IsOdevity == "偶数")
                                {
                                    //取余 如果余数不是0 表示是奇数，需要-1处理成偶数
                                    if (int.Parse(devInfo[i].Value1) % 2 != 0)
                                    {
                                        devInfo[i].Value1 = (int.Parse(devInfo[i].Value1) - 1).ToString();
                                    }
                                }
                                //默认项是奇数
                                if (LeftHeightModel.IsOdevity == "奇数")
                                {
                                    //取余 如果余数是0 表示是偶数，需要-1处理成奇数
                                    if (int.Parse(devInfo[i].Value1) % 2 == 0)
                                    {
                                        devInfo[i].Value1 = (int.Parse(devInfo[i].Value1) - 1).ToString();
                                    }
                                }
                            }
                        }
                        //判断默认项是否存在左侧低血压 value2 是左侧低血压
                        if (LeftLowModel != null)
                        {
                            //判断是否可以转换int
                            if (int.TryParse(devInfo[i].Value2, out num))
                            {
                                //默认项是偶数
                                if (LeftLowModel.IsOdevity == "偶数")
                                {
                                    //取余 如果余数不是0 表示是奇数，需要-1处理成偶数
                                    if (int.Parse(devInfo[i].Value2) % 2 != 0)
                                    {
                                        devInfo[i].Value2 = (int.Parse(devInfo[i].Value2) - 1).ToString();
                                    }
                                }
                                //默认项是奇数
                                if (LeftLowModel.IsOdevity == "奇数")
                                {
                                    //取余 如果余数是0 表示是偶数，需要-1处理成奇数
                                    if (int.Parse(devInfo[i].Value2) % 2 == 0)
                                    {
                                        devInfo[i].Value2 = (int.Parse(devInfo[i].Value2) - 1).ToString();
                                    }
                                }
                            }
                        }
                    }
                    //山东地区 单侧为右
                    if (devInfo[i].DeviceName == "右侧血压" || devInfo[i].DeviceName == "血压"|| string.IsNullOrEmpty(devInfo[i].DeviceName))
                    {
                        //判断默认项是否存在右侧高血压  value1 是右侧高血压
                        if (RightHeightModel != null)
                        {
                            //判断是否可以转换int
                            if (int.TryParse(devInfo[i].Value1, out num))
                            {
                                //默认项是偶数
                                if (RightHeightModel.IsOdevity == "偶数")
                                {
                                    //取余 如果余数不是0 表示是奇数，需要-1处理成偶数
                                    if (int.Parse(devInfo[i].Value1) % 2 != 0)
                                    {
                                        devInfo[i].Value1 = (int.Parse(devInfo[i].Value1) - 1).ToString();
                                    }
                                }
                                //默认项是奇数
                                if (RightHeightModel.IsOdevity == "奇数")
                                {
                                    //取余 如果余数是0 表示是偶数，需要-1处理成奇数
                                    if (int.Parse(devInfo[i].Value1) % 2 == 0)
                                    {
                                        devInfo[i].Value1 = (int.Parse(devInfo[i].Value1) - 1).ToString();
                                    }
                                }
                            }
                        }
                        //判断默认项是否存在左侧低血压 value2 是左侧低血压
                        if (RightLowModel != null)
                        {
                            //判断是否可以转换int
                            if (int.TryParse(devInfo[i].Value2, out num))
                            {
                                //默认项是偶数
                                if (RightLowModel.IsOdevity == "偶数")
                                {
                                    //取余 如果余数不是0 表示是奇数，需要-1处理成偶数
                                    if (int.Parse(devInfo[i].Value2) % 2 != 0)
                                    {
                                        devInfo[i].Value2 = (int.Parse(devInfo[i].Value2) - 1).ToString();
                                    }
                                }
                                //默认项是奇数
                                if (RightLowModel.IsOdevity == "奇数")
                                {
                                    //取余 如果余数是0 表示是偶数，需要-1处理成奇数
                                    if (int.Parse(devInfo[i].Value2) % 2 == 0)
                                    {
                                        devInfo[i].Value2 = (int.Parse(devInfo[i].Value2) - 1).ToString();
                                    }
                                }
                            }
                        }

                    }
                }
                this.dataGridView1.Columns.Add(this.GetTextColums("收缩压", "Value1", 0x58));
                this.dataGridView1.Columns.Add(this.GetTextColums("舒张压", "Value2", 0x58));
                this.dataGridView1.Columns.Add(this.GetTextColums("心率", "Value3", 0x58));
                if (this.m_direction != "Right")
                {
                    this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
                }
            }
            else if (this.m_DeviceType == "22")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("体重", "Value1", 0x42));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "24")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("血糖", "Value1", 70));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "32")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("血氧", "Value1", 0x58));
                this.dataGridView1.Columns.Add(this.GetTextColums("脉率", "Value2", 0x58));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "33")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
                this.dataGridView1.Columns.Add(this.GetTextColums("尿胆原", "Value1", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("潜血", "Value2", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("胆红素", "Value3", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("酮体", "Value4", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("葡萄糖", "Value5", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("蛋白质", "Value6", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("PH", "Value7", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("亚硝酸盐", "Value8", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("白细胞", "Value9", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("比重", "Value10", 50));
                this.dataGridView1.Columns.Add(this.GetTextColums("维生素C", "Value11", 50));
            }
            else if (this.m_DeviceType == "35")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums(this.mytypeName, "Value1", 0x58));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "39")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("身高", "Value1", 0x42));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "40")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("体温", "Value1", 0x42));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "98")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("呼吸频率", "Value1", 0x42));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "41")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("幽门螺杆菌", "Value1", 0x42));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "42")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("胸围", "Value1", 0x4c));
                this.dataGridView1.Columns.Add(this.GetTextColums("腰围", "Value2", 0x4c));
                this.dataGridView1.Columns.Add(this.GetTextColums("臀围", "Value3", 0x4c));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "52")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("血红蛋白值", "Value1", 0x42));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            else if (this.m_DeviceType == "97")
            {
                this.dataGridView1.Columns.Add(this.GetTextColums("检测结果", "Value1", 0xf6));
                this.dataGridView1.Columns.Add(this.GetTextColums("检测时间", "UpdateData", 120));
            }
            for (int i = 1; i < this.dataGridView1.ColumnCount; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.bds = new BindingSource();
            this.bds.DataSource = this.devInfo;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = this.bds;
        }

        private DataGridViewTextBoxColumn GetTextColums(string headtext, string mapingName, int width)
        {
            return new DataGridViewTextBoxColumn { HeaderText = headtext, DataPropertyName = mapingName, Width = width };
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            this.btnCancel = new Button();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.dataGridView1.BackgroundColor = SystemColors.InactiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(1, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x284, 0xe0);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.Location = new Point(0x209, 0xe4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x5f, 0x1f);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.BackColor = Color.FromArgb(7, 0x4c, 0x73);
            base.ClientSize = new Size(0x286, 0x106);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.dataGridView1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "FrmSelect";
            this.Text = "FrmSelect";
            base.Load += new EventHandler(this.FrmSelect_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        public string ItemTypeName
        {
            get
            {
                return this.mytypeName;
            }
            set
            {
                this.mytypeName = value;
            }
        }

        public stru_result m_Result { get; set; }
    }
}

