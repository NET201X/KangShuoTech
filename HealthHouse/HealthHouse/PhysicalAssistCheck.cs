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

namespace HealthHouse
{
    public partial class PhysicalAssistCheck : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public RecordsBaseInfoModel Model { get; set; }
        public HealthHousePhysicalAssistCheckModel HHAssistCheck { get; set; }
        private CSingleItem CHESTX;
        private HealthHouseModel HHModel { get; set; }

        public PhysicalAssistCheck()
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
            this.HHAssistCheck = new HealthHousePhysicalAssistCheckBLL().GetModel(HealthHouseFactory.ID);
            this.HHModel = new HealthHouseBLL().GetDataByID(HealthHouseFactory.ID);

            if (this.HHAssistCheck == null)
            {
                this.HHAssistCheck = new HealthHousePhysicalAssistCheckModel();
            }

            this.SimpleBinding(this.tbBIL,"BIL");
            this.SimpleBinding(this.tbBLD,"BLD");
            this.SimpleBinding(this.tbGLU,"GLU");
            this.SimpleBinding(this.tbKET,"KET");
            this.SimpleBinding(this.tbLEU,"LEU");
            this.SimpleBinding(this.tbNIT, "NIT");
            this.SimpleBinding(this.tbPH,"PH");
            this.SimpleBinding(this.tbPRO,"PRO");
            this.SimpleBinding(this.tbSG,"SG");
            this.SimpleBinding(this.tbUBG,"UBG");
            this.SimpleBinding(this.tbVC,"VC");
           
            CSingleItem item2 = new CSingleItem
            {
                Name = "胸部X射线",
                Usual = this.radxbxxpzc,
                Unusual = this.radxbxxpyc,
                Info = this.txtxbxxpyc
            };

            this.CHESTX = item2;
            this.CHESTX.TransInfo(this.HHAssistCheck.CHESTX, this.HHAssistCheck.CHESTXEx);
        
            this.EveryThingIsOk = true;
        }

        public bool SaveModelToDB()
        {
            HealthHousePhysicalAssistCheckBLL HHAssistCheckBLL = new HealthHousePhysicalAssistCheckBLL();
            this.HHAssistCheck.PID = HealthHouseFactory.ID;

            if (!HHAssistCheckBLL.ExistsPID(this.HHAssistCheck.IDCardNo, HealthHouseFactory.ID))
            {
                HHAssistCheckBLL.Add(this.HHAssistCheck);
            }
            else
            {
                HHAssistCheckBLL.Update(this.HHAssistCheck);
            }

            return true;
        }

        public void NotisfyChildStatus()
        {
        }

        public void UpdataToModel()
        {
            this.HHAssistCheck.IDCardNo = this.Model.IDCardNo;
            this.HHAssistCheck.CHESTX = this.CHESTX.Choose;
            this.HHAssistCheck.CHESTXEx = this.CHESTX.Choose_EX;
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        private void PhysicalAssistCheck_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }
        private void SimpleBinding(TextBox tb, string srcMember)
        {
            tb.ImeMode = ImeMode.Disable;
            Binding binding = new Binding("Text", this.HHAssistCheck, srcMember, true, DataSourceUpdateMode.OnPropertyChanged);
            tb.DataBindings.Add(binding);
         
        }
        private void bd_Parse(object sender, ConvertEventArgs e)
        {
            decimal num;
            Binding binding = sender as Binding;
            if (decimal.TryParse(e.Value.ToString(), out num))
            {
                if ((num >= 0M) && (num < 1000M))
                {
                    binding.Control.BackColor = Color.WhiteSmoke;
                    e.Value = num;
                }
                else
                {
                    binding.Control.BackColor = Color.Salmon;
                }
            }
            else
            {
                e.Value = null;
            }
        }
 
        private void btnReset_x_Click(object sender, EventArgs e)
        {
            this.txtxbxxpyc.Text = string.Empty;
            this.radxbxxpzc.Checked = false;
            this.radxbxxpyc.Checked = false;
            this.HHAssistCheck.CHESTX = string.Empty;
        }

        private void btnSelectBE_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(this.Model.IDCardNo, "33")
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (select.ShowDialog() == DialogResult.OK)
            {
                this.HHAssistCheck.PRO = select.m_Result.value6.ToString();
                this.HHAssistCheck.GLU = select.m_Result.value5.ToString();
                this.HHAssistCheck.KET = select.m_Result.value4.ToString();
                this.HHAssistCheck.BLD = select.m_Result.value2.ToString();
                this.HHAssistCheck.LEU = select.m_Result.value9.ToString();//白细胞
                this.HHAssistCheck.NIT = select.m_Result.value8.ToString();//亚硝酸
                this.HHAssistCheck.UBG = select.m_Result.value1.ToString();//尿胆原
                this.HHAssistCheck.BIL = select.m_Result.value3.ToString();//胆红素
                this.HHAssistCheck.PH = select.m_Result.value7.ToString();//ph
                this.HHAssistCheck.SG = select.m_Result.value10.ToString();//比重
                this.HHAssistCheck.VC= select.m_Result.value11.ToString();//vc

                this.tbPRO.Text = select.m_Result.value6;
                this.tbGLU.Text = select.m_Result.value5;
                this.tbKET.Text = select.m_Result.value4;
                this.tbBLD.Text = select.m_Result.value2;
                this.tbLEU.Text = select.m_Result.value9.ToString();//白细胞
                this.tbNIT.Text = select.m_Result.value8.ToString();//亚硝酸
                this.tbUBG.Text = select.m_Result.value1.ToString();//尿胆原
                this.tbBIL.Text = select.m_Result.value3.ToString();//胆红素
                this.tbPH.Text = select.m_Result.value7.ToString();//ph
                this.tbSG.Text = select.m_Result.value10.ToString();//比重
                this.tbVC.Text = select.m_Result.value11.ToString();//VC
            }
        }
    }
}
