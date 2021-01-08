using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OverView.Properties;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using RecordManagement.Properties;

namespace RecordManagement.OverView
{
    public class LeaveOutInfoFactory : ChildFormFactory
    {

        public LeaveOutInfoFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("个人档案", new Image[] { Resources.btngerenxinxi00, Resources.btngerenxinxi01, Resources.btngerenxinxi01 }));
            this.ItemParamters.Add(new ItemParamters("健康信息", new Image[] { Resources.btntijianxinxi00, Resources.btntijianxinxi01, Resources.btntijianxinxi01 }));
            this.ItemParamters.Add(new ItemParamters("老年人", new Image[] { Resources.btnlaonianren00, Resources.btnlaonianren01, Resources.btnlaonianren01 }));
            this.ItemParamters.Add(new ItemParamters("高血压", new Image[] { Resources.btngaoxueya00, Resources.btngaoxueya01, Resources.btngaoxueya01 }));
            this.ItemParamters.Add(new ItemParamters("糖尿病", new Image[] { Resources.btntangniaobing00, Resources.btntangniaobing01, Resources.btntangniaobing01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;

            if (str != null)
            {

                if (str == "个人档案")
                {
                    form = new frmOutBaseInfo();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "健康体检")
                {
                    form = new frmOutInfoQuery();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "老年人")
                {
                    form = new frmOutOldMen();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "高血压")
                {
                    form = new frmOutHyper();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "糖尿病")
                {
                    form = new frmOutDiabete();
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }

            (form as Form).Text = name;
            form.HaveToSave = false;
            return form;
        }

        public override List<ItemParamters> ItemParamters
        {
            get;
            set;
        }

        public override IMDIControler MControler
        {
            get;
            set;
        }
        public override string MDIFrmText
        {
            get
            {
                return "漏项统计";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
