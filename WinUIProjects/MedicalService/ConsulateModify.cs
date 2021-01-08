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
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.CommonTools;

namespace MedicalService
{
    public partial class ConsulateModify : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public ConsulationBaseInfoModel consulateModel;
        public ConsulationDoctorsModel doctorModel;
        public List<ConsulationDoctorsModel> ListModel;
        public List<ConsulationDoctorsModel> AddListModel;
        public StringBuilder DeletID;
        public DataSet doctorSet;
        public int ID;
        public int SelectRow = -1;
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }
        public ConsulateModify()
        {
            InitializeComponent();
            EveryThingIsOk = false;
        }
        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        private void ConsulateModify_Load(object sender, EventArgs e)
        {
            consulateModel = new ConsulationBaseInfoBLL().GetModel(this.ID);
            string strWhere = string.Format("OutKey={0}", this.ID);
            doctorSet = new ConsulationDoctorsBLL().GetList(strWhere);
            if (!this.EveryThingIsOk)
            {
                InitEveryThing();
            }
        }
        public bool SaveModelToDB()
        {
            try
            {
                bool result = new ConsulationBaseInfoBLL().Update(consulateModel);
                if (result)
                {
                    ListModel = new List<ConsulationDoctorsModel>();
                    AddListModel = new List<ConsulationDoctorsModel>();
                    int count = 0;
                    ReadInfo(ID);
                    if (AddListModel.Count > 0)
                    {
                        count = new ConsulationDoctorsBLL().Add(AddListModel);
                    }
                    if (count < 0)
                    {
                        return false;
                    }
                    if (!string.IsNullOrEmpty(DeletID.ToString()))
                    {
                        DeletID.Remove(DeletID.Length - 1, 1);
                        result = new ConsulationDoctorsBLL().DeleteList(DeletID.ToString());
                    }
                    if (!result)
                    {
                        return false;
                    }
                    if (ListModel.Count > 0)
                    {
                        result = new ConsulationDoctorsBLL().Update(ListModel);
                    }
                    if (result)
                    {
                        return true;
                    }

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
            consulateModel.UpdateUnitName = tbUpdatName.Text;
            consulateModel.UpdatePerson = tbUpdatName.Text;
            consulateModel.UpdateDate = dtpUpdatTime.Value;
            consulateModel.ConsultationDate = dtpConsultDate.Value;

        }
        public void InitEveryThing()
        {
            if (consulateModel == null)
                return;
            DeletID = new StringBuilder();
            this.lbName.Text = this.consulateModel.CustomerName;
            this.lbIDCard.Text = this.consulateModel.IDCardNo;
            this.lbAddress.Text = this.consulateModel.Address;
            this.tbCreateMenName.Text = this.consulateModel.CreateMenName;
            this.dtpCreatTime.Text = this.consulateModel.CreateTime.ToString();
            this.tbUpdatName.Text = ConfigHelper.GetNode("doctorName");
            this.tbUpdatUnitName.Text = ConfigHelper.GetNode("orgName");
            this.dtpUpdatTime.Text = DateTime.Today.ToString();
            this.tbCreateUnitName.Text = this.consulateModel.CreateUnitName;
            this.dtpConsultDate.Text = this.consulateModel.ConsultationDate.ToString();
            if (consulateModel.Sex == "1")
            {
                lbSex.Text = "男";
            }
            else if (consulateModel.Sex == "2")
            {
                lbSex.Text = "女";
            }
            this.tbConReason.DataBindings.Add("Text", this.consulateModel, "Reason", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbConsulView.DataBindings.Add("Text", this.consulateModel, "View", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbResponsibilityDoctor.DataBindings.Add("Text", this.consulateModel, "ResponsibilityDoctor", false, DataSourceUpdateMode.OnPropertyChanged);

            if (doctorSet != null)
            {
                this.dgConsulate.DataSource = doctorSet.Tables[0];
                dgConsulate.Refresh();
            }
            this.EveryThingIsOk = true;
            
        }

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
                for (int i = 0; i < dgConsulate.Rows.Count - 1; i++)
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
                    List<string> addstr = new List<string>();
                 
                    addstr.Add(tbConsultationUnitName.Text);
                    addstr.Add(tbConsultationDoctor1.Text);
                    addstr.Add(tbConsultationDoctor2.Text);
                    addstr.Add(tbConsultationDoctor3.Text);
                    DataTable table = (DataTable)dgConsulate.DataSource;
                    DataRow dr = table.NewRow();
                     //查询最新记录，给dr赋值然后

                    dr[1] = addstr[0];
                    dr[2] = addstr[1];
                    dr[3] = addstr[2];
                    dr[4] = addstr[3];
                    table.Rows.Add(dr);
                    dgConsulate.DataSource = table;

 
                   
                    //dgConsulate.Rows.Add(null, tbConsultationUnitName.Text, tbConsultationDoctor1.Text, tbConsultationDoctor2.Text, tbConsultationDoctor3.Text);
                }

            }
            else
            {
                dgConsulate.Rows[SelectRow].Cells["Column2"].Value = tbConsultationUnitName.Text;
                dgConsulate.Rows[SelectRow].Cells["Column3"].Value = tbConsultationDoctor1.Text;
                dgConsulate.Rows[SelectRow].Cells["Column4"].Value = tbConsultationDoctor2.Text;
                dgConsulate.Rows[SelectRow].Cells["Column5"].Value = tbConsultationDoctor3.Text;
                SelectRow = -1;
            }

            tbConsultationUnitName.Clear();
            tbConsultationDoctor1.Clear();
            tbConsultationDoctor2.Clear();
            tbConsultationDoctor3.Clear();
            dgConsulate.AllowUserToAddRows = false;
        }

        private void dgConsulate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgConsulate.RowCount < 1)
                return;

            if (e.ColumnIndex == 0)
            {
               
                if (!string.IsNullOrEmpty(dgConsulate.Rows[e.RowIndex].Cells["Column6"].Value.ToString()))
                {
                    DeletID.Append(dgConsulate.Rows[e.RowIndex].Cells["Column6"].Value.ToString() + ","); 
                }
                dgConsulate.Rows.RemoveAt(e.RowIndex);
                dgConsulate.Refresh();
            }
            else
            {
                this.tbConsultationUnitName.Text = dgConsulate.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                this.tbConsultationDoctor1.Text = dgConsulate.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                this.tbConsultationDoctor2.Text = dgConsulate.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
                this.tbConsultationDoctor3.Text = dgConsulate.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                SelectRow = e.RowIndex;
            }
        }
        public void ReadInfo(int outkey)
        {
            for (int i = 0; i < dgConsulate.Rows.Count; i++)
            {
                doctorModel = new ConsulationDoctorsModel();
                doctorModel.ConsultationUnitName = dgConsulate.Rows[i].Cells["Column2"].Value.ToString();
                doctorModel.ConsultationDoctor1 = dgConsulate.Rows[i].Cells["Column3"].Value.ToString();
                doctorModel.ConsultationDoctor2 = dgConsulate.Rows[i].Cells["Column4"].Value.ToString();
                doctorModel.ConsultationDoctor3 = dgConsulate.Rows[i].Cells["Column5"].Value.ToString();
                if (string.IsNullOrEmpty(dgConsulate.Rows[i].Cells["Column6"].Value.ToString()))
                {
                    doctorModel.OutKey = ID;
                    AddListModel.Add(doctorModel);
                }
                else
                {
                    doctorModel.ID = int.Parse(dgConsulate.Rows[i].Cells["Column6"].Value.ToString());
                    ListModel.Add(doctorModel);
                }
                
          

                
              
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
        
          
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbCreateUnitName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
