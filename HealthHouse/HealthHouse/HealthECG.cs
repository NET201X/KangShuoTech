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

namespace HealthHouse
{
    public partial class HealthECG : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private HealthHouseEcgModel EcgModel;
        private HealthHouseEcgBLL EcgBLL = new HealthHouseEcgBLL();
        private CSingleItem xindian;
        public HealthECG()
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
            this.EcgModel = this.EcgBLL.GetModel(HealthHouseFactory.ID);
            if (this.EcgModel == null)
            {
                this.EcgModel = new HealthHouseEcgModel();
                this.EcgModel.IDCardNo = this.Model.IDCardNo;
            }
            CSingleItem item = new CSingleItem
            {
                Name = "心电",
                Usual = this.radXDZC,
                Unusual = this.radXDYC,
                Info = this.txtXDYC
            };
            this.xindian = item;
            this.xindian.TransInfo(this.EcgModel.ECG, this.EcgModel.ECGEx);
            if (!string.IsNullOrEmpty(this.EcgModel.ImgPath) && File.Exists(this.EcgModel.ImgPath))
            {
                //读取文件流
                System.IO.FileStream fs = new System.IO.FileStream(this.EcgModel.ImgPath, FileMode.Open, FileAccess.Read);

                int byteLength = (int)fs.Length;
                byte[] fileBytes = new byte[byteLength];
                fs.Read(fileBytes, 0, byteLength);

                //文件流关閉,文件解除锁定
                fs.Close();
                Image image = Image.FromStream(new MemoryStream(fileBytes));

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
            this.EcgModel.PID = HealthHouseFactory.ID;
            if (!this.EcgBLL.ExistsPID(this.EcgModel.IDCardNo, HealthHouseFactory.ID))
            {
                this.EcgBLL.Add(this.EcgModel);
            }
            else
            {
                this.EcgBLL.Update(this.EcgModel);
            }
            return true;
        }
        public void NotisfyChildStatus()
        {
        }
        public void UpdataToModel()
        {
            this.EcgModel.ECG = this.xindian.Choose;
            this.EcgModel.ECGEx = this.xindian.Choose_EX;
        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private void HealthECG_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void btnReset_xd_Click(object sender, EventArgs e)
        {
            this.txtXDYC.Text = string.Empty;
            this.radXDYC.Checked = false;
            this.radXDZC.Checked = false;
            this.EcgModel.ECG = string.Empty;
        }

    }
}
