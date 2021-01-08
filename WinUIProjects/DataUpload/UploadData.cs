using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DataUpload
{
    public partial class UploadData : Form
    {
        public DataTable dtData = new DataTable();

        public UploadData()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadData_Load(object sender, EventArgs e)
        {
            this.label1.Text += this.dtData.Rows.Count.ToString() + "条";
            this.dataGridView1.DataSource = this.dtData;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("统计结果为空!!");
            }
            else
            {
                Dictionary<string, string> fgt = new Dictionary<string, string>();
                fgt.Add("IDCardNo", "身份证号");
                fgt.Add("Name", "姓名");
                fgt.Add("Error", "错误讯息");

                this.DatatableToCSVFile(fgt, dtData, @"d:\" + string.Format(@"\未同步人员列表{0}.csv", DateTime.Now.ToString("yyyyMMddHHmmss")));
            }
        }

        public void DatatableToCSVFile(Dictionary<string, string> fgt, DataTable dt, string fileName)
        {
            try
            {
                string str = "";
                foreach (KeyValuePair<string, string> pair in fgt)
                {
                    str = str + pair.Value + ',';
                }

                string str2 = str.TrimEnd(new char[] { ',' });
                StreamWriter writer = new StreamWriter(File.Create(fileName), Encoding.Default);
                writer.WriteLine(str2);

                foreach (DataRow row in dt.Rows)
                {
                    string str3 = "";
                    foreach (KeyValuePair<string, string> pair2 in fgt)
                    {
                        if (pair2.Key == "IDCardNo")
                        {
                            str3 = str3 + "\t" + row[pair2.Key].ToString() + ",";
                        }
                        else
                        {
                            str3 = str3 + row[pair2.Key].ToString() + ",";
                        }
                    }

                    string str4 = str3.TrimEnd(new char[] { ',' });
                    writer.WriteLine(str4);
                }

                writer.Flush();
                writer.Close();
                MessageBox.Show("导出文件至" + fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
