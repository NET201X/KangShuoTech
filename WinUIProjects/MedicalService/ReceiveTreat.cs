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

namespace MedicalService
{
    public partial class ReceiveTreat : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public ReceiveTreat()
        {
            InitializeComponent();
            this.HaveToSave = false;
        }
        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        public bool SaveModelToDB()
        {
            ReceiveTreatBaseInfoBLL receive_info = new ReceiveTreatBaseInfoBLL();
            int result = receive_info.Add(this.ClinicalModel);
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {
            ClinicalModel = new ReceiveTreatBaseInfoModel();
            this.ClinicalModel.IDCardNo = tbIDCARD.Text.Trim();
            this.ClinicalModel.Doctor = tbDoctor.Text.Trim();
            this.ClinicalModel.ReceiveDate = dtReceiveDate.Value;
            this.ClinicalModel.SubjectiveData = tbSubjectData.Text.Trim();
            this.ClinicalModel.ObjectiveData = tbObjectiveData.Text.Trim();
            this.ClinicalModel.Assessment = tbAssessment.Text.Trim();
            this.ClinicalModel.ManagePlane = tbManagePlane.Text.Trim();

        }

        public void InitEveryThing()
        {

            this.tbName.Text = this.Model.CustomerName;
            this.tbAddress.Text = this.Model.Address;
            this.dtCreatTime.Text = this.Model.CreateDate.ToString();
            this.tbIDCARD.Text = this.Model.IDCardNo;
            this.tbCreateMenName.Text = this.Model.CreateMenName;
            this.tbDoctor.Text = this.Model.Doctor;
            this.tbCreateUnitName.Text = this.Model.CreateUnitName;

            if (this.Model.Sex == "1")
            {
                this.tbSex.Text = "男";
            }
            else if (this.Model.Sex == "2")
            {
                this.tbSex.Text = "女";
            }


            this.EveryThingIsOk = true;
        }
        private void ClinicalAddForm_Load(object sender, EventArgs e)
        {

            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }


        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        public ReceiveTreatBaseInfoModel ClinicalModel { set; get; }
        public string IDCardNo { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
