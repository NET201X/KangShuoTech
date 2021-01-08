using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.DataAccessProjects.BLL;
using System.IO;
using KangShuoTech.Utilities.Common;

namespace HealthHouse
{
    public partial class HealthLungForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public HHLungModel LungModel;
        private HHLungBLL LungBLL = new HHLungBLL();
        private CSingleItem Lung;
        public HealthLungForm()
        {
            InitializeComponent();
            this.EveryThingIsOk = false;
        }
        public ChildFormStatus CheckErrorInput()
        {

            return ChildFormStatus.NoErrorInput;
        }

        public void InitEveryThing()
        {
            this.LungModel = LungBLL.GetData(this.Model.IDCardNo,HealthHouseFactory.ID);
            if (this.LungModel == null)
            {
                this.LungModel = new HHLungModel();
                this.LungModel.IDCardNo = this.Model.IDCardNo;
            }
            CSingleItem item = new CSingleItem
            {
                Name = "肺功能",
                Usual = this.rdLung,
                Unusual = this.rdLungEx,
                Info = this.txtLResultEx
            };
            this.Lung = item;
            this.Lung.TransInfo(this.LungModel.Result, this.LungModel.ResultEx);

            if (!string.IsNullOrEmpty(this.LungModel.ImgPath) && File.Exists(this.LungModel.ImgPath))
            {
                //读取文件流
                System.IO.FileStream fs = new System.IO.FileStream(this.LungModel.ImgPath, FileMode.Open, FileAccess.Read);

                int byteLength = (int)fs.Length;
                byte[] fileBytes = new byte[byteLength];
                fs.Read(fileBytes, 0, byteLength);

                //文件流关閉,文件解除锁定
                fs.Close();
                Image image = Image.FromStream(new MemoryStream(fileBytes));

                //Image img = System.Drawing.Image.FromFile(this.LungModel.ImgPath);
                //Image bmp = new System.Drawing.Bitmap(img);
                //img.Dispose();

                pboxBShow.Image = image;
            }
            else
            {
                btnPrint.Visible = false;
            }
            this.EveryThingIsOk = true;

        }
        public bool SaveModelToDB()
        {
            HHLungBLL LungBLL = new HHLungBLL();
            this.LungModel.PID = HealthHouseFactory.ID;
            if (!LungBLL.ExistsPID(this.LungModel.IDCardNo, HealthHouseFactory.ID))
            {
                LungBLL.Insert(this.LungModel);
            }
            else
            {
                LungBLL.Update(this.LungModel);
            }
            return true;
        }
        public void NotisfyChildStatus()
        {
        }
        public void UpdataToModel()
        {
            this.LungModel.Result = this.Lung.Choose;
            this.LungModel.ResultEx = this.Lung.Choose_EX;
        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private void HealthLungForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommonExtensions.ShellExecute(IntPtr.Zero, "Print", this.LungModel.ImgPath, "", "", 0);
        }

        private void btnResetLung_Click(object sender, EventArgs e)
        {
            rdLung.Checked = false;
            rdLungEx.Checked = false;
            txtLResultEx.Text = "";
            this.LungModel.Result = string.Empty;
        }
    }
}
