using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Reflection;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using System.Diagnostics;

    public class FrmStatistics : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private string auto_dbsyn = "1";
        private IContainer components;
        private DataGridView dataGridView1;
        private DataTable dt_statistics;
        private GroupBox groupBox1;
        private Button btnExport;
        private Label label1;
        private Label label3;
        private DateTimePicker dtpCreatedDateSt;
        private CheckBox ckxCreatedDate;
        private Label label2;
        private DateTimePicker dtpCreatedDateEd;
        private GroupBox groupBox3;
        private Button btnQuery;
        private ComboBox cmbtimetype;
        private int timebucket = 0;
        public FrmStatistics()
        {
            this.InitializeComponent();
            this.HaveToSave = false;
            this.EveryThingIsOk = false;
            this.CanDBSyn = false;
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

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
           
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.btnQuery.Text == "重置条件")
            {
                this.groupBox3.Enabled = true;
                this.btnQuery.Text = "查询";
                dtpCreatedDateSt.Text = "";
                dtpCreatedDateEd.Text = "";
            }
            else if (this.ckxCreatedDate.Checked && (this.dtpCreatedDateSt.Value.Date > this.dtpCreatedDateEd.Value.Date))
            {
                MessageBox.Show(" 建档日期:开始日期大于结束日期!", "日期错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    this.GetInfo(DateTime.Today.ToString("yyyy-MM-dd"));
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                }
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.Columns.Add(this.GetTextColums("项目", "项目", 150));
                string starttime ="" ;
                string endtime = "";
                this.btnQuery.Enabled = false;
                if (timebucket == 1)
                {
                    starttime = this.dtpCreatedDateSt.Value.Date.ToString("yyyy");
                    endtime = this.dtpCreatedDateEd.Value.Date.ToString("yyyy");
                    this.dataGridView1.DataSource = new DataOperationBLL().GetTimeBucketStatis(starttime,endtime, timebucket);
                }
                else if(timebucket ==2)
                {
                    starttime = this.dtpCreatedDateSt.Value.Date.ToString("yyyyMM");
                    endtime = this.dtpCreatedDateEd.Value.Date.ToString("yyyyMM");
                    this.dataGridView1.DataSource = new DataOperationBLL().GetTimeBucketStatis(starttime, endtime, timebucket);
                }
                else if (timebucket == 3)
                {
                    starttime = this.dtpCreatedDateSt.Value.Date.ToString("yyyyMMdd");
                    endtime = this.dtpCreatedDateEd.Value.Date.ToString("yyyyMMdd");
                    this.dataGridView1.DataSource = new DataOperationBLL().GetTimeBucketStatis(starttime, endtime, timebucket);
                }
                else
                {
                    this.dataGridView1.DataSource = new DataOperationBLL().GetStatistics();
                }
                System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (configuration.AppSettings.Settings["dbsyn"] == null)
                {
                    configuration.AppSettings.Settings.Add("dbsyn", this.auto_dbsyn);
                    configuration.Save();
                }
                else
                {
                    this.auto_dbsyn = configuration.AppSettings.Settings["dbsyn"].Value;
                }
                bool flag1 = this.auto_dbsyn == "1";
                this.groupBox3.Enabled = false;
                this.btnQuery.Enabled = true;
                this.btnQuery.Text = "重置条件";
            }
        }

        private void cmbtimetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            timebucket = (int)(this.cmbtimetype.SelectedIndex +1);
            if (timebucket == 1)//间隔时间段为年
            {
             this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
             this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
             this.dtpCreatedDateSt.Format = DateTimePickerFormat.Custom;
             this.dtpCreatedDateSt.CustomFormat = "yyyy年";
             this.dtpCreatedDateEd.Format = DateTimePickerFormat.Custom;
             this.dtpCreatedDateEd.CustomFormat = "yyyy年";
            }
            if (timebucket == 2)//间隔时间段为月
            {
                this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
                this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
                this.dtpCreatedDateSt.Format = DateTimePickerFormat.Custom;
                this.dtpCreatedDateSt.CustomFormat = "yyyy年MM月";
                this.dtpCreatedDateEd.Format = DateTimePickerFormat.Custom;
                this.dtpCreatedDateEd.CustomFormat = "yyyy年MM月";
            }
            if (timebucket == 3)//间隔时间短为日
            {
                this.dtpCreatedDateSt.Enabled = this.ckxCreatedDate.Checked;
                this.dtpCreatedDateEd.Enabled = this.ckxCreatedDate.Checked;
                this.dtpCreatedDateSt.Format = DateTimePickerFormat.Custom;
                this.dtpCreatedDateSt.CustomFormat = "yyyy年MM月dd日";
                this.dtpCreatedDateEd.Format = DateTimePickerFormat.Custom;
                this.dtpCreatedDateEd.CustomFormat = "yyyy年MM月dd日";
            }
        }
        private string GetTimeBucket()
        {
           string str2 = "";
           if (this.ckxCreatedDate.Checked && timebucket == 1) //间隔时间段为年
           {
               str2 = str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-01-01"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-12-31"));
           }
           else if (this.ckxCreatedDate.Checked && timebucket == 2)//间隔时间段为月
           {
               str2 = str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-01"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM"));
           }
           else if (this.ckxCreatedDate.Checked && timebucket == 3)//间隔时间短为日
           {
               str2 = str2 + string.Format(" and CreateDate between '{0}' and '{1}' ", this.dtpCreatedDateSt.Value.Date.ToString("yyyy-MM-dd"), this.dtpCreatedDateEd.Value.Date.ToString("yyyy-MM-dd"));
           }
           DataRowView selectedItem = this.cmbtimetype.SelectedItem as DataRowView;
           if (selectedItem == null)
           {
               return str2;
           }
           DataRow row = selectedItem.Row;
           if (row["ID"].ToString() == "-1")
           {
               return str2;
           }
           return str2 ;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string where = this.GetTimeBucket();
                string foldername = @"D:\国家公共卫生项目工作统计\";
                CreatFolder(foldername);
                DataTable newData = dataGridView1.DataSource as DataTable; 
                string strFileName = string.Format(@"\{0}",Model.CustomerName.Trim().ToString()+ DateTime.Now.ToString("yyyyMMddHHmmss"));
                ExpToExcel(newData, strFileName, "工作统计");
                //MessageBox.Show("成功导入D:\\国家公共卫生项目工作统计");
                string excelname = foldername + strFileName;
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wkb = app.Workbooks.Add(excelname);
                app.Visible = true;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
       
        private static void CreatFolder(string strToPath)
        {
            if (!Directory.Exists(strToPath))  //如果源文件夹不存在，则创建
            {
                Directory.CreateDirectory(strToPath); 
            }
        }
        /// <summary>
        /// 将源数据汇入到指定的 Excel 文件
        /// </summary>
        /// <typeparam name="T">源数据的类型</typeparam>
        /// <param name="newData">源数据</param>
        /// <param name="strFileName">目标文件名称</param>
        /// <param name="strSheetName">目标 Sheet 名称</param>
        private void ExpToExcel(DataTable newData, string strFileName, string strSheetName)
        {
            try
            {
                if (newData != null && strFileName != null && strSheetName != null)
                {
                    // 創建Excel文件的對象
                    HSSFWorkbook workbook = new HSSFWorkbook();
                    // 添加一個sheet
                    ISheet sheetEmp = workbook.CreateSheet(strSheetName);
                    //表的第一列
                    IRow rowtemp = sheetEmp.CreateRow(0);
                    for (int k = 0; k < newData.Columns.Count; k++)
                    {
                        string obj = newData.Columns[k].ColumnName.ToString();
                        rowtemp.CreateCell(k).SetCellValue(obj);
                    }
                    //將數據寫入sheetEmp的各個行
                    for (int i = 0; i < newData.Rows.Count; i++)
                    {
                        rowtemp = sheetEmp.CreateRow(i + 1);
                        int columnIndex = 0;
                        for (int k = 0; k < newData.Columns.Count; k++)
                        {
                            string obj = newData.Rows[i][k].ToString();
                            rowtemp.CreateCell(columnIndex).SetCellValue(obj);
                            columnIndex++;
                        }
                    }

                    // 寫入到客戶端 
                    MemoryStream ms = new MemoryStream();
                    workbook.Write(ms);
                    FileStream fs = new FileStream(@"D:\国家公共卫生项目工作统计\"+ strFileName + ".xls", FileMode.OpenOrCreate);
                    BinaryWriter w = new BinaryWriter(fs);
                    w.Write(ms.ToArray());
                    fs.Close();
                    workbook = null;
                    ms.Close();
                    ms.Dispose();
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetGateWay()
        {
            string str = "";
            foreach (ManagementObject obj2 in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                if (Convert.ToBoolean(obj2["ipEnabled"]))
                {
                    obj2["Caption"].ToString();
                    string[] strArray = obj2["DefaultIPGateway"] as string[];
                    if (strArray != null)
                    {
                        str = strArray[0];
                    }
                }
            }
            return str;
        }

        private void GetInfo(string date)
        {
        }

        private DataGridViewTextBoxColumn GetTextColums(string headtext, string mapingName, int width)
        {
            return new DataGridViewTextBoxColumn { HeaderText = headtext, DataPropertyName = mapingName, Width = width, ReadOnly = true };
        }

        public void InitEveryThing()
        {
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpCreatedDateSt = new System.Windows.Forms.DateTimePicker();
            this.ckxCreatedDate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCreatedDateEd = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbtimetype = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox1.Location = new System.Drawing.Point(69, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1400, 408);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工作统计";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1386, 369);
            this.dataGridView1.TabIndex = 37;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("宋体", 15F);
            this.btnExport.Location = new System.Drawing.Point(1375, 572);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 33);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(377, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 14);
            this.label3.TabIndex = 3;
            // 
            // dtpCreatedDateSt
            // 
            this.dtpCreatedDateSt.CustomFormat = "";
            this.dtpCreatedDateSt.Enabled = false;
            this.dtpCreatedDateSt.Location = new System.Drawing.Point(311, 29);
            this.dtpCreatedDateSt.Name = "dtpCreatedDateSt";
            this.dtpCreatedDateSt.Size = new System.Drawing.Size(208, 30);
            this.dtpCreatedDateSt.TabIndex = 3;
            // 
            // ckxCreatedDate
            // 
            this.ckxCreatedDate.AutoSize = true;
            this.ckxCreatedDate.Location = new System.Drawing.Point(9, 33);
            this.ckxCreatedDate.Name = "ckxCreatedDate";
            this.ckxCreatedDate.Size = new System.Drawing.Size(138, 24);
            this.ckxCreatedDate.TabIndex = 0;
            this.ckxCreatedDate.Text = "时间间隔段:";
            this.ckxCreatedDate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "—";
            // 
            // dtpCreatedDateEd
            // 
            this.dtpCreatedDateEd.Enabled = false;
            this.dtpCreatedDateEd.Location = new System.Drawing.Point(568, 29);
            this.dtpCreatedDateEd.Name = "dtpCreatedDateEd";
            this.dtpCreatedDateEd.Size = new System.Drawing.Size(196, 30);
            this.dtpCreatedDateEd.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cmbtimetype);
            this.groupBox3.Controls.Add(this.dtpCreatedDateEd);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ckxCreatedDate);
            this.groupBox3.Controls.Add(this.dtpCreatedDateSt);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox3.Location = new System.Drawing.Point(72, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1278, 81);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询列表类型";
            // 
            // cmbtimetype
            // 
            this.cmbtimetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtimetype.FormattingEnabled = true;
            this.cmbtimetype.Items.AddRange(new object[] {
            "年",
            "月",
            "日"});
            this.cmbtimetype.Location = new System.Drawing.Point(150, 30);
            this.cmbtimetype.Name = "cmbtimetype";
            this.cmbtimetype.Size = new System.Drawing.Size(126, 28);
            this.cmbtimetype.TabIndex = 2;
            this.cmbtimetype.SelectedIndexChanged += new System.EventHandler(this.cmbtimetype_SelectedIndexChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1371, 49);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(98, 81);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // FrmStatistics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmStatistics";
            this.Text = "FrmStatistics";
            this.Load += new System.EventHandler(this.FrmStatistics_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            return true;
        }

        private void setBtnEnabled(Button btn, bool en)
        {
            Action<Button, bool> method = new Action<Button, bool>(this.setBtnEnabled);
            if (btn.InvokeRequired)
            {
                btn.Invoke(method, new object[] { btn, en });
            }
            else
            {
                btn.Enabled = en;
            }
        }

        

        public void UpdataToModel()
        {
        }
 
        private bool CanDBSyn { get; set; }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

    }
}

