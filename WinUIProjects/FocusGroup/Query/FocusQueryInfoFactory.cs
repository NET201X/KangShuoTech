using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup
{
    using Properties;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Drawing;
    using FocusGroup.OldPeople;
    using FocusGroup.elderInfo;
    using FocusGroup.ChronicDisease;

    public class FocusQueryInfoFactory : ChildFormFactory
    {
        public FocusQueryInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("老年人记录", new Image[] { Resources.btnlaonianren00, Resources.btnlaonianren01, Resources.btnlaonianren01 }));
            this.ItemParamters.Add(new ItemParamters("高血压记录", new Image[] { Resources.btngaoxueya00, Resources.btngaoxueya01, Resources.btngaoxueya01 }));
            this.ItemParamters.Add(new ItemParamters("糖尿病记录", new Image[] { Resources.btntangniaobing00, Resources.btntangniaobing01, Resources.btntangniaobing01 }));
            this.ItemParamters.Add(new ItemParamters("冠心病记录", new Image[] { Resources.btnguanxinbing00, Resources.btnguanxinbing01, Resources.btnguanxinbing01 }));
            this.ItemParamters.Add(new ItemParamters("脑卒中记录", new Image[] { Resources.btnnaocuzhong00, Resources.btnnaocuzhong01, Resources.btnnaocuzhong01 }));
            this.ItemParamters.Add(new ItemParamters("精神病记录", new Image[] { Resources.btnjingshenjibing00, Resources.btnjingshenjibing01, Resources.btnjingshenjibing01 }));
            this.ItemParamters.Add(new ItemParamters("肺结核记录", new Image[] { Resources.btnfeijiehe00, Resources.btnfeijiehe01, Resources.btnfeijiehe01 }));
        }

        public FocusQueryInfoFactory(int ID, string recordName)
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ID = ID;
            this.RecordsName = recordName;
            if (this.RecordsName == "老年人记录")
            {
                this.ItemParamters.Add(new ItemParamters("健康评估", new Image[] { Resources.btnjiankangpinggu00, Resources.btnjiankangpinggu01, Resources.btnjiankangpinggu01 }));
                this.ItemParamters.Add(new ItemParamters("中医保健", new Image[] { Resources.btnzhongyibaojian00, Resources.btnzhongyibaojian01, Resources.btnzhongyibaojian01 }));
            }
            else if (this.RecordsName == "高血压记录")
            {
                this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
                this.ItemParamters.Add(new ItemParamters("随访信息", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
                
            }
            else if (this.RecordsName == "糖尿病记录")
            {
                this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
                this.ItemParamters.Add(new ItemParamters("随访信息", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));

            }
            else if (this.RecordsName == "冠心病记录")
            {
                this.ItemParamters.Add(new ItemParamters("患者随访", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
            }
            else if (this.RecordsName == "脑卒中记录")
            {
                this.ItemParamters.Add(new ItemParamters("患者随访", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
            }
            else if (this.RecordsName == "精神病记录")
            {
                this.ItemParamters.Add(new ItemParamters("基本信息", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
                this.ItemParamters.Add(new ItemParamters("随访记录", new Image[] { Resources.suifang00, Resources.suifang01, Resources.suifang01 }));
            }
            else if (this.RecordsName == "肺结核记录")
            {
                this.ItemParamters.Add(new ItemParamters("第1次入户随访", new Image[] { Resources.btnruhu00, Resources.btnruhu01, Resources.btnruhu01 }));
                this.ItemParamters.Add(new ItemParamters("随访服务信息1", new Image[] { Resources.btnfeijiehe100, Resources.btnfeijiehe101, Resources.btnfeijiehe101 }));
                this.ItemParamters.Add(new ItemParamters("随访服务信息2", new Image[] { Resources.btnfeijiehe200, Resources.btnfeijiehe201, Resources.btnfeijiehe201 }));
                this.ItemParamters.Add(new ItemParamters("随访服务信息3", new Image[] { Resources.btnfeijiehe300, Resources.btnfeijiehe301, Resources.btnfeijiehe301 }));
                this.ItemParamters.Add(new ItemParamters("随访服务信息4", new Image[] { Resources.btnfeijiehe400, Resources.btnfeijiehe401, Resources.btnfeijiehe401}));
            }
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null &&　!string.IsNullOrEmpty(this.RecordsName))
            {
               switch (RecordsName)
               {
                   case "老年人记录":
                       OldPeopleInfoFactory.ID = this.ID;
                       if (!(str == "健康评估"))
                       {
                           if (str == "中医保健")
                           {
                               form = new FrmOldMedEX();
                              
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }
                       }
                       else
                       {
                           form = new OldPeopleInfoForm();
                           (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                       }
                       break;
                   case "高血压记录":
                       if (!(str == "基本信息"))
                       {
                           if (str == "随访信息")
                           {
                               form = new HypVisitForm { IDPerson = this.ID };
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }
                       }
                       else
                       {
                           form = new HypInfoForm();
                           (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                       }
                       break;
                   case "糖尿病记录":
                       if (!(str == "基本信息"))
                       {
                           if (str == "随访信息")
                           {
                               form = new DiaVisitForm { IDPerson = this.ID };
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }
                       }
                       else
                       {
                           form = new DiaInfoForm();
                           (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                       }
                       break;
                   case "冠心病记录":
                       if (str == "患者随访")
                       {
                           form = new CHDVisitForm { IDPerson = this.ID };
                           (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                       }
                       break;
                   case "脑卒中记录":
                       if (str == "患者随访")
                       {
                           form = new StrokeVisitForm { IDPerson =this.ID};
                           (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                       }
                       break;
                   case "精神病记录":
                       if (!(str == "基本信息"))
                       {
                           if (str == "随访记录")
                           {
                               form = new MentalVisitForm { IDPerson = this.ID };
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }
                       }
                       else
                       {
                           form = new MentalInfoForm();
                           (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                       }
                       break;
                   case "肺结核记录":
                       PTBFactory.ID = this.ID;
                       if (!(str == "第1次入户随访"))
                       {
                           if (str == "随访服务信息1")
                           {
                               form = new PTBVisitForm("1") { IDPerson = this.ID };
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }

                           if (str == "随访服务信息2")
                           {
                               form = new PTBVisitForm("2") { IDPerson = this.ID };
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }

                           if (str == "随访服务信息3")
                           {
                               form = new PTBVisitForm("3") { IDPerson = this.ID };
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }

                           if (str == "随访服务信息4")
                           {
                               form = new PTBVisitForm("4") { IDPerson = this.ID };
                               (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                           }
                       }
                       else
                       {
                           form = new PTBInfoForm { IDPerson = this.ID };
                           (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                       }
                       break;
                 
                   default: break;
               }
            }

            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }
        public int ID { set; get; }

        public string RecordsName { set; get; }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "随访人群";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
