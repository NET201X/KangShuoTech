using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using FocusGroup.Properties;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.Kids
{
    internal class KidsFactory : ChildFormFactory
    {
        public KidsFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("儿童管理卡", new Image[] { Resources.btnjiben00, Resources.btnjiben01, Resources.btnjiben01 }));
            this.ItemParamters.Add(new ItemParamters("新生儿访视", new Image[] { Resources.btnxinshenger00, Resources.btnxinshenger01, Resources.btnxinshenger01 }));
            this.ItemParamters.Add(new ItemParamters("1-8月内检查", new Image[] { Resources.btn1jiancha00, Resources.btn1jiancha01, Resources.btn1jiancha01 }));
            this.ItemParamters.Add(new ItemParamters("12-30月内检查", new Image[] { Resources.btn1_2jiancha00, Resources.btn1_2jiancha01, Resources.btn1_2jiancha01 }));
            this.ItemParamters.Add(new ItemParamters("3-6岁内检查", new Image[] { Resources.btn3_6jiancha00, Resources.btn3_6jiancha01, Resources.btn3_6jiancha01 }));
            this.ItemParamters.Add(new ItemParamters("中医药管理", new Image[] { Resources.btnzhongyiyao00, Resources.btnzhongyiyao01, Resources.btnzhongyiyao01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (!(str == "儿童管理卡"))
                {
                    if (str == "1-8月内检查")
                    {
                        form = new KidsInOneYearOldVisitForm();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                    else if (str == "新生儿访视")
                    {
                        form = new FrmNewBornVisit();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                    else if (str == "12-30月内检查")
                    {
                        form = new KidsOneToTwoVisitForm();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                    else if (str == "3-6岁内检查")
                    {
                        form = new KidsThreeToSixVisitForm();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                    else if (str == "中医药管理")
                    {
                        form = new FrmChlTcmhmOne();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                }
                else
                {
                    form = new KidsInfoForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }
            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public static int ID { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "儿童管理";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}

