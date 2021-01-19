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
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using System.IO;


namespace ArchiveInfo
{
    public partial class frmHyperSurvey : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private SimpleBindingManager<RecordsHyperSurveyModel> bindingManagersurvey;
        private List<InputRangeDec> inputRangessurvey =new List<InputRangeDec> ();
        private List<InputRangeStr> inputrange_str =new List<InputRangeStr> ();
        private List<YesNoControl> foodControl = new List<YesNoControl>();
        public frmHyperSurvey()
        {
            InitializeComponent();
            foodControl.Add(this.FoodXDControl);
            foodControl.Add(this.FoodXYControl);
            foodControl.Add(this.FoodXPControl);
            foodControl.Add(this.FoodXMControl);
            foodControl.Add(this.FoodFBMControl);
            foodControl.Add(this.FoodDFRControl);
            foodControl.Add(this.FoodXCControl);
            foodControl.Add(this.FoodLJJControl);
            foodControl.Add(this.FoodXJControl);
            foodControl.Add(this.FoodTMJControl);
            foodControl.Add(this.FoodDBJControl);
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }
    
        public void InitEveryThing()
        {
            this.HyperSurveyModel = new RecordsHyperSurveyBLL().GetModel(PhysicalInfoFactory.ID);
            this.HyperFoodsModel = new RecordsHyperFoodsBLL().GetModelList(string.Format("IDCardNo = '{0}' and OutKey={1}", this.Model.IDCardNo,PhysicalInfoFactory.ID));
            if (this.HyperSurveyModel == null)
            {
                HyperSurveyModel = new RecordsHyperSurveyModel();
                HyperSurveyModel.IDCardNo = Model.IDCardNo;
            }
           
            this.tbName.Text = Model.CustomerName;

            this.bindingManagersurvey = new SimpleBindingManager<RecordsHyperSurveyModel>(this.inputRangessurvey, this.inputrange_str, this.HyperSurveyModel);
            this.bindingManagersurvey.SimpleBindingInt(this.txbPersonSum, "EatPersonSum", true);
            this.bindingManagersurvey.SimpleBindingInt(this.txbPersonChild, "EatChildSum", true);
            this.bindingManagersurvey.SimpleBinding(this.txbSalt, "EatSaltQuantity", true);
            this.bindingManagersurvey.SimpleBinding(this.txbSoy, "EatSoyQuntity", true);

            for (int k = 0; k < this.foodControl.Count; k++)
            {
                if (k < HyperFoodsModel.Count)
                {
                    switch (HyperFoodsModel[k].FoodName)
                    {
                        case "咸蛋": this.foodControl[0].Source = this.HyperFoodsModel[k]; break;
                        case "咸鱼": this.foodControl[1].Source = this.HyperFoodsModel[k]; break;
                        case "虾皮": this.foodControl[2].Source = this.HyperFoodsModel[k]; break;
                        case "虾米": this.foodControl[3].Source = this.HyperFoodsModel[k]; break;
                        case "方便面": this.foodControl[4].Source = this.HyperFoodsModel[k]; break;
                        case "豆腐乳": this.foodControl[5].Source = this.HyperFoodsModel[k]; break;
                        case "咸菜": this.foodControl[6].Source = this.HyperFoodsModel[k]; break;
                        case "辣椒酱": this.foodControl[7].Source = this.HyperFoodsModel[k]; break;
                        case "虾酱": this.foodControl[8].Source = this.HyperFoodsModel[k]; break;
                        case "甜面酱": this.foodControl[9].Source = this.HyperFoodsModel[k]; break;
                        case "豆瓣酱": this.foodControl[10].Source = this.HyperFoodsModel[k]; break;
                        default: break;
                    }
                }
            }
            for (int k = 0; k < this.foodControl.Count; k++)
            {
                if (this.foodControl[k].Source == null)
                {
                    RecordsHyperFoodsModel recordsHyperFoodsModel = new RecordsHyperFoodsModel
                    {
                        IDCardNo = this.Model.IDCardNo,
                        ModelState = RecordsStateModel.AddToDB
                    };
                    this.foodControl[k].Source = recordsHyperFoodsModel;
                }
                else
                {
                    this.foodControl[k].Source.ModelState = RecordsStateModel.UpdateInDB;
                }
            }

           this.EveryThingIsOk = true;
        }
        private void frmHyperSurvey_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void NotisfyChildStatus()
        {

        }

