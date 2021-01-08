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
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.Utilities.CommonControl;
using System.IO;
using KangShuoTech.Utilities.Common;

namespace HealthHouse
{
    public partial class HealthVascularForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public HHCardiovascularModel vascularModel;
        private HHCardiovascularBLL vascularBLL = new HHCardiovascularBLL();
        private CSingleItem Cardiovascular;
        public HealthVascularForm()
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
            this.vascularModel = vascularBLL.GetData(this.Model.IDCardNo,HealthHouseFactory.ID);
            if (this.vascularModel == null)
            {
                this.vascularModel = new HHCardiovascularModel();
                this.vascularModel.IDCardNo = this.Model.IDCardNo;
            }
            CSingleItem item2 = new CSingleItem
            {
                Name = "心血管",
                Usual = this.rdCardiovascular,
                Unusual = this.rdCardiovascularEx,
                Info = this.txtCResultEx
            };
            this.Cardiovascular = item2;
            this.Cardiovascular.TransInfo(this.vascularModel.Result, this.vascularModel.ResultEx);
            if (!string.IsNullOrEmpty(this.vascularModel.ImgPath) && File.Exists(this.vascularModel.ImgPath))
            {
                //读取文件流
                System.IO.FileStream fs = new System.IO.FileStream(this.vascularModel.ImgPath, FileMode.Open, FileAccess.Read);

                int byteLength = (int)fs.Length;
                byte[] fileBytes = new byte[byteLength];
                fs.Read(fileBytes, 0, byteLength);

                //文件流关閉,文件解除锁定
                fs.Close();
                Image image = Image.FromStream(new MemoryStream(fileBytes));

                pboxBShow.Image = image;

                //Image img = System.Drawing.Image.FromFile(this.vascularModel.ImgPath);
                //Image bmp = new System.Drawing.Bitmap(img);
                //img.Dispose();

                //pboxBShow.Image = bmp;
            }
            else
            {
                btnPrint.Visible = false;
            }
            this.EveryThingIsOk = true;
        }

        public bool SaveModelToDB()
        {
            this.vascularModel.PID = HealthHouseFactory.ID;
            if (!this.vascularBLL.ExistsPID(this.vascularModel.IDCardNo, HealthHouseFactory.ID))
            {
                this.vascularBLL.Insert(this.vascularModel);
            }
            else
            {
                this.vascularBLL.Update(this.vascularModel);
            }
            return true;
        }
        public void NotisfyChildStatus()
        {
        }
        public void UpdataToModel()
        {
            this.vascularModel.Result = this.Cardiovascular.Choose;
            this.vascularModel.ResultEx = this.Cardiovascular.Choose_EX;
        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private void HealthVascularForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void txtResetCardiovascular_Click(object sender, EventArgs e)
        {
            rdCardiovascular.Checked = false;
            rdCardiovascularEx.Checked = false;
            txtCResultEx.Text = "";
            this.vascularModel.Result = string.Empty;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommonExtensions.ShellExecute(IntPtr.Zero, "Print", this.vascularModel.ImgPath, "", "", 0);
        }
    }
}
