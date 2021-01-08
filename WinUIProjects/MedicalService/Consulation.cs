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
    public partial class Consulation : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
       
        public Consulation()
        {
            InitializeComponent();
            this.EveryThingIsOk = false;
            this.HaveToSave = false;
        }
        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }
        public void InitEveryThing()
        {
           
            ListModel = new List<ConsulationDoctorsModel>();
            ConModel = new ConsulationBaseInfoModel();
            ConDocModel = new ConsulationDoctorsModel();
            if (!string.IsNullOrEmpty(this.IDCardNo))
            {
                this.Model = new RecordsBaseInfoBLL().GetModel(this.IDCardNo);
            }
            this.lbAddress.Text = this.Model.Address;
            this.lbName.Text = this.Model.CustomerName;
            this.lbIDCard.Text = this.Model.IDCardNo;
            this.tbCreateMenName.Text = this.Model.CreateMenName;
            this.tbCreateUnitName.Text = this.Model.CreateUnitName;
            this.dtpCreatTime.Text = this.Model.CreateDate.Value.ToString();
            if (this.Model.Sex == "1")
            {
                this.lbSex.Text = "男";
            }
            else if (this.Model.Sex == "2")
            {
                this.lbSex.Text = "女";
            }

          
            this.ConModel.IDCardNo = lbIDCard.Text;
            this.EveryThingIsOk = true;
        }
        public void ReadInfo(int outkey)
        {
            for (int i = 0; i < dgConsulate.Rows.Count; i++)
            {
                ConDocModel = new ConsulationDoctorsModel();
                ConDocModel.ConsultationUnitName = dgConsulate.Rows[i].Cells[1].Value.ToString();
                ConDocModel.ConsultationDoctor1 = dgConsulate.Rows[i].Cells[2].Value.ToString();
                ConDocModel.ConsultationDoctor2 = dgConsulate.Rows[i].Cells[3].Value.ToString();
                ConDocModel.ConsultationDoctor3 = dgConsulate.Rows[i].Cells[4].Value.ToString();
                ConDocModel.OutKey = outkey;
                ListModel.Add(ConDocModel);
            }
        }
        public bool SaveModelToDB()
        {
           
            ConsulationBaseInfoBLL ConBll = new ConsulationBaseInfoBLL();
            ConsulationDoctorsBLL DocBll = new ConsulationDoctorsBLL();
            int result = ConBll.Add(ConModel);
            if (result == 0)
            {
                return false;
            }
            else
            {
                ReadInfo(result);
                if (ListModel.Count < 1)
                {
                    return true;
                }
              
                result = DocBll.Add(ListModel);
                if (result == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void NotisfyChildStatus()
        {

        }

        public void UpdataToModel()
        {
            this.ConModel.Reason = tbConReason.Text;
            this.ConModel.View = tbConsulView.Text;
            this.ConModel.ResponsibilityDoctor = tbResponsibilityDoctor.Text;
            this.ConModel.ConsultationDate = dtpConsultDate.Value;
            
        }
        private void Consulation_Load(object sender, EventArgs e)
        {
            if (!EveryThingIsOk)
            {
                InitEveryThing();
            }

        }

        public int SelectRow = -1;
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbConsultationUnitName.Text))
            {
                MessageBox.Show("医疗机构不能为空！");
                tbConsultationUnitName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbConsultationDoctor1.Text) && string.IsNullOrEmpty(tbConsultationDoctor2.Text) && string.IsNullOrEmpty(tbConsultationDoctor3.Text))
            {
                MessageBox.Show("会诊医生不能为空！");
                tbConsultationDoctor1.Focus();
                return;
            }
            dgConsulate.AllowUserToAddRows = true;
            
            if (SelectRow == -1)
            {
                bool addFlag = true;
                for (int i = 0; i < dgConsulate.Rows.Count-1; i++)
                {
                    string dgConsultationUnitName = dgConsulate.Rows[i].Cells[1].Value.ToString();
                    string dgConsultationDoctor1 = dgConsulate.Rows[i].Cells[2].Value.ToString();
                    string dgConsultationDoctor2 = dgConsulate.Rows[i].Cells[3].Value.ToString();
                    string dgConsultationDoctor3 = dgConsulate.Rows[i].Cells[4].Value.ToString();
                    string addConsultationUnitName = tbConsultationUnitName.Text;
                    string addConsultationDoctor1 = tbConsultationDoctor1.Text;
                    string addConsultationDoctor2 = tbConsultationDoctor2.Text;
                    string addConsultationDoctor3 = tbConsultationDoctor3.Text;
                    if (dgConsultationUnitName == addConsultationUnitName && dgConsultationDoctor1 == addConsultationDoctor1 && dgConsultationDoctor2 == addConsultationDoctor2 && dgConsultationDoctor3 == addConsultationDoctor3)
                    {
                        addFlag = false;
                        break;
                    }
                    
                }
                if (addFlag)
                {
                    dgConsulate.Rows.Add(null, tbConsultationUnitName.Text, tbConsultationDoctor1.Text, tbConsultationDoctor2.Text, tbConsultationDoctor3.Text);
                }
                    
            }
            else
            {
                dgConsulate.Rows[SelectRow].Cells[1].Value = tbConsultationUnitName.Text;
                dgConsulate.Rows[SelectRow].Cells[2].Value = tbConsultationDoctor1.Text;
                dgConsulate.Rows[SelectRow].Cells[3].Value = tbConsultationDoctor2.Text;
                dgConsulate.Rows[SelectRow].Cells[4].Value = tbConsultationDoctor3.Text;
                SelectRow=-1;
            }
       
            tbConsultationUnitName.Clear();
            tbConsultationDoctor1.Clear();
            tbConsultationDoctor2.Clear();
            tbConsultationDoctor3.Clear();
            dgConsulate.AllowUserToAddRows = false;
        }

        private void dgConsulate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgConsulate.RowCount <1)
                return;
            string content = dgConsulate.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                dgConsulate.Rows.RemoveAt(e.RowIndex);
                dgConsulate.Refresh();
            }
            else 
            {
                this.tbConsultationUnitName.Text = dgConsulate.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.tbConsultationDoctor1.Text = dgConsulate.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.tbConsultationDoctor2.Text = dgConsulate.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.tbConsultationDoctor3.Text = dgConsulate.Rows[e.RowIndex].Cells[4].Value.ToString();
                SelectRow = e.RowIndex;
            }
        }

        private void dgConsulate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private ConsulationBaseInfoModel ConModel { get; set; }
        private ConsulationDoctorsModel ConDocModel { get; set; }
        private List<ConsulationDoctorsModel> ListModel;
        public string IDCardNo { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbConsultationDoctor3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
