using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
 
    public class Controler : IMDIControler, IDisposable
    {
        public Controler(IParentForm iparent, ChildFormFactory factory)
        {
            this.IParentFrm = iparent;
            this.IParentFrm.IMDIControler = this;
            this.Factory = factory;
            this.Factory.MControler = this;
            iparent.SetFrmText(this.Factory.MDIFrmText);
            this.IParentFrm.SetChildrenButton(factory.ItemParamters);
            this.IChildrens = this.Factory.GetOneOrMoreForm();
        }

        public virtual void Call_Child(object sender, EventArgs e)
        {
            Control control = sender as Control;
            IChildForm child = this.CreateChild(control.Name);
            this.IParentFrm.ChildStatus(control.Name, ChildFormStatus.Activity);
            this.IParentFrm.ShowChild(child);
        }

        public IChildForm CreateChild(string ch)
        {
            IChildForm form = null;
            if (!this.IChildrens.TryGetValue(ch, out form))
            {
                form = this.Factory.CreateChildForm(ch);
                if (form == null)
                {
                    return form;
                }
                Form form2 = form as Form;
                form2.Text = ch;
                form2.TopLevel = false;
                ChildContentForm content = form as ChildContentForm;
                MDIParentForm iParentFrm = this.IParentFrm as MDIParentForm;
                if (content != null)
                {
                    content.upStateInfo = (Action<string>) Delegate.Combine(content.upStateInfo, new Action<string>(iParentFrm.SetStateInfo));
                }
                this.IChildrens.Add(ch, form);
            }
            return form;
        }

        public void Dispose()
        {
            this.Factory = null;
            foreach (KeyValuePair<string, IChildForm> pair in this.IChildrens)
            {
                Form form = pair.Value as Form;
                if (form != null)
                {
                    form.Close();
                }
            }
            Form iParentFrm = this.IParentFrm as Form;
            if (iParentFrm != null)
            {
                iParentFrm.Close();
            }
        }

        public virtual bool DoSave()
        {
            bool flag = true;
            this.SaveDataInfo = "保存失败！";
            foreach (KeyValuePair<string, IChildForm> pair in this.IChildrens)
            {
                if (pair.Value.EveryThingIsOk)
                {
                    pair.Value.SaveDataInfo = "";
                    pair.Value.UpdataToModel();
                    if (pair.Value.CheckErrorInput() == ChildFormStatus.HasErrorInput)
                    {
                        flag = false;
                        this.IParentFrm.ChildStatus(pair.Key, ChildFormStatus.HasErrorInput);
                        Controler controler = this;
                        string str = controler.SaveDataInfo + pair.Value.SaveDataInfo;
                        controler.SaveDataInfo = str;
                    }
                }
            }
            if (!flag)
            {
                return false;
            }
            foreach (KeyValuePair<string, IChildForm> pair2 in this.IChildrens)
            {
                if (pair2.Value.EveryThingIsOk)
                {
                    flag = pair2.Value.SaveModelToDB();
                }
            }
            if (!flag)
            {
                return false;
            }
            IParentModel<RecordsBaseInfoModel> iParentFrm = this.IParentFrm as IParentModel<RecordsBaseInfoModel>;
            if (iParentFrm != null)
            {
                iParentFrm.SaveModel();
            }
            return flag;
        }

        public Action Close
        {
            get
            {
                if (this.IParentFrm != null)
                {
                    return this.IParentFrm.FrmClose;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    this.IParentFrm.FrmClose = value;
                }
            }
        }

        public ChildFormFactory Factory { get; set; }

        public Dictionary<string, IChildForm> IChildrens { get; set; }

        public IParentForm IParentFrm { get; set; }

        public string SaveDataInfo { get; set; }
    }
}

