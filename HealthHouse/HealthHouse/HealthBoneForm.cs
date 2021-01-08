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
    public partial class HealthBoneForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public HHBoneModel BoneModel;
        private HHBoneBLL BoneBLL = new HHBoneBLL();
        private CSingleItem Bone;
        public HealthBoneForm()
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
            this.BoneModel = this.BoneBLL.GetData(this.Model.IDCardNo,HealthHouseFactory.ID);
            if (this.BoneModel == null)
            {
                this.BoneModel = new HHBoneModel();
                this.BoneModel.IDCardNo = this.Model.IDCardNo;
            }
             CSingleItem item = new CSingleItem
            {
                Name = "骨密度",
                Usual = this.rdBone,
                Unusual = this.rdBoneEx,
                Info = this.txtResultEx
            };
            this.Bone = item;
            this.Bone.TransInfo(this.BoneModel.Result, this.BoneModel.ResultEx);
            if (!string.IsNullOrEmpty(this.BoneModel.ImgPath) && File.Exists(this.BoneModel.ImgPath))
            {
                //读取文件流
                System.IO.FileStream fs = new System.IO.FileStream(this.BoneModel.ImgPath, FileMode.Open, FileAccess.Read);

                int byteLength = (int)fs.Length;
                byte[] fileBytes = new byte[byteLength];
                fs.Read(fileBytes, 0, byteLength);

                //文件流关閉,文件解除锁定
                fs.Close();
                Image image = Image.FromStream(new MemoryStream(fileBytes));

                pboxBShow.Image = image;

                //Image img = System.Drawing.Image.FromFile(this.BoneModel.ImgPath);
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
            this.BoneModel.PID = HealthHouseFactory.ID;
            if (!BoneBLL.ExistsPID(this.BoneModel.IDCardNo, HealthHouseFactory.ID))
            {
                BoneBLL.Insert(this.BoneModel);
            }
            else
            {
                BoneBLL.Update(this.BoneModel);
            }
            return true;
        }
        public void NotisfyChildStatus()
        {
        }
        public void UpdataToModel()
        {
            this.BoneModel.Result = this.Bone.Choose;
            this.BoneModel.ResultEx = this.Bone.Choose_EX;
        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private void HealthBoneForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommonExtensions.ShellExecute(IntPtr.Zero, "Print", this.BoneModel.ImgPath, "", "", 0);
        }

        private void btnResetBone_Click(object sender, EventArgs e)
        {
            rdBone.Checked = false;
            rdBoneEx.Checked = false;
            txtResultEx.Text = "";
            this.BoneModel.Result = string.Empty;
        }

    }
}
