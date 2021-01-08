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
    public partial class HealthBCHAO : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private HealthHouseBCHAOBLL BchaoBLL=new HealthHouseBCHAOBLL();
        private HealthHouseBCHAOModel BchaoModel;
        private CSingleItem BCHAO;
        private CSingleItem BCHAOther;

        public HealthBCHAO()
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
            this.BchaoModel = this.BchaoBLL.GetModel(HealthHouseFactory.ID);
            if (this.BchaoModel == null)
            {
                this.BchaoModel = new HealthHouseBCHAOModel();
                this.BchaoModel.IDCardNo = this.Model.IDCardNo;
            }
            CSingleItem item1 = new CSingleItem
            {
                Name = "B超",
                Usual = this.radbczc,
                Unusual = this.radbcyc,
                Info = this.txtbcyc
            };
            this.BCHAO = item1;
            this.BCHAO.TransInfo(this.BchaoModel.BCHAO, this.BchaoModel.BCHAOEx);
            CSingleItem item2 = new CSingleItem
            {
                Name = "B超其他",
                Usual = this.radbcqtzc,
                Unusual = this.radbcqtyc,
                Info = this.txtbcqtyc
            };
            this.BCHAOther = item2;
            this.BCHAOther.TransInfo(this.BchaoModel.BCHAOther, this.BchaoModel.BCHAOtherEx);
            if (!string.IsNullOrEmpty(this.BchaoModel.ImgPath) && File.Exists(this.BchaoModel.ImgPath))
            {
                //读取文件流
                System.IO.FileStream fs = new System.IO.FileStream(this.BchaoModel.ImgPath, FileMode.Open, FileAccess.Read);

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
            this.BchaoModel.PID = HealthHouseFactory.ID;
            if (!this.BchaoBLL.ExistsPID(this.BchaoModel.IDCardNo, HealthHouseFactory.ID))
            {
                this.BchaoBLL.Add(this.BchaoModel);
            }
            else
            {
                this.BchaoBLL.Update(this.BchaoModel);
            }
            return true;
        }
        public void NotisfyChildStatus()
        {
        }
        public void UpdataToModel()
        {
            this.BchaoModel.BCHAO = this.BCHAO.Choose;
            this.BchaoModel.BCHAOEx = this.BCHAO.Choose_EX;
            this.BchaoModel.BCHAOther = this.BCHAOther.Choose;
            this.BchaoModel.BCHAOtherEx = this.BCHAOther.Choose_EX;
        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private void HealthBCHAO_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        private void btnReset_b_Click(object sender, EventArgs e)
        {
            this.txtbcyc.Text = string.Empty;
            this.radbcyc.Checked = false;
            this.radbczc.Checked = false;
            this.BchaoModel.BCHAO = string.Empty;
        }

        private void btnReset_bqt_Click(object sender, EventArgs e)
        {
            this.txtbcqtyc.Text = string.Empty;
            this.radbcqtyc.Checked = false;
            this.radbcqtzc.Checked = false;
            this.BchaoModel.BCHAOther = string.Empty;
        }
    }
}
