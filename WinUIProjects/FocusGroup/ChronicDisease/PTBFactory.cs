using System;
using System.Collections.Generic;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using FocusGroup.Properties;
using System.Drawing;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Forms;

namespace FocusGroup
{
    public class PTBFactory : ChildFormFactory
    {
        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "肺结核管理";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }

        public PTBFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("第1次入户随访", new Image[] { Resources.btnruhu00, Resources.btnruhu01, Resources.btnruhu01 }));
            this.ItemParamters.Add(new ItemParamters("随访服务信息1", new Image[] { Resources.btnfeijiehe100, Resources.btnfeijiehe101, Resources.btnfeijiehe101 }));
            this.ItemParamters.Add(new ItemParamters("随访服务信息2", new Image[] { Resources.btnfeijiehe200, Resources.btnfeijiehe201, Resources.btnfeijiehe201 }));
            this.ItemParamters.Add(new ItemParamters("随访服务信息3", new Image[] { Resources.btnfeijiehe300, Resources.btnfeijiehe301, Resources.btnfeijiehe301 }));
            this.ItemParamters.Add(new ItemParamters("随访服务信息4", new Image[] { Resources.btnfeijiehe400, Resources.btnfeijiehe401, Resources.btnfeijiehe401
            }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (!(str == "第1次入户随访"))
                {
                    if (str == "随访服务信息1")
                    {
                        form = new PTBVisitForm("1");
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }

                    if (str == "随访服务信息2")
                    {
                        form = new PTBVisitForm("2");
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }

                    if (str == "随访服务信息3")
                    {
                        form = new PTBVisitForm("3");
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }

                    if (str == "随访服务信息4")
                    {
                        form = new PTBVisitForm("4");
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                    }
                }
                else
                {
                    form = new PTBInfoForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }

            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }
        public static int ID { set; get; }
        public static bool NewAdd { set; get; }

        public static int PtbID { get; set; }
    }
}
