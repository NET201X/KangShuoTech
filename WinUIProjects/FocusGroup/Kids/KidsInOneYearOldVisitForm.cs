using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using System.IO;
using System.Configuration;

namespace FocusGroup.Kids
{
    public class KidsInOneYearOldVisitForm : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private IContainer components;
        private KidsWithinOneYearOldVisitForm f1;
        private KidsWithinOneYearOldVisitForm f2;
        private KidsWithinOneYearOldVisitForm f3;
        private KidsWithinOneYearOldVisitForm f4;

        private Crownwood.Magic.Controls.TabControl tabControl1;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public KidsInOneYearOldVisitForm()
        {
            this.InitializeComponent();
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            ChildFormStatus noErrorInput = ChildFormStatus.NoErrorInput;
            if (this.f1.EveryThingIsOk)
            {
                noErrorInput = this.f1.CheckErrorInput();
            }
            if (this.f2.EveryThingIsOk)
            {
                noErrorInput |= this.f2.CheckErrorInput();
            }
            if (this.f3.EveryThingIsOk)
            {
                noErrorInput |= this.f3.CheckErrorInput();
            }
            if (this.f4.EveryThingIsOk)
            {
                noErrorInput |= this.f4.CheckErrorInput();
            }
            return noErrorInput;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmChildInAge1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void InitEveryThing()
        {
            this.f1 = new KidsWithinOneYearOldVisitForm(1);
            this.f1.Model = this.Model;
            Crownwood.Magic.Controls.TabPage page = new Crownwood.Magic.Controls.TabPage("满月健康检查记录表", this.f1);
            this.tabControl1.TabPages.Add(page);
            this.f2 = new KidsWithinOneYearOldVisitForm(2);
            this.f2.Model = this.Model;
            this.tabControl1.TabPages.Add(new Crownwood.Magic.Controls.TabPage("3月龄健康检查记录表", this.f2));
            this.f3 = new KidsWithinOneYearOldVisitForm(3);
            this.f3.Model = this.Model;
            this.tabControl1.TabPages.Add(new Crownwood.Magic.Controls.TabPage("6月龄健康检查记录表", this.f3));
            this.f4 = new KidsWithinOneYearOldVisitForm(4);
            this.f4.Model = this.Model;
            this.tabControl1.TabPages.Add(new Crownwood.Magic.Controls.TabPage("8月龄健康检查记录表", this.f4));
            page.Selected = true;
            this.EveryThingIsOk = true;
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.IDEPixelBorder = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.ShowArrows = false;
            this.tabControl1.ShowClose = false;
            this.tabControl1.Size = new System.Drawing.Size(1540, 680);
            this.tabControl1.TabIndex = 2;
            // 
            // KidsInOneYearOldVisitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "KidsInOneYearOldVisitForm";
            this.Text = "KidsOneYearOldVisitForm";
            this.Load += new System.EventHandler(this.FrmChildInAge1_Load);
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            if (this.f1.EveryThingIsOk)
            {
                this.f1.SaveModelToDB();
            }
            if (this.f2.EveryThingIsOk)
            {
                this.f2.SaveModelToDB();
            }
            if (this.f3.EveryThingIsOk)
            {
                this.f3.SaveModelToDB();
            }
            if (this.f4.EveryThingIsOk)
            {
                this.f4.SaveModelToDB();
            }
            return true;
        }

        public void UpdataToModel()
        {
            if (this.f1.EveryThingIsOk)
            {
                this.f1.UpdataToModel();
            }
            if (this.f2.EveryThingIsOk)
            {
                this.f2.UpdataToModel();
            }
            if (this.f3.EveryThingIsOk)
            {
                this.f3.UpdataToModel();
            }
            if (this.f4.EveryThingIsOk)
            {
                this.f4.UpdataToModel();
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }
    }
}

