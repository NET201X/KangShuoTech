using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using System.Drawing;
using FocusGroup.Properties;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;

namespace FocusGroup.Query
{
    public class GroupDataListsSearchFactory : ChildFormFactory
    {
        public GroupDataListsSearchFactory()
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

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "老年人记录")
                {
                    form = new GroupDataListsSearch(str);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "高血压记录")
                {
                    form = new GroupDataListsSearch(str);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "糖尿病记录")
                {
                    form = new GroupDataListsSearch(str);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "冠心病记录")
                {
                    form = new GroupDataListsSearch(str);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "脑卒中记录")
                {
                    form = new GroupDataListsSearch(str);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "精神病记录")
                {
                    form = new GroupDataListsSearch(str);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "肺结核记录")
                {
                    form = new GroupDataListsSearch(str);
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }

            (form as Form).Text = name;
            form.HaveToSave = false;
            return form;
        }

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
