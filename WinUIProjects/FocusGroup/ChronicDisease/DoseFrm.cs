using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FocusGroup.ChronicDisease
{
    public partial class DoseFrm : Form
    {
        public DoseFrm()
        {
            InitializeComponent();

            dgvDose.Columns.Add(GetTextColums("名称", "name", 120));
            dgvDose.Columns.Add(GetTextColums("用法", "yongfa", 80));
            dgvDose.Columns.Add(GetTextColums("服药剂量(mg/次)", "jiliang", 80));
            dgvDose.Columns.Add(GetTextColums("服药次数/天", "cishu", 80));
            dgvDose.Columns.Add(GetTextColums("剂型", "jixing", 90));
            dgvDose.Columns.Add(GetTextColums("生产厂家", "factory", 100));
            dgvDose.Columns.Add(GetTextColums("类型", "leixing", 80));
            dgvDose.Columns.Add(GetTextColums("首字母", "szm", 70));
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    MessageBox.Show("请选择药物类型!!");
                    return;
                }
                //这里是取剪贴板里的内容，如果内容为空，则退出
                string pastTest = Clipboard.GetText();
                if (string.IsNullOrEmpty(pastTest)) return;

                //excel中是以 空格 和换行来 当做字段和行，所以用\n \r来分隔
                string[] lines = pastTest.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                BindingSource bds = (BindingSource)dgvDose.DataSource;
                foreach (string line in lines)
                {
                    string[] strs = line.Split(new char[] { '\t' });
                    List<string> lst_str = new List<string>(strs);
                    lst_str.Add(comboBox1.Text);//
                    var szm = GetChineseSpell(lst_str[0]);
                    lst_str.Add(szm);

                    if (lst_str.Count != 6)
                    {
                        tbInfo.AppendText("不正确的格式:" + line);
                    }
                    else
                    {
                        ((DataTable)bds.DataSource).Rows.Add(lst_str.ToArray());
                    }
                }
            }
            else if (((ContextMenuStrip)sender).Items[1] == e.ClickedItem)
            {
                //BindingSource bds = (BindingSource)dataGridView1.DataSource;
                //if (bds.Position >= 0)
                //{
                //    DataRowView drv = bds.List[bds.Position] as DataRowView;

                //    if (drv != null)
                //    {
                //        DataRow dr = drv.Row;
                //        dr.Delete();
                //    }
                //}

                //dataGridView1.SelectedRows

                foreach (DataGridViewRow item in dgvDose.SelectedRows)
                {
                    if (item.IsNewRow)
                    {

                    }
                    else
                    {
                        DataRowView drv = item.DataBoundItem as DataRowView;

                        if (drv != null)
                        {
                            DataRow dr = drv.Row;
                            dr.Delete();
                        }
                    }
                }
            }
        }
        DataSet ds;

        private void DoseFrm_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(Application.StartupPath + "\\dose.xml");

            BindingSource bds = new BindingSource();
            bds.DataSource = ds.Tables[0];
            dgvDose.DataSource = bds;
            comboBox1.SelectedIndex = 1;

            ds.Tables[0].RowChanged += new DataRowChangeEventHandler(DoseFrm_RowChanged);
            ds.Tables[0].TableNewRow += new DataTableNewRowEventHandler(DoseFrm_TableNewRow);
        }
        void DoseFrm_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            //throw new NotImplementedException();
            DataRow dr = e.Row;

            if (dr["szm"] == null)
            {
                dr["szm"] = GetChineseSpell(dr["name"].ToString());
            }
            else
            {
                if (string.IsNullOrEmpty(dr["szm"].ToString()))
                {
                    dr["szm"] = GetChineseSpell(dr["name"].ToString());
                }
            }
        }
        void DoseFrm_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRow dr = e.Row;

            if (dr["szm"] == null)
            {
                dr["szm"] = GetChineseSpell(dr["name"].ToString());
            }
            else
            {
                if (string.IsNullOrEmpty(dr["szm"].ToString()))
                {
                    if (dr["name"] != null && !string.IsNullOrEmpty(dr["name"].ToString()))
                    {
                        dr["szm"] = GetChineseSpell(dr["name"].ToString());
                    }
                    else
                    {
                        //MessageBox.Show("药品名称不能为空!");
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ds.WriteXml(Application.StartupPath + "\\" + "dose.xml");
            MessageBox.Show("保存成功!");
        }
        public string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        public string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            BindingSource bds = (BindingSource)dgvDose.DataSource;
            if (comboBox1.SelectedIndex == 0)
            {
                bds.Filter = "";
            }
            else
            {
                bds.Filter = string.Format("leixing = '{0}'", comboBox1.Text);
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex < ds.Tables[0].Rows.Count)
                {
                    DataRow dr = ds.Tables[0].Rows[e.RowIndex];
                    var name = dr["name"].ToString().Replace("(", ",").Replace(")", "").Replace("（", ",").Replace("）", "");
                    dr["szm"] = GetChineseSpell(name);
                }

            }
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            BindingSource bds = (BindingSource)dgvDose.DataSource;
            DataTable dt = bds.DataSource as DataTable;
            if (dt == null)
            {
                return;
            }
            if (e.RowIndex >= dt.Rows.Count)
            {
                return;
            }

            DataRow dr = dt.Rows[e.RowIndex];

            if (dr["name"] == null || string.IsNullOrEmpty(dr["name"].ToString()))
            {
                dgvDose.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
            }
            else
            {
                dgvDose.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }

            //System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
            //    e.RowBounds.Location.Y,
            //    dataGridView1.RowHeadersWidth - 4,
            //    e.RowBounds.Height);

            //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            //    dataGridView1.RowHeadersDefaultCellStyle.Font,
            //    rectangle,
            //    dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
            //    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDose.SelectedRows.Count != 0)
            {
                //MessageBox.Show("选中行");
                contextMenuStrip1.Items[1].Enabled = true;
            }
            else
            {
                //MessageBox.Show("选中列"); \
                contextMenuStrip1.Items[1].Enabled = false;
            }
        }
        private DataGridViewTextBoxColumn GetTextColums(string headtext, string mapingName, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = headtext;
            col.DataPropertyName = mapingName;
            col.Width = width;

            return col;
        }

    }
}
