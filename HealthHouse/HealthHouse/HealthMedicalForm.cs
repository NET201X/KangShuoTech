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
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.BLL;

namespace HealthHouse
{
    public partial class HealthMedicalForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private Physique pinghezhi;
        private Physique qixuzhi;
        private Physique qiyuzhi;
        private Physique shirezhi;
        private Physique tanshizhi;
        private Physique tejianzhi;
        private Physique tingli;
        private Physique xueyuzhi;
        private Physique yangxuzhi;
        private Physique yinxuzhi;
        private HealthHouseMediPhyModel HHMediphy;
        private HealthHouseMedicineCnModel HHMediCn;
        private HealthHouseMedicineResultModel HHMediRes;
        private HealthHouseMediPhyBLL MediPyBLL = new HealthHouseMediPhyBLL();
        private HealthHouseMedicineCnBLL MediCnBll = new HealthHouseMedicineCnBLL();
        private HealthHouseMedicineResultBLL MediResBLL = new HealthHouseMedicineResultBLL();
        public HealthMedicalForm()
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
            this.HHMediphy = this.MediPyBLL.GetModel(HealthHouseFactory.ID);
            if (this.HHMediphy == null)
            {
                this.HHMediphy = new HealthHouseMediPhyModel();
                this.HHMediphy.IDCardNo = this.Model.IDCardNo;
            }
            else
            {
                this.HHMediCn = this.MediCnBll.GetModel(this.HHMediphy.MedicineID);
                this.HHMediRes = this.MediResBLL.GetModel(this.HHMediphy.MedicineResultID);
            }
            this.HealthModel = new HealthHouseBLL().GetDataByID(HealthHouseFactory.ID);
            if (this.HealthModel == null)
            {
                this.HealthModel = new HealthHouseModel();
            }
            this.pinghezhi = new Physique(this.radshipinghe, this.radjibenpinghe, this.HHMediphy.Mild);
            this.qixuzhi = new Physique(this.radshiqixu, this.radqingqixu, this.HHMediphy.Faint);
            this.yangxuzhi = new Physique(this.radshiyangxu, this.radqingyangxu, this.HHMediphy.Yang);
            this.yinxuzhi = new Physique(this.radshiyinxu, this.radqingyinxu, this.HHMediphy.Yin);
            this.tanshizhi = new Physique(this.radshitanshi, this.radqingtanshi, this.HHMediphy.PhlegmDamp);
            this.shirezhi = new Physique(this.radshishire, this.radqingshire, this.HHMediphy.Muggy);
            this.xueyuzhi = new Physique(this.radshixueyu, this.radqingxueyu, this.HHMediphy.BloodStasis);
            this.qiyuzhi = new Physique(this.radshiqiyu, this.radqingqiyu, this.HHMediphy.QiConstraint);
            this.tejianzhi = new Physique(this.radshitejian, this.radqingtejian, this.HHMediphy.Characteristic);
            this.EveryThingIsOk = true;
        }
        private void btnElderM_Click(object sender, EventArgs e)
        {
            HealthOldMedEX dex = new HealthOldMedEX(this.Model)
            {
                phy = this.HHMediphy,
                MedCn = this.HHMediCn,
                MedResult = this.HHMediRes,
                HealthModel = this.HealthModel,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = "中医体质判定",
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false

            };
            dex.PhysicalItem();
            dex.StartPosition = FormStartPosition.CenterParent;
            if (dex.ShowDialog() == DialogResult.OK)
            {
                this.pinghezhi.Reset(this.HHMediphy.Mild);
                this.qixuzhi.Reset(this.HHMediphy.Faint);
                this.yangxuzhi.Reset(this.HHMediphy.Yang);
                this.yinxuzhi.Reset(this.HHMediphy.Yin);
                this.tanshizhi.Reset(this.HHMediphy.PhlegmDamp);
                this.shirezhi.Reset(this.HHMediphy.Muggy);
                this.xueyuzhi.Reset(this.HHMediphy.BloodStasis);
                this.qiyuzhi.Reset(this.HHMediphy.QiConstraint);
                this.tejianzhi.Reset(this.HHMediphy.Characteristic);
                this.HHMediCn = dex.MedCn;
                this.HHMediRes = dex.MedResult;
            }
        }
        public bool SaveModelToDB()
        {
            if (this.HHMediphy == null)
            {
                return false;
            }
            this.HHMediphy.PID = HealthHouseFactory.ID;
            HealthHouseMediPhyModel MediPhyTem = this.MediPyBLL.GetModel(HealthHouseFactory.ID);
            if (MediPhyTem == null)//新增
            {
                if (this.HHMediCn != null)
                {
                    this.HHMediphy.MedicineID = this.MediCnBll.Add(this.HHMediCn);
                }
                this.MediPyBLL.Add(this.HHMediphy);
             
            }
            else
            {
                if (this.HHMediCn != null)
                {
                    if (this.HHMediphy.MedicineID == 0)//中医体质中，无体质辨识问卷
                    {
                        this.HHMediphy.MedicineID = this.MediCnBll.Add(this.HHMediCn);
                    }
                    else //中医体质中，有体质辨识问卷
                    {
                        this.HHMediCn.ID = MediPhyTem.MedicineID;
                        this.HHMediphy.MedicineID = MediPhyTem.MedicineID;
                        this.MediCnBll.Update(this.HHMediCn);
                    }
                }
                if (this.HHMediRes != null)
                {
                    if (this.HHMediphy.MedicineResultID == 0)//中医体质中，无体质辨识问卷
                    {
                        this.HHMediphy.MedicineResultID = this.MediResBLL.Add(this.HHMediRes);
                    }
                    else //中医体质中，有体质辨识问卷
                    {
                        this.HHMediRes.ID = MediPhyTem.MedicineResultID;
                        this.HHMediphy.MedicineResultID = MediPhyTem.MedicineResultID;
                        this.MediResBLL.Update(this.HHMediRes);
                    }
                }
                this.MediPyBLL.Update(this.HHMediphy);
            }
            return true;
        }
        public void NotisfyChildStatus()
        {
        }
        public void UpdataToModel()
        {
            this.HHMediphy.IDCardNo = this.Model.IDCardNo;
            this.HHMediphy.Mild = this.pinghezhi.Result;
            this.HHMediphy.Faint = this.qixuzhi.Result;
            this.HHMediphy.Yang = this.yangxuzhi.Result;
            this.HHMediphy.Yin = this.yinxuzhi.Result;
            this.HHMediphy.PhlegmDamp = this.tanshizhi.Result;
            this.HHMediphy.Muggy = this.shirezhi.Result;
            this.HHMediphy.BloodStasis = this.xueyuzhi.Result;
            this.HHMediphy.QiConstraint = this.qiyuzhi.Result;
            this.HHMediphy.Characteristic = this.tejianzhi.Result;
        }
        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public string SaveDataInfo { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public HealthHouseModel HealthModel { get; set; }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.pinghezhi.Reset();
            this.qixuzhi.Reset();
            this.yangxuzhi.Reset();
            this.yinxuzhi.Reset();
            this.tanshizhi.Reset();
            this.shirezhi.Reset();
            this.xueyuzhi.Reset();
            this.qiyuzhi.Reset();
            this.tejianzhi.Reset();
        }
        internal class Physique
        {
            public Physique(RadioButton r1, RadioButton r2, string info)
            {
                this.Rd1 = r1;
                this.Rd2 = r2;
                this.Result = info;
            }

            public Physique(string name, RadioButton r1, RadioButton r2, string info)
            {
                this.Rd1 = r1;
                this.Rd2 = r2;
                this.Name = name;
                this.Result = info;
            }

            public void Reset()
            {
                this.Rd1.Checked = false;
                this.Rd2.Checked = false;
            }

            public void Reset(string val)
            {
                if (!string.IsNullOrEmpty(val))
                {
                    this.Result = val;
                }
                else
                {
                    this.Reset();
                }
            }

            public string Name { get; set; }

            public RadioButton Rd1 { get; set; }

            public RadioButton Rd2 { get; set; }

            public string Result
            {
                get
                {
                    if (this.Rd1.Checked)
                    {
                        return "1";
                    }
                    if (this.Rd2.Checked)
                    {
                        return "2";
                    }
                    return null;
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value == "1")
                        {
                            this.Rd1.Checked = true;
                        }
                        else if (value == "2")
                        {
                            this.Rd2.Checked = true;
                        }
                    }
                    else if ((this.Name == "运动") || (this.Name == "听力"))
                    {
                        this.Rd1.Checked = true;
                    }
                }
            }
        }

        private void HealthMedicalForm_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }
    }
}
