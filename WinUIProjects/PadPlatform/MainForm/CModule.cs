using KangShuoTech.Utilities.CommonUI;

namespace PadPlatform
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    public class CModule
    {
        private ChildFormFactory _childFactory;
        private Controler _moduleControler;
        private const BindingFlags c_bf = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        private Button c_btn;
        private Form loadForm;
        public EventHandler ModuleCall;
        private UserControl ucMainItems;

        public event EventHandler ModuleCancelClick;

        private void its_cancel(object sender, EventArgs e)
        {
            if ((this.UCMainItems != null) && (this.ModuleCancelClick != null))
            {
                this.ModuleCancelClick(sender, e);
            }
        }

        public void ModuleEnd()
        {
            this._moduleControler = null;
        }

        private void picbox_Click(object sender, EventArgs e)
        {
            if ((this.UCMainItems != null) && (this.ModuleCall != null))
            {
                this.ModuleCall(this, e);
            }

            if ((this.LoadForm != null) && (this.ModuleCall != null))
            {
                this.ModuleCall(this, e);
            }

            if ((this.ModuleControler != null) && (this.ModuleCall != null))
            {
                this.ModuleCall(this, e);
            }
        }

        public void SetLoadFormIDCardNo(string idcard)
        {
            PropertyInfo property = this.loadForm.GetType().GetProperty("IDCard", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (property != null)
            {
                property.SetValue(this.loadForm, PadForm.idNo, null);
            }
        }

        public void SetModuleIDCardNo(string idcard)
        {
            PropertyInfo property = this.ucMainItems.GetType().GetProperty("IDCardNo", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (property != null)
            {
                property.SetValue(this.ucMainItems, PadForm.idNo, null);
            }
        }

        public Button C_Btn
        {
            get
            {
                return this.c_btn;
            }
            set
            {
                this.c_btn = value;
                if (this.c_btn != null)
                {
                    this.c_btn.Click += new EventHandler(this.picbox_Click);
                }
            }
        }

        public string FileName { get; set; }

        public string ImgName { get; set; }

        public string LcdOrder { get; set; }

        public Form LoadForm
        {
            get
            {
                if ((this.ModuleAssembly != null) && !string.IsNullOrEmpty(this.StrMainForms))
                {
                    this.loadForm = (Form) this.ModuleAssembly.CreateInstance(this.StrMainForms);
                }

                if (this.loadForm != null)
                {
                    PropertyInfo property = this.loadForm.GetType().GetProperty("IDCard", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    this.loadForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    this.loadForm.MaximizeBox = false;
                    this.loadForm.MinimizeBox = false;

                    if (property != null)
                    {
                        property.SetValue(this.loadForm, PadForm.idNo, null);
                    }
                }
                return this.loadForm;
            }
        }

        public Assembly ModuleAssembly { get; set; }

        public Controler ModuleControler
        {
            get
            {
                if (this._moduleControler == null)
                {
                    if ((this.ModuleAssembly != null) && !string.IsNullOrEmpty(this.StrFactory))
                    {
                        this._childFactory = (ChildFormFactory) this.ModuleAssembly.CreateInstance(this.StrFactory);
                    }
                    if (this._childFactory != null)
                    {
                        this._moduleControler = new Controler(new MDIParentForm(PadForm.idNo), this._childFactory);
                        this._moduleControler.Close = (Action) Delegate.Combine(this._moduleControler.Close, new Action(this.ModuleEnd));
                    }
                }
                return this._moduleControler;
            }
        }

        public string Name { get; set; }

        public string StrFactory { get; set; }

        public string StrMainForms { get; set; }

        public string StrMainItems { get; set; }

        public UserControl UCMainItems
        {
            get
            {
                if (this.ucMainItems == null)
                {
                    if ((this.ModuleAssembly != null) && !string.IsNullOrEmpty(this.StrMainItems))
                    {
                        this.ucMainItems = (UserControl) this.ModuleAssembly.CreateInstance(this.StrMainItems);
                    }

                    if (this.ucMainItems != null)
                    {
                        EventInfo info = this.ucMainItems.GetType().GetEvent("Cancel_Click", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                        EventHandler handler = new EventHandler(this.its_cancel);

                        if (handler != null && info != null)
                        {
                            info.AddEventHandler(this.ucMainItems, handler);
                        }

                        PropertyInfo property = this.ucMainItems.GetType().GetProperty("IDCardNo", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                        if (property != null)
                        {
                            property.SetValue(this.ucMainItems, PadForm.idNo, null);
                        }
                    }
                }

                return this.ucMainItems;
            }
        }
    }
}

