using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.Utilities.CommonUI;
using MedicalService.Properties;
using KangShuoTech.DataAccessProjects.Model;
using System.Windows.Forms;
using System.Drawing;

namespace MedicalService
{
    class ModifyFactory : ChildFormFactory
    {
        public ModifyFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("接诊修改", new Image[] { Resources.btnjiezhen00, Resources.btnjiezhen01, Resources.btnjiezhen01 }));
        }
        public ModifyFactory(int ID,string recordName)
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ID = ID;
            this.RecordsName = recordName;
            if (RecordsName == "接诊记录")
            {
                this.ItemParamters.Add(new ItemParamters("接诊修改", new Image[] { Resources.btnjiezhen00, Resources.btnjiezhen01, Resources.btnjiezhen01 }));
            }
            else if (RecordsName == "会诊记录")
            {
                this.ItemParamters.Add(new ItemParamters("会诊修改", new Image[] { Resources.btnhuizhen00, Resources.btnhuizhen01, Resources.btnhuizhen01 }));
            }
            else if (RecordsName == "转诊记录")
            {
                this.ItemParamters.Add(new ItemParamters("转诊修改", new Image[] { Resources.btnzhuanzhen00, Resources.btnzhuanzhen01, Resources.btnzhuanzhen01 }));
            }
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;
            if (str != null)
            {
                if (str == "会诊修改")
                {
                    form = new ConsulateModify {
                        ID=this.ID
                    };
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "接诊修改")
                {
                    form = new ReceiveTreatModify
                    {
                        ID = this.ID
                    };
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
                else if (str == "转诊修改")
                {
                    form = new ReferralModify
                    {
                        ID = this.ID
                    };
                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }

            (form as Form).Text = name;
            form.HaveToSave = true;
            return form;
        }

        public int ID { set; get; }
        public string RecordsName { set;get;}
        public override List<ItemParamters> ItemParamters { get; set; }

        public override IMDIControler MControler { get; set; }

        public override string MDIFrmText
        {
            get
            {
                return "医疗服务";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
