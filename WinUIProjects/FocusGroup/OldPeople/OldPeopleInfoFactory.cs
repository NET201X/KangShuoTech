using FocusGroup.elderInfo;
using FocusGroup.Properties;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Drawing;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace FocusGroup.OldPeople
{
    public  class OldPeopleInfoFactory : ChildFormFactory
    {
        public OldPeopleInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("健康评估", new Image[] { Resources.btnjiankangpinggu00, Resources.btnjiankangpinggu01, Resources.btnjiankangpinggu01 }));
            this.ItemParamters.Add(new ItemParamters("中医保健", new Image[] { Resources.btnzhongyibaojian00, Resources.btnzhongyibaojian01, Resources.btnzhongyibaojian01 }));
        }
        public OldPeopleInfoFactory(int type)
        {
            this.ItemParamters = new List<ItemParamters>();

            switch (type)
            {
                case 1:
                    this.ItemParamters.Add(new ItemParamters("中医保健", new Image[] { Resources.btnzhongyibaojian00, Resources.btnzhongyibaojian01, Resources.btnzhongyibaojian01 }));
                    break;

            }
        }
        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
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
            }
            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }

        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "老年人管理";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }

        public List<string> Strs_Children { get; set; }
        public static int ID { get; set; }
    }
}

