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
using KangShuoTech.Utilities.Common;

namespace HealthHouse
{
    public partial class HealthAssessSetExForm : Form
    {
        private List<HealthOverviewSetModel> SetList=new List<HealthOverviewSetModel>();
        private HealthOverviewSetModel SetTempModel { get; set; }
        private HealthOverviewSetBLL setbll = new HealthOverviewSetBLL();
        public HealthAssessSetExForm()
        {
            InitializeComponent();
        }
        private void SimpleBinding(TextBox tb, object src, string srcMember)
        {
            tb.ImeMode = ImeMode.On;
            Binding binding = new Binding("Text", src, srcMember, true, DataSourceUpdateMode.OnPropertyChanged);
            tb.DataBindings.Add(binding);

        }
        private void HealthAssessSetExForm_Load(object sender, EventArgs e)
        {
            SetList=setbll.GetList("");
            if (SetList == null)
            {
                SetList = new List<HealthOverviewSetModel>();
                for (int i = 1; i < 21; i++)
                {
                    SetTempModel = new HealthOverviewSetModel();
                    SetTempModel.Type = i.ToString();
                    SetTempModel.CreateDate = new DateTime?(DateTime.Today);
                    SetTempModel.CreateBy = ConfigHelper.GetNode("doctorName");
                    SetList.Add(SetTempModel);
                }
            }
            foreach (HealthOverviewSetModel hs in SetList)
            {
                if (hs.Type == "1")//体质指数
                {
                    SimpleBinding(this.tbBLRang, hs, "maxValues");
                    SimpleBinding(this.tbBHRang, hs, "minValues");
                    SimpleBinding(this.tbBHadvice, hs, "MaxEx");
                    SimpleBinding(this.tbBLadvice, hs, "MinEx");
                }
                else if (hs.Type == "2")//血压
                {
                    if (!string.IsNullOrEmpty(hs.maxValues))
                    {
                        string[] strmax = hs.maxValues.Split('/');
                        if (strmax.Length == 2)
                        {
                            this.tbXHRang.Text = strmax[0];
                            this.tbXLRang.Text = strmax[1];
                        }
                        else
                        {
                            this.tbXHRang.Text = strmax[0];
                        }
                    }
                    if (!string.IsNullOrEmpty(hs.minValues))
                    {
                        string[] strmin = hs.minValues.Split('/');
                        if (strmin.Length == 2)
                        {
                            this.tbXHRang2.Text = strmin[0];
                            this.tbXLRang2.Text = strmin[1];
                        }
                        else
                        {
                            this.tbXHRang2.Text = strmin[0];
                        }
                    }
                    SimpleBinding(this.tbXHadvice, hs, "MaxEx");
                    SimpleBinding(this.tbXLadvice, hs, "MinEx");
                }
                else if (hs.Type == "3")//心率
                {
                    SimpleBinding(this.tbPHRang, hs, "maxValues");
                    SimpleBinding(this.tbPLRang, hs, "minValues");
                    SimpleBinding(this.tbPHadvice, hs, "MaxEx");
                    SimpleBinding(this.tbPLadvice, hs, "MinEx");
                }
                else if (hs.Type == "4")//血氧
                {
                    SimpleBinding(this.tbOHRang, hs, "maxValues");
                    SimpleBinding(this.tbOLRang, hs, "minValues");
                    SimpleBinding(this.tbOHadvice, hs, "MaxEx");
                    SimpleBinding(this.tbOLadvice, hs, "MinEx");
                }
                else if (hs.Type == "5")//胸部X线片
                {
                    SimpleBinding(this.tbCadvice, hs, "Content");
                }
                else if (hs.Type == "6")//心电
                {
                    SimpleBinding(this.tbECGadvice, hs, "Content");
                }
                else if (hs.Type == "7")//B超
                {
                    SimpleBinding(this.tbBchaoadvice, hs, "Content");
                }
                else if (hs.Type == "8")//心血管
                {
                    SimpleBinding(this.tbVadvice, hs, "Content");
                }
                else if (hs.Type == "9")//肺功能
                {
                    SimpleBinding(this.tbLadvice, hs, "Content");
                }
                else if (hs.Type == "10")//骨密度
                {
                    SimpleBinding(this.tbBoneadvice, hs, "Content");
                }
                else if (hs.Type == "11")//尿常规
                {
                    SimpleBinding(this.tbNadvice, hs, "Content");
                }
                else if (hs.Type == "12") //平和质
                {
                    SimpleBinding(this.tbphz, hs, "Content");
                }
                else if (hs.Type == "13") //气虚质
                {
                    SimpleBinding(this.tbqxz, hs, "Content");
                }
                else if (hs.Type == "14") //阳虚质
                {
                    SimpleBinding(this.tbyangxz, hs, "Content");
                }
                else if (hs.Type == "15") //阴虚质
                {
                    SimpleBinding(this.tbyinxz, hs, "Content");
                }
                else if (hs.Type == "16") //痰湿质
                {
                    SimpleBinding(this.tbtansz, hs, "Content");
                }
                else if (hs.Type == "17") //湿热质
                {
                    SimpleBinding(this.tbshirz, hs, "Content");
                }
                else if (hs.Type == "18") //血瘀质
                {
                    SimpleBinding(this.tbxueyz, hs, "Content");
                }
                else if (hs.Type == "19") //气郁质
                {
                    SimpleBinding(this.tbqiyz, hs, "Content");
                }
                else if (hs.Type == "20") //特兼质
                {
                    SimpleBinding(this.tbtebz, hs, "Content");
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (HealthOverviewSetModel hs in SetList)
            {
                if (hs.Type == "2")//血压
                {
                    hs.maxValues = this.tbXHRang.Text.Trim() + "/" + this.tbXLRang.Text.Trim();
                    hs.minValues = this.tbXHRang2.Text.Trim() + "/" + this.tbXLRang2.Text.Trim();
                }
                hs.UpdateDate = new DateTime?(DateTime.Today);
                hs.UpdateBy = ConfigHelper.GetNode("doctorName");
                if (!setbll.Update(hs))
                {
                    setbll.Add(hs);
                }
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

    }
}
