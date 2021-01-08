using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using KangShuoTech.Utilities.CommonUI;
using System.Configuration;
using System.Text.RegularExpressions;
using KangShuoTech.CommomDataAccessProjects.CommonBLL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;

namespace PhotoGraph
{
    public partial class PhotoListForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private int currentPage;
        private int totalPages;
        private int totalCount;
        private int pageCount = 10;
        private BindingSource bds;
        private DataTable dt = new DataTable();
        private string PhotosPath = ConfigurationManager.AppSettings["PhotosPath"] == null ? @"D:\QCSoft\photos\" :
            ConfigurationManager.AppSettings["PhotosPath"].ToString();

        CommonClassBLL commonClassBLL = new CommonClassBLL();

        // 取得屏幕分辨率的宽高
        private int SH = Screen.PrimaryScreen.Bounds.Height;
        private int SW = Screen.PrimaryScreen.Bounds.Width;

        public PhotoListForm()
        {
            InitializeComponent();

            int height = 160;

            if (SW > 1400) height = 200;

            this.Size = new Size(SW, SH - height);
            this.groupBox1.Width = SW - 180;
            this.groupBox1.Left = 50;
            this.dgvData.Width = groupBox1.Width;
            this.dgvData.Height = this.Height - groupBox1.Height - 60;
            this.dgvData.Left = 50;
            this.btnQuery.Left = txtIdNum.Right + 70;
            this.panel1.Top = this.Height - 50;
            this.panel1.Left = dgvData.Width - panel1.Width + 50;

            this.dgvData.AutoGenerateColumns = false;
        }

        private void PhotoShowForm_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            this.bds = new BindingSource();

            DirectoryInfo dir = new DirectoryInfo(PhotosPath);//初始化一个DirectoryInfo类的对象
            //GetAllFiles(dir);
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.bds.Position >= 0) && (e.RowIndex >= 0))
            {
                DataRowView view = (DataRowView)this.bds.List[this.bds.Position];
                string name = view.Row["CustomerName"].ToString();
                string idCards = view.Row["IDCardNo"].ToString();
                string photoName = idCards + "_" + name + ".bmp";

                if (this.dgvData.Columns[e.ColumnIndex].HeaderText == "删除")
                {
                    if (MessageBox.Show("确定删除:" + idCards + "？删除之后图片将无法恢复!", "删除",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DataRow row = view.Row;

                        DeletePhoto(PhotosPath, photoName);

                        // 更新基本信息中的照片路径
                        new CommonClassBLL().Update(idCards, "");

                        ChackData();
                    }
                }
                else if (this.dgvData.Columns[e.ColumnIndex].HeaderText == "重拍")
                {
                    FrmCamera form = new FrmCamera()
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };

                    form.Name = name;
                    form.IDCardNo = idCards;

                    if (form.ShowDialog() == DialogResult.OK) ChackData();
                }
            }
        }

        /// <summary>
        /// 删除拍照
        /// </summary>
        /// <param name="path"></param>
        public void DeletePhoto(string path, string photoName)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    return;
                }

                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo fi in files)
                {
                    if (fi.Name.Contains(photoName))
                    {
                        File.Delete(fi.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public RecordsBaseInfoModel Model { get; set; }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.btnQuery.Text == "重置条件")
            {
                this.btnQuery.Text = "查询";
                txtIdNum.Text = "";
            }
            else
            {
                this.currentPage = 0;

                ChackData();
            }
        }

        private void ChackData()
        {
            string input = this.txtIdNum.Text.Trim();
            string where = GetWhere();

            this.totalCount = commonClassBLL.GetRecordCount(where);
            this.totalPages = (this.totalCount <= this.pageCount) ? 1 : ((this.totalCount / this.pageCount) +
                 (((this.totalCount % this.pageCount) > 0) ? 1 : 0));
            this.lbTotalCount.Text = string.Format("共计{0}条", this.totalCount.ToString());

            if (this.currentPage > totalPages - 1) this.currentPage--;

            DataSet ds = commonClassBLL.GetListByPage(where, "", this.currentPage * this.pageCount, this.pageCount);
            this.lbPages.Text = string.Format("{0}/{1}页", this.currentPage + 1, this.totalPages);

            if (ds.Tables.Count > 0)
            {
                this.TransDs(ds);
                this.bds.DataSource = dt;
                this.dgvData.DataSource = this.bds;
            }
        }

        private void TransDs(DataSet ds)
        {
            dt = ds.Tables[0];
            dt.Columns.Add("image", typeof(Image));

            foreach (DataRow row in dt.Rows)
            {
                if (row["PhotoPath"].ToString() != "")
                {
                    Image img = Image.FromFile(row["PhotoPath"].ToString());
                    Image image = new Bitmap(img);

                    row["image"] = image;

                    img.Dispose();
                }
            }
        }

        private string GetWhere()
        {
            string input = this.txtIdNum.Text.Trim();
            string where = "";

            if (input != "")
                where = !Regex.IsMatch(input, @"^\d{15}") ? string.Format(" AND CustomerName LIKE '%{0}%'", input) : ("AND IDCardNo LIKE '%" + input + "%'");

            return where;
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 0)
            {
                this.lbPages.Text = string.Format("{0}/{1}页", --this.currentPage + 1, this.totalPages);

                DataSet ds = commonClassBLL.GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);

                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = dt;
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < (this.totalPages - 1))
            {
                this.lbPages.Text = string.Format("{0}/{1}页", ++this.currentPage + 1, this.totalPages);

                DataSet ds = commonClassBLL.GetListByPage(this.GetWhere(), "", this.currentPage * this.pageCount, this.pageCount);

                if (ds.Tables.Count > 0)
                {
                    this.TransDs(ds);
                    this.bds.DataSource = dt;
                    this.dgvData.DataSource = this.bds;
                }
            }
        }

        #region 实例化接口

        public void InitEveryThing()
        {
            this.EveryThingIsOk = true;
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public bool SaveModelToDB()
        {
            return false;
        }

        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {

        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        #endregion
    }
}
