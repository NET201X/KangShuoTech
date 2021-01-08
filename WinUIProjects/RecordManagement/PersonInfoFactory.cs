using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{
    using RecordManagement.Properties;
    
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;

    public  class PersonInfoFactory : ChildFormFactory
    {
        public PersonInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            
            this.ItemParamters.Add(new ItemParamters("封面信息", new Image[] { Resources.btnfengmian00, Resources.btnfengmian01, Resources.btnfengmian00 }));
            this.ItemParamters.Add(new ItemParamters("详细信息", new Image[] { Resources.btnxiangxi00, Resources.btnxiangxi01, Resources.btnxiangxi00 }));
            this.ItemParamters.Add(new ItemParamters("健康信息", new Image[] { Resources.btnjiankang00, Resources.btnjiankang01, Resources.btnjiankang00 }));
        }
        public PersonInfoFactory(int type)
        {
            this.ItemParamters = new List<ItemParamters>();

            switch (type)
            {
                case 1:
                    this.ItemParamters.Add(new ItemParamters("封面信息", new Image[] { Resources.btnfengmian00, Resources.btnfengmian01, Resources.btnfengmian00 }));
                    break;
                case 2:
                    this.ItemParamters.Add(new ItemParamters("详细信息", new Image[] { Resources.btnxiangxi00, Resources.btnxiangxi01, Resources.btnxiangxi00 }));
                    break;
                case 3:
                    this.ItemParamters.Add(new ItemParamters("健康信息", new Image[] { Resources.btnjiankang00, Resources.btnjiankang01, Resources.btnjiankang00 }));
                    break;
            }
        }
        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            PersonFileFrm iParentFrm = this.MControler.IParentFrm as PersonFileFrm;
            string str = name;
            if (str != null)
            {
                if (!(str == "封面信息"))
                {
                    if (str == "详细信息")
                    {
                        form = new PersonRecordInfoForm();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>) this.MControler.IParentFrm).Model;
                    }
                    else if (str == "健康信息")
                    {
                        form = new HealthInfoForm();
                        (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>) this.MControler.IParentFrm).Model;
                    }
                }
                else
                {
                    form = new RecordBaseInfoForm();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>) this.MControler.IParentFrm).Model;
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
                return "个人档案";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}

