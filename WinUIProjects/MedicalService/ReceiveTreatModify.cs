using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonTools;
using KangShuoTech.Utilities.CommonUI;

namespace MedicalService
{
    public partial class ReceiveTreatModify : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public int ID;
        public ReceiveTreatBaseInfoModel receiveMode;
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        public ReceiveTreatModify()
        {
            InitializeComponent();
            this.HaveToSave = false;
            this.EveryThingIsOk = false;
        }
        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }
        private void ReceiveTreatModify_Load(object sender, EventArgs e)
        {
            
             receiveMode = new ReceiveTreatBaseInfoBLL().GetModel(this.ID);
             if (!this.EveryThingIsOk)
             {
                 InitEveryThing();
             }
             
        }
        public bool SaveModelToDB()
        {
            try
            {
                bool result = new ReceiveTreatBaseInfoBLL().Update(receiveMode);
                if (result)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return true;
        }

        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {
            receiveMode.UpdateUnitName = tbUpdatName.Text;
            receiveMode.UpdatePerson = tbUpdatName.Text;
            receiveMode.UpdateDate = dtpUpdatTime.Value;
            receiveMode.ReceiveDate = dtReceiveDate.Value;

        }
        public void InitEveryThing()
        {
            tbName.Text = receiveMode.CustomerName;
            tbIDCARD.Text = receiveMode.IDCardNo;
            tbAddress.Text = receiveMode.Address;
            tbCreateUnitName.Text = receiveMode.CreateUnitName;
            tbCreateMenName.Text = receiveMode.CreateMenName;
            dtReceiveDate.Text = receiveMode.ReceiveDate.ToString();
            if (this.receiveMode.CreateDate.HasValue)
            {
                this.dtCreatTime.Value = this.receiveMode.CreateDate.Value;
            }
            this.tbUpdatName.Text = this.Model.Doctor;
            this.tbUpdatUnitName.Text = ConfigHelper.GetNode("orgName");
            this.dtpUpdatTime.Text = DateTime.Now.ToString();  
            if (receiveMode.Sex == "1")
            {
                tbSex.Text = "男";
            }
            else if(receiveMode.Sex == "2")
            {
                tbSex.Text = "女";
            }
            tbSubjectData.DataBindings.Add("Text", this.receiveMode, "SubjectiveData", false, DataSourceUpdateMode.OnPropertyChanged);
            tbObjectiveData.DataBindings.Add("Text", this.receiveMode, "ObjectiveData", false, DataSourceUpdateMode.OnPropertyChanged);
            tbAssessment.DataBindings.Add("Text", this.receiveMode, "Assessment", false, DataSourceUpdateMode.OnPropertyChanged);
            tbManagePlane.DataBindings.Add("Text", this.receiveMode, "ManagePlane", false, DataSourceUpdateMode.OnPropertyChanged);
            tbDoctor.DataBindings.Add("Text", this.receiveMode, "Doctor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.EveryThingIsOk = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