        public bool SaveModelToDB()
        {
            if (this.HyperSurveyModel != null)
            {
                RecordsHyperSurveyBLL recordsHyperSurveyBLL = new RecordsHyperSurveyBLL();
                this.HyperSurveyModel.OutKey = PhysicalInfoFactory.ID;
                if (!recordsHyperSurveyBLL.ExistsOutKey(this.HyperSurveyModel.IDCardNo,PhysicalInfoFactory.ID))
                {
                    recordsHyperSurveyBLL.Add(this.HyperSurveyModel);
                }
                else
                {
                    recordsHyperSurveyBLL.Update(this.HyperSurveyModel);
                }
            }
            
            SaveHyperFoods();
            return true;
        }
        private void SaveHyperFoods()
        {
            RecordsHyperFoodsBLL recordsHyperFoodsBLL = new RecordsHyperFoodsBLL();

            foreach (RecordsHyperFoodsModel recordsHyperFoodsModel in this.HyperFoodsModel)
            {
                recordsHyperFoodsModel.OutKey = PhysicalInfoFactory.ID;
                if (!recordsHyperFoodsBLL.ExistsOutKey(recordsHyperFoodsModel.IDCardNo,recordsHyperFoodsModel.FoodName, PhysicalInfoFactory.ID))
                {
                    recordsHyperFoodsBLL.Add(recordsHyperFoodsModel);
                }
                else
                {
                    if (recordsHyperFoodsModel.ModelState == RecordsStateModel.AddToDB)
                    {
                        recordsHyperFoodsBLL.Add(recordsHyperFoodsModel);
                    }
                    else if (recordsHyperFoodsModel.ModelState == RecordsStateModel.UpdateInDB)
                    {
                        recordsHyperFoodsBLL.Update(recordsHyperFoodsModel);
                    }
                }
              
            }
        }
        public void UpdataToModel()
        {
            for (int k = 0; k < this.foodControl.Count; k++)
            {
                switch (k)
                {
                    case 0: this.foodControl[k].Source.FoodName = this.labxd.Text; break;
                    case 1: this.foodControl[k].Source.FoodName = this.labxy.Text; break;
                    case 2: this.foodControl[k].Source.FoodName = this.labxp.Text; break;
                    case 3: this.foodControl[k].Source.FoodName = this.labxm.Text; break;
                    case 4: this.foodControl[k].Source.FoodName = this.labfbm.Text; break;
                    case 5: this.foodControl[k].Source.FoodName = this.labdfr.Text; break;
                    case 6: this.foodControl[k].Source.FoodName = this.labxc.Text; break;
                    case 7: this.foodControl[k].Source.FoodName = this.labljj.Text; break;
                    case 8: this.foodControl[k].Source.FoodName = this.labxj.Text; break;
                    case 9: this.foodControl[k].Source.FoodName = this.labtmj.Text; break;
                    case 10: this.foodControl[k].Source.FoodName = this.labdbj.Text; break;
                    default: break;
                }
                this.foodControl[k].UpdateSource();
                if (this.foodControl[k].Source.ModelState == RecordsStateModel.AddToDB)
                {
                    this.HyperFoodsModel.Add(this.foodControl[k].Source);
                }
            }
        }


        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsHyperSurveyModel HyperSurveyModel { get; set; }
        public List<RecordsHyperFoodsModel> HyperFoodsModel { get; set; }

        public string SaveDataInfo { get; set; }



    }
}
